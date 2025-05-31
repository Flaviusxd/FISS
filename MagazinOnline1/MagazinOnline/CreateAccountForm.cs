using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using MagazinOnline.Clase;

namespace MagazinOnline
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Cumpărător");
            comboBox1.Items.Add("Vânzător");
            comboBox1.SelectedIndex = 0;
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {

        }

        private void CreateAccountForm_Load_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string type = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Calea completă către folderul Conturi din root-ul proiectului
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Conturi");

            // Alegerea fișierului în funcție de tip
            string filepath = type == "Cumpărător"
                ? "Conturi/buyers.json"
                : "Conturi/sellers.json";

            // Dacă fișierul nu există, îl creăm cu un array gol
            if (!File.Exists(filepath))
            {
                File.WriteAllText(filepath, "[]");
            }

            // Deserializare
            List<User> users;
            if (type == "Cumpărător")
            {
                users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filepath)) ?? new List<User>();
            }
            else // Vânzător
            {
                users = JsonSerializer.Deserialize<List<Seller>>(File.ReadAllText(filepath)).Cast<User>().ToList();
            }

            // Verificare dacă email-ul există deja
            if (users.Any(u => u.Email == email))
            {
                MessageBox.Show("Email already exists.");
                return;
            }

            // Adăugare utilizator nou
            if (type == "Cumpărător")
            {
                users.Add(new User { Email = email, Password = password });
            }
            else if (type == "Vânzător")
            {
                users.Add(new Seller { Email = email, Password = password });
            }

            // Serializare înapoi în fișier
            File.WriteAllText(filepath, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

            MessageBox.Show("Account created successfully!");
            this.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
