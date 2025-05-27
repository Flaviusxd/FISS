namespace MagazinOnline
{
    partial class SellerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerForm));
            lblBunVenit = new Label();
            groupBox1 = new GroupBox();
            chkNegociabil = new CheckBox();
            txtDescriere = new TextBox();
            numPret = new NumericUpDown();
            txtNume = new TextBox();
            btnAdaugaProdus = new Button();
            dataGridViewProduse = new DataGridView();
            btnAnuleazaVanzare = new Button();
            btnAprobaNegociere = new Button();
            btnAnuleazaNegociere = new Button();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridViewOferte = new DataGridView();
            numPretMinim = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPret).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOferte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPretMinim).BeginInit();
            SuspendLayout();
            // 
            // lblBunVenit
            // 
            lblBunVenit.AutoSize = true;
            lblBunVenit.BackColor = Color.Transparent;
            lblBunVenit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBunVenit.ForeColor = Color.White;
            lblBunVenit.Location = new Point(27, 53);
            lblBunVenit.Name = "lblBunVenit";
            lblBunVenit.Size = new Size(88, 21);
            lblBunVenit.TabIndex = 0;
            lblBunVenit.Text = "Bun venit!";
            lblBunVenit.Click += lblBunVenit_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(numPretMinim);
            groupBox1.Controls.Add(chkNegociabil);
            groupBox1.Controls.Add(txtDescriere);
            groupBox1.Controls.Add(numPret);
            groupBox1.Controls.Add(txtNume);
            groupBox1.Controls.Add(btnAdaugaProdus);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(27, 103);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 229);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Adaugă produs";
            // 
            // chkNegociabil
            // 
            chkNegociabil.Location = new Point(20, 125);
            chkNegociabil.Name = "chkNegociabil";
            chkNegociabil.Size = new Size(115, 31);
            chkNegociabil.TabIndex = 0;
            chkNegociabil.Text = "Negociabil?";
            chkNegociabil.CheckedChanged += chkNegociabil_CheckedChanged;
            // 
            // txtDescriere
            // 
            txtDescriere.Location = new Point(20, 88);
            txtDescriere.Name = "txtDescriere";
            txtDescriere.PlaceholderText = "Descriere produs";
            txtDescriere.Size = new Size(350, 29);
            txtDescriere.TabIndex = 1;
            // 
            // numPret
            // 
            numPret.DecimalPlaces = 2;
            numPret.Location = new Point(20, 58);
            numPret.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPret.Name = "numPret";
            numPret.Size = new Size(150, 29);
            numPret.TabIndex = 2;
            // 
            // txtNume
            // 
            txtNume.Location = new Point(20, 28);
            txtNume.Name = "txtNume";
            txtNume.PlaceholderText = "Nume produs";
            txtNume.Size = new Size(350, 29);
            txtNume.TabIndex = 3;
            // 
            // btnAdaugaProdus
            // 
            btnAdaugaProdus.BackColor = Color.Silver;
            btnAdaugaProdus.ForeColor = Color.Black;
            btnAdaugaProdus.Location = new Point(20, 191);
            btnAdaugaProdus.Name = "btnAdaugaProdus";
            btnAdaugaProdus.Size = new Size(150, 32);
            btnAdaugaProdus.TabIndex = 4;
            btnAdaugaProdus.Text = "Adaugă produs";
            btnAdaugaProdus.UseVisualStyleBackColor = false;
            btnAdaugaProdus.Click += btnAdaugaProdus_Click;
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.Location = new Point(0, 0);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.ReadOnly = true;
            dataGridViewProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProduse.Size = new Size(513, 324);
            dataGridViewProduse.TabIndex = 3;
            dataGridViewProduse.CellContentClick += dataGridViewProduse_CellContentClick;
            // 
            // btnAnuleazaVanzare
            // 
            btnAnuleazaVanzare.Location = new Point(505, 400);
            btnAnuleazaVanzare.Name = "btnAnuleazaVanzare";
            btnAnuleazaVanzare.Size = new Size(150, 33);
            btnAnuleazaVanzare.TabIndex = 4;
            btnAnuleazaVanzare.Text = "Anulează vânzare";
            btnAnuleazaVanzare.Click += btnAnuleazaVanzare_Click;
            // 
            // btnAprobaNegociere
            // 
            btnAprobaNegociere.Location = new Point(685, 400);
            btnAprobaNegociere.Name = "btnAprobaNegociere";
            btnAprobaNegociere.Size = new Size(150, 33);
            btnAprobaNegociere.TabIndex = 5;
            btnAprobaNegociere.Text = "Aprobă negociere";
            btnAprobaNegociere.Click += btnAprobaNegociere_Click;
            // 
            // btnAnuleazaNegociere
            // 
            btnAnuleazaNegociere.Location = new Point(854, 400);
            btnAnuleazaNegociere.Name = "btnAnuleazaNegociere";
            btnAnuleazaNegociere.Size = new Size(150, 33);
            btnAnuleazaNegociere.TabIndex = 6;
            btnAnuleazaNegociere.Text = "Anulează negociere";
            btnAnuleazaNegociere.Click += btnAnuleazaNegociere_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 18, 18);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1020, 36);
            panel1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 11);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 4;
            label2.Text = "FIS";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(983, 0);
            button1.Name = "button1";
            button1.Size = new Size(37, 36);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(487, 42);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(521, 352);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridViewProduse);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(513, 324);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewOferte);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(513, 324);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // dataGridViewOferte
            // 
            dataGridViewOferte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOferte.Location = new Point(0, 0);
            dataGridViewOferte.Name = "dataGridViewOferte";
            dataGridViewOferte.Size = new Size(513, 328);
            dataGridViewOferte.TabIndex = 0;
            dataGridViewOferte.CellContentClick += dataGridViewOferte_CellContentClick;
            // 
            // numPretMinim
            // 
            numPretMinim.DecimalPlaces = 2;
            numPretMinim.Location = new Point(20, 156);
            numPretMinim.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPretMinim.Name = "numPretMinim";
            numPretMinim.Size = new Size(150, 29);
            numPretMinim.TabIndex = 5;
            numPretMinim.Visible = false;
           // numPretMinim.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // SellerForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1020, 473);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Controls.Add(lblBunVenit);
            Controls.Add(groupBox1);
            Controls.Add(btnAnuleazaVanzare);
            Controls.Add(btnAprobaNegociere);
            Controls.Add(btnAnuleazaNegociere);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SellerForm";
            Text = "Interfață Vânzător";
            Load += SellerForm_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPret).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOferte).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPretMinim).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblBunVenit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.NumericUpDown numPret;
        private System.Windows.Forms.TextBox txtDescriere;
        private System.Windows.Forms.CheckBox chkNegociabil;
        private System.Windows.Forms.Button btnAdaugaProdus;
        private System.Windows.Forms.DataGridView dataGridViewProduse;
        private System.Windows.Forms.Button btnAnuleazaVanzare;
        private System.Windows.Forms.Button btnAprobaNegociere;
        private System.Windows.Forms.Button btnAnuleazaNegociere;
        private Panel panel1;
        private Label label2;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewOferte;
        private NumericUpDown numPretMinim;
    }
}
