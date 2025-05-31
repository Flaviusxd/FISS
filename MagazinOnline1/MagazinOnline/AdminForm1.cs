using MagazinOnline.Clase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace MagazinOnline
{
    public partial class AdminForm1 : Form
    {
        private List<Seller> vanzatori;
        private List<Product> produse;

        public AdminForm1()
        {
            InitializeComponent();
            IncarcaVanzatori();
            IncarcaProduse();
            AfiseazaVanzatori();
        }

        private void IncarcaVanzatori()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Conturi", "sellers.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                vanzatori = JsonSerializer.Deserialize<List<Seller>>(json) ?? new List<Seller>();
                dataGridViewVanzatori.DataSource = vanzatori.Select(v => new
                {
                    v.Email,
                    Aprobat = v.IsApproved ? "Da" : "Nu",
                    Activ = v.IsActive ? "Da" : "Nu"
                }).ToList();
            }
            else
            {
                MessageBox.Show($"Fișierul {path} nu a fost găsit.");
            }
        }

        private void AfiseazaVanzatori()
        {
            dataGridViewVanzatori.DataSource = vanzatori.Select(v => new
            {
                v.Email,
                Aprobat = v.IsApproved ? "Da" : "Nu",
                Activ = v.IsActive ? "Da" : "Nu"
            }).ToList();
        }


        private void IncarcaProduse()
        {
            string path = "Produse/produse.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                produse = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
                dataGridViewProduse.DataSource = produse.Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.VanzatorEmail,
                    p.Description,
                    Negociabil = p.EsteNegociabil ? "Da" : "Nu"
                }).ToList();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewVanzatori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewVanzatori.DataSource = vanzatori;
        }

        private void dataGridViewProduse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewProduse.DataSource = produse;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewVanzatori.CurrentRow != null)
            {
                string email = dataGridViewVanzatori.CurrentRow.Cells["Email"].Value.ToString();
                var vanzator = vanzatori.FirstOrDefault(v => v.Email == email);
                if (vanzator != null)
                {
                    vanzator.IsApproved = true;
                    SalveazaVanzatori();
                    IncarcaVanzatori();
                }
            }
            else
            {
                MessageBox.Show("Selectează un vânzător pentru aprobare.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewVanzatori.CurrentRow != null)
            {
                string email = dataGridViewVanzatori.CurrentRow.Cells["Email"].Value.ToString();
                var vanzator = vanzatori.FirstOrDefault(v => v.Email == email);
                if (vanzator != null)
                {
                    vanzator.IsActive = false;
                    SalveazaVanzatori();
                    IncarcaVanzatori();
                }
            }
            else
            {
                MessageBox.Show("Selectează un vânzător pentru dezactivare.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduse.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewProduse.CurrentRow.Cells["Id"].Value);
                var produs = produse.FirstOrDefault(p => p.Id == id);
                if (produs != null)
                {
                    produse.Remove(produs);
                    SalveazaProduse();
                    IncarcaProduse();
                }
            }
            else
            {
                MessageBox.Show("Selectează un produs pentru ștergere.");
            }
        }

        private void SalveazaVanzatori()
        {
            string path = "Conturi/sellers.json";
            string json = JsonSerializer.Serialize(vanzatori, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
        private void SalveazaProduse()
        {
            string path = "Produse/produse.json";
            string json = JsonSerializer.Serialize(produse, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewVanzatori.CurrentRow != null)
            {
                string email = dataGridViewVanzatori.CurrentRow.Cells["Email"].Value.ToString();
                var vanzator = vanzatori.FirstOrDefault(v => v.Email == email);
                if (vanzator != null)
                {
                    vanzator.IsActive = true;
                    SalveazaVanzatori();
                    IncarcaVanzatori();
                }
            }
            else
            {
                MessageBox.Show("Selectează un vânzător pentru activare.");
            }
        }

        private void AdminForm1_Load(object sender, EventArgs e)
        {

        }
    }
}
