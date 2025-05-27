using MagazinOnline.Clase;
using System.Text.Json;

namespace MagazinOnline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccountForm form = new CreateAccountForm();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Calea absolută către folderul "Conturi"
            //string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Conturi");

            // Verificare administrator
            string adminPath = "Conturi/admin_accounts.json";
            if (File.Exists(adminPath))
            {
                var admins = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(adminPath));
                if (admins.Any(a => a.Email == email && a.Password == password))
                {
                    AdminForm1 adminForm = new AdminForm1();
                    adminForm.Show();
                    this.Hide();
                    return;
                }
            }

            // Verificare cumpărător
            string buyerPath = "Conturi/buyers.json";
            if (File.Exists(buyerPath))
            {
                var buyers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(buyerPath));
                var buyer = buyers.FirstOrDefault(b => b.Email == email && b.Password == password);
                if (buyer!=null)
                {
                    BuyerForm buyerForm = new BuyerForm(buyer);
                    buyerForm.Show();
                    this.Hide();
                    return;
                }
            }

            // Verificare vânzător
            string sellerPath = "Conturi/sellers.json";
            if (File.Exists(sellerPath))
            {
                var sellers = JsonSerializer.Deserialize<List<Seller>>(File.ReadAllText(sellerPath));
                var seller = sellers.FirstOrDefault(s => s.Email == email && s.Password == password);
                if (seller != null)
                {
                    if (!seller.IsApproved)
                    {
                        MessageBox.Show("Contul tău de vânzător nu a fost aprobat încă.");
                        return;
                    }
                    if (!seller.IsActive)
                    {
                        MessageBox.Show("Contul tău de vânzător a fost dezactivat.");
                        return;
                    }

                    SellerForm sellerForm = new SellerForm(seller);
                    sellerForm.Show();
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Email sau parolă incorecte.");
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
