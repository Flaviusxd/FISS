using MagazinOnline.Clase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace MagazinOnline
{
    public partial class BuyerForm : Form
    {
        private User cumparatorCurent;
        private List<Product> produse;
        private List<Offer> oferte;
        private List<dynamic> istoricVanzari;

        public BuyerForm(User cumparator)
        {
            InitializeComponent();
            this.cumparatorCurent = cumparator;
            InitializeData();
            SetupUI();
        }

        private void InitializeData()
        {
            try
            {
                CreateDirectoriesIfNotExist();
                IncarcaProduse();
                IncarcaOferte();
                IncarcaIstoricVanzari();
                AfiseazaProduse();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la inițializarea datelor: {ex.Message}");
            }
        }

        private void SetupUI()
        {
            // Setează textul de bun venit
            if (lblBunVenit != null)
            {
                lblBunVenit.Text = $"Bun venit, {cumparatorCurent.Email}!";
            }

            // Configurează DataGridView pentru produse
            if (dataGridViewProduse != null)
            {
                dataGridViewProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProduse.MultiSelect = false;
                dataGridViewProduse.ReadOnly = true;
            }

            // Configurează DataGridView pentru istoric
            if (dataGridViewIstoric != null)
            {
                dataGridViewIstoric.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewIstoric.MultiSelect = false;
                dataGridViewIstoric.ReadOnly = true;
            }
        }

        private void CreateDirectoriesIfNotExist()
        {
            string[] directories = { "Produse", "Oferte", "Vanzari", "Conturi" };
            foreach (string dir in directories)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }

        private void btnIesire_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCumparaDirect_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProduse.CurrentRow == null)
                {
                    MessageBox.Show("Selectați un produs pentru cumpărare.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewProduse.CurrentRow.Cells["Id"].Value);
                var produs = produse.FirstOrDefault(p => p.Id == id);

                if (produs == null)
                {
                    MessageBox.Show("Produsul selectat nu mai există.");
                    return;
                }

                // Verifică dacă produsul aparține cumpărătorului curent
                if (produs.VanzatorEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Nu puteți cumpăra propriul produs.");
                    return;
                }

                var result = MessageBox.Show($"Confirmați cumpărarea produsului '{produs.Name}' la prețul de {produs.Price:C}?",
                                           "Confirmare cumpărare",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FinalizareVanzare(produs, produs.Price);
                    MessageBox.Show($"Produsul '{produs.Name}' a fost cumpărat cu succes pentru {produs.Price:C}!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la cumpărarea produsului: {ex.Message}");
            }
        }

        private void btnFaceOferta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProduse.CurrentRow == null)
                {
                    MessageBox.Show("Selectați un produs pentru a face o ofertă.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewProduse.CurrentRow.Cells["Id"].Value);
                var produs = produse.FirstOrDefault(p => p.Id == id);

                if (produs == null)
                {
                    MessageBox.Show("Produsul selectat nu mai există.");
                    return;
                }

                if (!produs.EsteNegociabil)
                {
                    MessageBox.Show("Acest produs nu este negociabil. Puteți doar să îl cumpărați direct.");
                    return;
                }

                // Verifică dacă produsul aparține cumpărătorului curent
                if (produs.VanzatorEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Nu puteți face ofertă pentru propriul produs.");
                    return;
                }

                // Verifică dacă cumpărătorul a mai făcut o ofertă pentru acest produs
                if (oferte.Any(o => o.ProductId == id && o.BuyerEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Aveți deja o ofertă activă pentru acest produs.");
                    return;
                }

                // Deschide formularul pentru introducerea ofertei
                using (var ofertaForm = new OfertaForm(produs))
                {
                    if (ofertaForm.ShowDialog() == DialogResult.OK)
                    {
                        decimal pretOferta = ofertaForm.PretOferta;

                        // Verifică dacă oferta este peste prețul minim (dacă există)
                        if (produs.PretMinim.HasValue && pretOferta < produs.PretMinim.Value)
                        {
                            MessageBox.Show($"Oferta dvs. de {pretOferta:C} este sub prețul minim acceptat. Oferta a fost refuzată automat.");
                            return;
                        }

                        var oferta = new Offer
                        {
                            ProductId = produs.Id,
                            BuyerEmail = cumparatorCurent.Email,
                            OfferPrice = pretOferta,
                            DataOferta = DateTime.Now
                        };

                        oferte.Add(oferta);
                        SalveazaOferte();
                        MessageBox.Show($"Oferta dvs. de {pretOferta:C} pentru produsul '{produs.Name}' a fost înregistrată și trimisă către vânzător.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la crearea ofertei: {ex.Message}");
            }
        }

        private void btnCumparaNegociat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProduse.CurrentRow == null)
                {
                    MessageBox.Show("Selectați un produs pentru cumpărare.");
                    return;
                }

                int id = Convert.ToInt32(dataGridViewProduse.CurrentRow.Cells["Id"].Value);
                var produs = produse.FirstOrDefault(p => p.Id == id);

                if (produs == null)
                {
                    MessageBox.Show("Produsul selectat nu mai există.");
                    return;
                }

                if (!produs.EsteNegociabil)
                {
                    MessageBox.Show("Acest produs nu este negociabil.");
                    return;
                }

                // Verifică dacă există o ofertă aprobată pentru acest produs și cumpărător
                var ofertaAprobata = oferte.FirstOrDefault(o => o.ProductId == id &&
                                                               o.BuyerEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase) &&
                                                               o.EsteAprobata);

                if (ofertaAprobata == null)
                {
                    MessageBox.Show("Nu aveți o ofertă aprobată pentru acest produs. Faceți mai întâi o ofertă și așteptați aprobarea vânzătorului.");
                    return;
                }

                var result = MessageBox.Show($"Confirmați cumpărarea produsului '{produs.Name}' la prețul negociat de {ofertaAprobata.OfferPrice:C}?",
                                           "Confirmare cumpărare negociată",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    FinalizareVanzare(produs, ofertaAprobata.OfferPrice);
                    MessageBox.Show($"Produsul '{produs.Name}' a fost cumpărat cu succes la prețul negociat de {ofertaAprobata.OfferPrice:C}!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la cumpărarea produsului negociat: {ex.Message}");
            }
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                IncarcaProduse();
                IncarcaOferte();
                IncarcaIstoricVanzari();
                AfiseazaProduse();
                AfiseazaIstoricVanzari();
                MessageBox.Show("Datele au fost actualizate.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea datelor: {ex.Message}");
            }
        }

        private void FinalizareVanzare(Product produs, decimal pretVanzare)
        {
            try
            {
                // Creează înregistrarea de vânzare
                var vanzare = new
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = produs.Id,
                    ProductName = produs.Name,
                    SellerEmail = produs.VanzatorEmail,
                    BuyerEmail = cumparatorCurent.Email,
                    PretOriginal = produs.Price,
                    PretVanzare = pretVanzare,
                    DataVanzare = DateTime.Now,
                    EsteNegociat = pretVanzare != produs.Price
                };

                // Adaugă în istoric
                istoricVanzari.Add(vanzare);
                SalveazaIstoricVanzari();

                // Șterge produsul din listă
                produse.Remove(produs);
                SalveazaProduse();

                // Șterge toate ofertele pentru acest produs
                oferte.RemoveAll(o => o.ProductId == produs.Id);
                SalveazaOferte();

                // Actualizează afișajul
                AfiseazaProduse();
                AfiseazaIstoricVanzari();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la finalizarea vânzării: {ex.Message}");
            }
        }

        private void IncarcaProduse()
        {
            try
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
                    File.WriteAllText(path, "[]");
                }
            }
            catch (Exception ex)
            {
                produse = new List<Product>();
                MessageBox.Show($"Eroare la încărcarea produselor: {ex.Message}");
            }
        }

        private void SalveazaProduse()
        {
            try
            {
                string path = "Produse/produse.json";
                string json = JsonSerializer.Serialize(produse, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea produselor: {ex.Message}");
            }
        }

        private void IncarcaOferte()
        {
            try
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
                    File.WriteAllText(path, "[]");
                }
            }
            catch (Exception ex)
            {
                oferte = new List<Offer>();
                MessageBox.Show($"Eroare la încărcarea ofertelor: {ex.Message}");
            }
        }

        private void SalveazaOferte()
        {
            try
            {
                string path = "Oferte/oferte.json";
                string json = JsonSerializer.Serialize(oferte, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea ofertelor: {ex.Message}");
            }
        }

        private void IncarcaIstoricVanzari()
        {
            try
            {
                string path = "Vanzari/vanzari.json";
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    istoricVanzari = JsonSerializer.Deserialize<List<dynamic>>(json) ?? new List<dynamic>();
                }
                else
                {
                    istoricVanzari = new List<dynamic>();
                    File.WriteAllText(path, "[]");
                }
            }
            catch (Exception ex)
            {
                istoricVanzari = new List<dynamic>();
                MessageBox.Show($"Eroare la încărcarea istoricului: {ex.Message}");
            }
        }

        private void SalveazaIstoricVanzari()
        {
            try
            {
                string path = "Vanzari/vanzari.json";
                string json = JsonSerializer.Serialize(istoricVanzari, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvarea istoricului: {ex.Message}");
            }
        }

        private void AfiseazaProduse()
        {
            try
            {
                // Filtrează produsele pentru a afișa doar cele care nu aparțin cumpărătorului curent
                var produseDisponibile = produse
                    .Where(p => !p.VanzatorEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new
                    {
                        p.Id,
                        p.Name,
                        Pret = p.Price.ToString("C"),
                        Vanzator = p.VanzatorEmail,
                        p.Description,
                        Negociabil = p.EsteNegociabil ? "Da" : "Nu",
                        StatusOferta = GetStatusOferta(p.Id)
                    }).ToList();

                dataGridViewProduse.DataSource = produseDisponibile;

                // Ascunde coloana Id
                if (dataGridViewProduse.Columns["Id"] != null)
                {
                    dataGridViewProduse.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la afișarea produselor: {ex.Message}");
            }
        }

        private string GetStatusOferta(int productId)
        {
            var ofertaCurenta = oferte.FirstOrDefault(o => o.ProductId == productId &&
                                                          o.BuyerEmail.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase));

            if (ofertaCurenta == null)
                return "Fără ofertă";

            if (ofertaCurenta.EsteAprobata)
                return "Ofertă aprobată";

            return $"Ofertă în așteptare ({ofertaCurenta.OfferPrice:C})";
        }

        private void AfiseazaIstoricVanzari()
        {
            try
            {
                // Afișează doar cumpărările făcute de cumpărătorul curent
                var cumpararileMele = istoricVanzari
                    .Where(v => GetPropertyValue(v, "BuyerEmail")?.ToString()?.Equals(cumparatorCurent.Email, StringComparison.OrdinalIgnoreCase) == true)
                    .Select(v => new
                    {
                        Produs = GetPropertyValue(v, "ProductName")?.ToString(),
                        Vanzator = GetPropertyValue(v, "SellerEmail")?.ToString(),
                        PretOriginal = GetPropertyValue(v, "PretOriginal")?.ToString(),
                        PretVanzare = GetPropertyValue(v, "PretVanzare")?.ToString(),
                        DataVanzare = GetPropertyValue(v, "DataVanzare")?.ToString(),
                        Negociat = (bool?)GetPropertyValue(v, "EsteNegociat") == true ? "Da" : "Nu"
                    }).ToList();

                dataGridViewIstoric.DataSource = cumpararileMele;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la afișarea istoricului: {ex.Message}");
            }
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            try
            {
                if (obj is JsonElement element)
                {
                    if (element.TryGetProperty(propertyName, out JsonElement prop))
                    {
                        switch (prop.ValueKind)
                        {
                            case JsonValueKind.String:
                                // For Date strings, they will be returned as strings.
                                // Further parsing to DateTime can be done where it's used if needed.
                                return prop.GetString();
                            case JsonValueKind.Number:
                                // Attempt to get decimal for prices, add other types if necessary
                                if (prop.TryGetDecimal(out decimal decValue))
                                {
                                    return decValue;
                                }
                                // Fallback for other number types if needed (e.g., int, double)
                                if (prop.TryGetInt32(out int intValue)) return intValue;
                                if (prop.TryGetInt64(out long longValue)) return longValue;
                                return prop.GetDouble(); // General fallback
                            case JsonValueKind.True:
                                return true; // Correctly return a boolean true
                            case JsonValueKind.False:
                                return false; // Correctly return a boolean false
                            case JsonValueKind.Null:
                                return null;
                            case JsonValueKind.Object:
                            case JsonValueKind.Array:
                                // Return a clone if you might need to access it after the original JsonDocument is disposed
                                return prop.Clone();
                            default:
                                // Fallback for any other unexpected JsonValueKind
                                return prop.GetRawText(); // Note: GetRawText() might include quotes for string literals
                        }
                    }
                    return null; // Property not found in JsonElement
                }

                // If obj is not a JsonElement (e.g., it's an already materialized .NET object,
                // like before data is first serialized), use reflection.
                var propertyInfo = obj?.GetType().GetProperty(propertyName);
                return propertyInfo?.GetValue(obj);
            }
            catch (Exception ex)
            {
                // It's good practice to log the exception or at least output it for debugging
                System.Diagnostics.Debug.WriteLine($"Error in GetPropertyValue for '{propertyName}': {ex.Message} - {ex.StackTrace}");
                // Optionally, you could show a MessageBox here, but it might be too frequent for errors.
                // MessageBox.Show($"DEBUG: Error in GetPropertyValue for '{propertyName}': {ex.Message}");
                return null;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1) // Tab-ul pentru istoric
                {
                    AfiseazaIstoricVanzari();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la schimbarea tab-ului: {ex.Message}");
            }
        }

        private void dataGridViewProduse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Poți adăuga logică suplimentară aici dacă este necesar
        }

        private void dataGridViewIstoric_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Poți adăuga logică suplimentară aici dacă este necesar
        }

        private void BuyerForm_Load(object sender, EventArgs e)
        {
            // Orice inițializare suplimentară la încărcarea formularului
        }

        private void lblProduse_Click(object sender, EventArgs e)
        {

        }

        private void tabProduse_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    // Formular pentru introducerea ofertei
    public partial class OfertaForm : Form
    {
        public decimal PretOferta { get; private set; }
        private Product produs;

        public OfertaForm(Product produs)
        {
            InitializeComponent();
            this.produs = produs;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Faceți o ofertă";
            this.Size = new System.Drawing.Size(400, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblProdus = new Label
            {
                Text = $"Produs: {produs.Name}",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(350, 20)
            };

            var lblPretCurent = new Label
            {
                Text = $"Preț curent: {produs.Price:C}",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(350, 20)
            };

            var lblOferta = new Label
            {
                Text = "Oferta dvs.:",
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(100, 20)
            };

            var numPretOferta = new NumericUpDown
            {
                Name = "numPretOferta",
                Location = new System.Drawing.Point(130, 78),
                Size = new System.Drawing.Size(120, 20),
                DecimalPlaces = 2,
                Minimum = 0.01m,
                Maximum = 999999.99m,
                Value = Math.Max(produs.Price * 0.8m, 0.01m) // Sugerează 80% din prețul original
            };

            var btnOK = new Button
            {
                Text = "Trimite Oferta",
                Location = new System.Drawing.Point(200, 120),
                Size = new System.Drawing.Size(100, 30),
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Anulează",
                Location = new System.Drawing.Point(310, 120),
                Size = new System.Drawing.Size(70, 30),
                DialogResult = DialogResult.Cancel
            };

            btnOK.Click += (s, e) => {
                PretOferta = numPretOferta.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            this.Controls.AddRange(new Control[] { lblProdus, lblPretCurent, lblOferta, numPretOferta, btnOK, btnCancel });
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}