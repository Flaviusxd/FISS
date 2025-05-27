using MagazinOnline.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazinOnline
{
    public partial class SellerForm : Form
    {
        private Seller vanzatorCurent;
        private List<Product> produse;
        private List<Offer> oferte;

        public SellerForm(Seller vanzator)
        {
            InitializeComponent();
            this.vanzatorCurent = vanzator;
            IncarcaProduse();
            AfiseazaProduse();
            IncarcaOferte();
            AfiseazaOferta();

            // Configurează vizibilitatea inițială a controalelor pentru prețul minim
            SetMinPriceControlsVisibility(chkNegociabil.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCereAprobare_Click(object sender, EventArgs e)
        {
            vanzatorCurent.IsApproved = true;
            SalveazaVanzator();
            MessageBox.Show("Cererea de aprobare a fost trimisă.");
        }

        private void btnAdaugaProdus_Click(object sender, EventArgs e)
        {
            // Validări de bază
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Introduceți numele produsului.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPret.Value <= 0)
            {
                MessageBox.Show("Prețul trebuie să fie mai mare ca 0.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validări pentru prețul minim dacă obiectul este negociabil
            if (chkNegociabil.Checked)
            {
                if (numPretMinim.Value <= 0)
                {
                    MessageBox.Show("Pentru produsele negociabile trebuie să specificați un preț minim valid.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numPretMinim.Focus();
                    return;
                }

                if (numPretMinim.Value >= numPret.Value)
                {
                    MessageBox.Show("Prețul minim trebuie să fie mai mic decât prețul inițial.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numPretMinim.Focus();
                    return;
                }
            }

            var produs = new Product
            {
                Id = GetNextProductId(),
                Name = txtNume.Text.Trim(),
                Price = numPret.Value,
                Description = txtDescriere.Text?.Trim() ?? "",
                EsteNegociabil = chkNegociabil.Checked,
                VanzatorEmail = vanzatorCurent.Email,
                MinPrice = chkNegociabil.Checked ? numPretMinim.Value : (decimal?)null
            };

            produse.Add(produs);
            SalveazaProduse();
            AfiseazaProduse();
            ClearForm();
            MessageBox.Show("Produs adăugat cu succes!");
        }

        private void btnAnuleazaVanzare_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduse.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewProduse.CurrentRow.Cells["Id"].Value);
                var produs = produse.FirstOrDefault(p => p.Id == id && p.VanzatorEmail == vanzatorCurent.Email);
                if (produs != null)
                {
                    var result = MessageBox.Show($"Sigur doriți să anulați produsul '{produs.Name}'?",
                                               "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        produse.Remove(produs);
                        SalveazaProduse();
                        AfiseazaProduse();
                        MessageBox.Show("Produsul a fost anulat.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați un produs pentru a-l anula.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAprobaNegociere_Click(object sender, EventArgs e)
        {
            if (dataGridViewOferte.CurrentRow != null)
            {
                int produsId = Convert.ToInt32(dataGridViewOferte.CurrentRow.Cells["ProductId"].Value);
                string cumparator = dataGridViewOferte.CurrentRow.Cells["BuyerEmail"].Value.ToString();

                var oferta = oferte.FirstOrDefault(o => o.ProductId == produsId && o.BuyerEmail == cumparator);
                var produs = produse.FirstOrDefault(p => p.Id == produsId && p.VanzatorEmail == vanzatorCurent.Email);

                if (oferta != null && produs != null)
                {
                    var result = MessageBox.Show($"Acceptați oferta de {oferta.OfferPrice:C} pentru '{produs.Name}' de la {cumparator}?",
                                               "Confirmare vânzare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ProceseazaVanzarea(produs, oferta);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o ofertă pentru a o aproba.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnuleazaNegociere_Click(object sender, EventArgs e)
        {
            if (dataGridViewOferte.CurrentRow != null)
            {
                int produsId = Convert.ToInt32(dataGridViewOferte.CurrentRow.Cells["ProductId"].Value);
                string cumparator = dataGridViewOferte.CurrentRow.Cells["BuyerEmail"].Value.ToString();

                var oferta = oferte.FirstOrDefault(o => o.ProductId == produsId && o.BuyerEmail == cumparator);
                if (oferta != null)
                {
                    var result = MessageBox.Show($"Sigur doriți să respingeți oferta de {oferta.OfferPrice:C} de la {cumparator}?",
                                               "Confirmare respingere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        oferte.Remove(oferta);
                        SalveazaOferta();
                        AfiseazaOferta();
                        MessageBox.Show("Oferta a fost respinsă.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o ofertă pentru a o respinge.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkNegociabil_CheckedChanged(object sender, EventArgs e)
        {
            SetMinPriceControlsVisibility(chkNegociabil.Checked);

            // Dacă se debifează, resetează prețul minim
            if (!chkNegociabil.Checked)
            {
                numPretMinim.Value = 0;
            }
        }

        // Metodă pentru a controla vizibilitatea controalelor pentru prețul minim
        private void SetMinPriceControlsVisibility(bool isNegotiable)
        {
            // lblPretMinim.Visible = isNegotiable;
            numPretMinim.Visible = isNegotiable;

            if (isNegotiable)
            {
                // Setează o valoare implicită pentru prețul minim (ex: 80% din prețul normal)
                if (numPret.Value > 0)
                {
                    numPretMinim.Value = Math.Round(numPret.Value * 0.8m, 2);
                }
            }
        }

        // Metodă pentru a curăța formularul după adăugarea unui produs
        private void ClearForm()
        {
            txtNume.Text = "";
            txtDescriere.Text = "";
            numPret.Value = 0;
            numPretMinim.Value = 0;
            chkNegociabil.Checked = false;
            SetMinPriceControlsVisibility(false);
            txtNume.Focus(); // Pune focus pe primul câmp
        }

        // Metodă pentru procesarea automată a vânzării
        private void ProceseazaVanzarea(Product produs, Offer oferta)
        {
            produs.Price = oferta.OfferPrice; // Acceptă prețul negociat

            // Ștergem produsul vândut
            produse.Remove(produs);

            // Ștergem oferta aferentă
            oferte.Remove(oferta);

            SalveazaProduse();
            SalveazaOferta();
            AfiseazaProduse();
            AfiseazaOferta();

            MessageBox.Show($"Felicitări! Ați vândut '{produs.Name}' cu {oferta.OfferPrice:C} către {oferta.BuyerEmail}.",
                          "Vânzare finalizată", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Metodă pentru procesarea automată a ofertelor (refuzare automată pentru ofertele sub prețul minim)
        private void ProceseazaOferteleAutomat()
        {
            var oferteDeEliminat = new List<Offer>();

            // Găsește ofertele care sunt sub prețul minim și trebuie refuzate automat
            foreach (var oferta in oferte.ToList())
            {
                var produs = produse.FirstOrDefault(p => p.Id == oferta.ProductId && p.VanzatorEmail == vanzatorCurent.Email);

                if (produs != null && produs.EsteNegociabil && produs.MinPrice.HasValue)
                {
                    // Dacă oferta este sub prețul minim, o refuzăm automat
                    if (oferta.OfferPrice < produs.MinPrice.Value)
                    {
                        oferteDeEliminat.Add(oferta);
                    }
                }
            }

            // Elimină ofertele refuzate automat
            foreach (var oferta in oferteDeEliminat)
            {
                oferte.Remove(oferta);
            }

            // Salvează modificările dacă au fost eliminate oferte
            if (oferteDeEliminat.Count > 0)
            {
                SalveazaOferta();
            }
        }

        private void IncarcaProduse()
        {
            string path = "Produse/produse.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                produse = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
            }
            else
            {
                produse = new List<Product>();
            }
        }

        private void SalveazaProduse()
        {
            string path = "Produse/produse.json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string json = JsonSerializer.Serialize(produse, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        private void SalveazaVanzator()
        {
            string path = "Conturi/sellers.json";
            if (File.Exists(path))
            {
                var totiVanzatorii = JsonSerializer.Deserialize<List<Seller>>(File.ReadAllText(path));
                var index = totiVanzatorii.FindIndex(v => v.Email == vanzatorCurent.Email);
                if (index >= 0)
                {
                    totiVanzatorii[index] = vanzatorCurent;
                    File.WriteAllText(path, JsonSerializer.Serialize(totiVanzatorii, new JsonSerializerOptions { WriteIndented = true }));
                }
            }
        }

        private void AfiseazaProduse()
        {
            var produseAfisate = produse
                .Where(p => p.VanzatorEmail == vanzatorCurent.Email)
                .Select(p => new
                {
                    p.Id,
                    Nume = p.Name,
                    Preț = p.Price.ToString("C"),
                    PretMinim = p.MinPrice?.ToString("C") ?? "N/A",
                    Descriere = p.Description,
                    Negociabil = p.EsteNegociabil ? "Da" : "Nu"
                }).ToList();

            dataGridViewProduse.DataSource = produseAfisate;

            // Ajustează lățimea coloanelor
            if (dataGridViewProduse.Columns.Count > 0)
            {
                dataGridViewProduse.Columns["Id"].Width = 50;
                dataGridViewProduse.Columns["Nume"].Width = 150;
                dataGridViewProduse.Columns["Preț"].Width = 80;
                dataGridViewProduse.Columns["PretMinim"].Width = 80;
                dataGridViewProduse.Columns["Descriere"].Width = 200;
                dataGridViewProduse.Columns["Negociabil"].Width = 80;
            }
        }

        private void IncarcaOferte()
        {
            string path = "Oferte/oferte.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                oferte = JsonSerializer.Deserialize<List<Offer>>(json) ?? new List<Offer>();
            }
            else
            {
                oferte = new List<Offer>();
            }
        }

        private void SalveazaOferta()
        {
            string path = "Oferte/oferte.json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string json = JsonSerializer.Serialize(oferte, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        private void AfiseazaOferta()
        {
            // Procesează ofertele automat (elimină cele sub prețul minim)
            ProceseazaOferteleAutomat();

            dataGridViewOferte.Rows.Clear();
            dataGridViewOferte.Columns.Clear();

            string sellerEmail = vanzatorCurent.Email;

            try
            {
                var produse = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("Produse/produse.json")) ?? new List<Product>();
                var oferte = JsonSerializer.Deserialize<List<Offer>>(File.ReadAllText("Oferte/oferte.json")) ?? new List<Offer>();

                // Filtrează doar ofertele care îndeplinesc prețul minim sau pentru produsele non-negociabile
                var oferteAfisate = from oferta in oferte
                                    join produs in produse on oferta.ProductId equals produs.Id
                                    where produs.VanzatorEmail == sellerEmail &&
                                          (!produs.EsteNegociabil || // Pentru produsele non-negociabile
                                           !produs.MinPrice.HasValue || // Pentru produsele fără preț minim
                                           oferta.OfferPrice >= produs.MinPrice.Value) // Pentru ofertele care îndeplinesc prețul minim
                                    select new
                                    {
                                        NumeProdus = produs.Name,
                                        Cumparator = oferta.BuyerEmail,
                                        PretOferta = oferta.OfferPrice,
                                        PretMinim = produs.MinPrice,
                                        ProdusId = produs.Id,
                                        EsteNegociabil = produs.EsteNegociabil
                                    };

                // Adaugă coloanele
                dataGridViewOferte.Columns.Add("Produs", "Produs");
                dataGridViewOferte.Columns.Add("Cumparator", "Cumpărător");
                dataGridViewOferte.Columns.Add("PretOferta", "Preț oferit");
                dataGridViewOferte.Columns.Add("PretMinim", "Preț minim");
                dataGridViewOferte.Columns.Add("Status", "Status");
                dataGridViewOferte.Columns.Add("ProductId", "ProductId");
                dataGridViewOferte.Columns["ProductId"].Visible = false;
                dataGridViewOferte.Columns.Add("BuyerEmail", "BuyerEmail");
                dataGridViewOferte.Columns["BuyerEmail"].Visible = false;

                // Adaugă rândurile
                foreach (var item in oferteAfisate)
                {
                    string status = "✓ Necesită aprobare";
                    string pretMinimText = item.PretMinim.HasValue ? item.PretMinim.Value.ToString("C") : "N/A";

                    var row = dataGridViewOferte.Rows.Add(
                        item.NumeProdus,
                        item.Cumparator,
                        item.PretOferta.ToString("C"),
                        pretMinimText,
                        status,
                        item.ProdusId,
                        item.Cumparator
                    );

                    // Colorează rândul în verde pentru ofertele valide
                    dataGridViewOferte.Rows[row].DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // Ajustează lățimea coloanelor
                if (dataGridViewOferte.Columns.Count > 0)
                {
                    dataGridViewOferte.Columns["Produs"].Width = 150;
                    dataGridViewOferte.Columns["Cumparator"].Width = 120;
                    dataGridViewOferte.Columns["PretOferta"].Width = 100;
                    dataGridViewOferte.Columns["PretMinim"].Width = 100;
                    dataGridViewOferte.Columns["Status"].Width = 120;
                }

                // Afișează un mesaj informativ dacă nu există oferte
                if (!oferteAfisate.Any())
                {
                    // Poți adăuga un mesaj într-un label sau păstra lista goală
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea ofertelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetNextProductId()
        {
            return produse.Any() ? produse.Max(p => p.Id) + 1 : 1;
        }

        // Event handlers existente
        private void SellerForm_Load(object sender, EventArgs e)
        {
            AfiseazaOferta();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblBunVenit_Click(object sender, EventArgs e)
        {

        }

        private void SellerForm_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridViewProduse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            AfiseazaOferta();
        }

        private void dataGridViewOferte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AfiseazaOferta();
        }
        // Event handler pentru schimbarea prețului - actualizează automat prețul minim sugerat
        private void numPret_ValueChanged(object sender, EventArgs e)
        {
            if (chkNegociabil.Checked && numPret.Value > 0)
            {
                // Sugerează 80% din prețul normal ca preț minim
                numPretMinim.Value = Math.Round(numPret.Value * 0.8m, 2);
            }
        }
    }
}