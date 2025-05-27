namespace MagazinOnline
{
    partial class BuyerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyerForm));
            lblBunVenit = new Label();
            tabControl1 = new TabControl();
            tabProduse = new TabPage();
            groupBox1 = new GroupBox();
            btnCumparaNegociat = new Button();
            btnFaceOferta = new Button();
            btnCumparaDirect = new Button();
            btnActualizeaza = new Button();
            dataGridViewProduse = new DataGridView();
            lblProduse = new Label();
            tabIstoric = new TabPage();
            dataGridViewIstoric = new DataGridView();
            lblIstoric = new Label();
            panel1 = new Panel();
            label2 = new Label();
            ExitButton = new Button();
            tabControl1.SuspendLayout();
            tabProduse.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            tabIstoric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIstoric).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblBunVenit
            // 
            lblBunVenit.AutoSize = true;
            lblBunVenit.BackColor = Color.Transparent;
            lblBunVenit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBunVenit.ForeColor = Color.Magenta;
            lblBunVenit.Location = new Point(13, 65);
            lblBunVenit.Margin = new Padding(4, 0, 4, 0);
            lblBunVenit.Name = "lblBunVenit";
            lblBunVenit.Size = new Size(193, 20);
            lblBunVenit.TabIndex = 0;
            lblBunVenit.Text = "Bun venit, Cumpărător!";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabProduse);
            tabControl1.Controls.Add(tabIstoric);
            tabControl1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(13, 106);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1167, 577);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabProduse
            // 
            tabProduse.BackColor = Color.Transparent;
            tabProduse.BackgroundImage = (Image)resources.GetObject("tabProduse.BackgroundImage");
            tabProduse.Controls.Add(groupBox1);
            tabProduse.Controls.Add(btnActualizeaza);
            tabProduse.Controls.Add(dataGridViewProduse);
            tabProduse.Controls.Add(lblProduse);
            tabProduse.Location = new Point(4, 25);
            tabProduse.Margin = new Padding(4, 3, 4, 3);
            tabProduse.Name = "tabProduse";
            tabProduse.Padding = new Padding(4, 3, 4, 3);
            tabProduse.Size = new Size(1159, 548);
            tabProduse.TabIndex = 0;
            tabProduse.Text = "Produse Disponibile";
            tabProduse.Click += tabProduse_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(btnCumparaNegociat);
            groupBox1.Controls.Add(btnFaceOferta);
            groupBox1.Controls.Add(btnCumparaDirect);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Magenta;
            groupBox1.Location = new Point(23, 438);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(642, 92);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acțiuni pentru produsul selectat";
            // 
            // btnCumparaNegociat
            // 
            btnCumparaNegociat.BackColor = Color.Orange;
            btnCumparaNegociat.FlatStyle = FlatStyle.Flat;
            btnCumparaNegociat.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCumparaNegociat.ForeColor = Color.White;
            btnCumparaNegociat.Location = new Point(432, 29);
            btnCumparaNegociat.Margin = new Padding(4, 3, 4, 3);
            btnCumparaNegociat.Name = "btnCumparaNegociat";
            btnCumparaNegociat.Size = new Size(187, 46);
            btnCumparaNegociat.TabIndex = 2;
            btnCumparaNegociat.Text = "Cumpără la Preț Negociat";
            btnCumparaNegociat.UseVisualStyleBackColor = false;
            btnCumparaNegociat.Click += btnCumparaNegociat_Click;
            // 
            // btnFaceOferta
            // 
            btnFaceOferta.BackColor = Color.SteelBlue;
            btnFaceOferta.FlatStyle = FlatStyle.Flat;
            btnFaceOferta.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFaceOferta.ForeColor = Color.White;
            btnFaceOferta.Location = new Point(222, 29);
            btnFaceOferta.Margin = new Padding(4, 3, 4, 3);
            btnFaceOferta.Name = "btnFaceOferta";
            btnFaceOferta.Size = new Size(187, 46);
            btnFaceOferta.TabIndex = 1;
            btnFaceOferta.Text = "Faceți o Ofertă";
            btnFaceOferta.UseVisualStyleBackColor = false;
            btnFaceOferta.Click += btnFaceOferta_Click;
            // 
            // btnCumparaDirect
            // 
            btnCumparaDirect.BackColor = Color.ForestGreen;
            btnCumparaDirect.FlatStyle = FlatStyle.Flat;
            btnCumparaDirect.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCumparaDirect.ForeColor = Color.White;
            btnCumparaDirect.Location = new Point(23, 29);
            btnCumparaDirect.Margin = new Padding(4, 3, 4, 3);
            btnCumparaDirect.Name = "btnCumparaDirect";
            btnCumparaDirect.Size = new Size(187, 46);
            btnCumparaDirect.TabIndex = 0;
            btnCumparaDirect.Text = "Cumpără Direct";
            btnCumparaDirect.UseVisualStyleBackColor = false;
            btnCumparaDirect.Click += btnCumparaDirect_Click;
            // 
            // btnActualizeaza
            // 
            btnActualizeaza.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizeaza.BackColor = Color.DodgerBlue;
            btnActualizeaza.FlatStyle = FlatStyle.Flat;
            btnActualizeaza.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizeaza.ForeColor = Color.White;
            btnActualizeaza.Location = new Point(992, 485);
            btnActualizeaza.Margin = new Padding(4, 3, 4, 3);
            btnActualizeaza.Name = "btnActualizeaza";
            btnActualizeaza.Size = new Size(140, 46);
            btnActualizeaza.TabIndex = 3;
            btnActualizeaza.Text = "Actualizează";
            btnActualizeaza.UseVisualStyleBackColor = false;
            btnActualizeaza.Click += btnActualizeaza_Click;
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.AllowUserToAddRows = false;
            dataGridViewProduse.AllowUserToDeleteRows = false;
            dataGridViewProduse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProduse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduse.BackgroundColor = Color.White;
            dataGridViewProduse.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.Location = new Point(23, 63);
            dataGridViewProduse.Margin = new Padding(4, 3, 4, 3);
            dataGridViewProduse.MultiSelect = false;
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.ReadOnly = true;
            dataGridViewProduse.RowHeadersWidth = 25;
            dataGridViewProduse.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProduse.Size = new Size(1108, 369);
            dataGridViewProduse.TabIndex = 1;
            dataGridViewProduse.CellContentClick += dataGridViewProduse_CellContentClick;
            // 
            // lblProduse
            // 
            lblProduse.AutoSize = true;
            lblProduse.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProduse.ForeColor = Color.Magenta;
            lblProduse.Location = new Point(23, 23);
            lblProduse.Margin = new Padding(4, 0, 4, 0);
            lblProduse.Name = "lblProduse";
            lblProduse.Size = new Size(161, 18);
            lblProduse.TabIndex = 0;
            lblProduse.Text = "Produse disponibile:";
            lblProduse.Click += lblProduse_Click;
            // 
            // tabIstoric
            // 
            tabIstoric.BackColor = Color.WhiteSmoke;
            tabIstoric.Controls.Add(dataGridViewIstoric);
            tabIstoric.Controls.Add(lblIstoric);
            tabIstoric.Location = new Point(4, 25);
            tabIstoric.Margin = new Padding(4, 3, 4, 3);
            tabIstoric.Name = "tabIstoric";
            tabIstoric.Padding = new Padding(4, 3, 4, 3);
            tabIstoric.Size = new Size(1159, 548);
            tabIstoric.TabIndex = 1;
            tabIstoric.Text = "Istoric Cumpărări";
            // 
            // dataGridViewIstoric
            // 
            dataGridViewIstoric.AllowUserToAddRows = false;
            dataGridViewIstoric.AllowUserToDeleteRows = false;
            dataGridViewIstoric.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewIstoric.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIstoric.BackgroundColor = Color.White;
            dataGridViewIstoric.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewIstoric.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIstoric.Location = new Point(23, 58);
            dataGridViewIstoric.Margin = new Padding(4, 3, 4, 3);
            dataGridViewIstoric.MultiSelect = false;
            dataGridViewIstoric.Name = "dataGridViewIstoric";
            dataGridViewIstoric.ReadOnly = true;
            dataGridViewIstoric.RowHeadersWidth = 25;
            dataGridViewIstoric.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIstoric.Size = new Size(1108, 462);
            dataGridViewIstoric.TabIndex = 1;
            dataGridViewIstoric.CellContentClick += dataGridViewIstoric_CellContentClick;
            // 
            // lblIstoric
            // 
            lblIstoric.AutoSize = true;
            lblIstoric.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIstoric.ForeColor = Color.DarkSlateGray;
            lblIstoric.Location = new Point(23, 23);
            lblIstoric.Margin = new Padding(4, 0, 4, 0);
            lblIstoric.Name = "lblIstoric";
            lblIstoric.Size = new Size(214, 18);
            lblIstoric.TabIndex = 0;
            lblIstoric.Text = "Istoric cumpărări efectuate:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 18, 18);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ExitButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1195, 37);
            panel1.TabIndex = 3;
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
            // ExitButton
            // 
            ExitButton.BackgroundImage = (Image)resources.GetObject("ExitButton.BackgroundImage");
            ExitButton.BackgroundImageLayout = ImageLayout.Zoom;
            ExitButton.Dock = DockStyle.Right;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.ForeColor = Color.Transparent;
            ExitButton.Location = new Point(1158, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(37, 37);
            ExitButton.TabIndex = 0;
            ExitButton.Tag = "ExitButton";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // BuyerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1195, 706);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(lblBunVenit);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 686);
            Name = "BuyerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Magazin Online - Panou Cumpărător";
            Load += BuyerForm_Load;
            tabControl1.ResumeLayout(false);
            tabProduse.ResumeLayout(false);
            tabProduse.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            tabIstoric.ResumeLayout(false);
            tabIstoric.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIstoric).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBunVenit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProduse;
        private System.Windows.Forms.TabPage tabIstoric;
        private System.Windows.Forms.DataGridView dataGridViewProduse;
        private System.Windows.Forms.DataGridView dataGridViewIstoric;
        private System.Windows.Forms.Button btnCumparaDirect;
        private System.Windows.Forms.Button btnFaceOferta;
        private System.Windows.Forms.Button btnCumparaNegociat;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Label lblProduse;
        private System.Windows.Forms.Label lblIstoric;
        private System.Windows.Forms.GroupBox groupBox1;
        private Panel panel1;
        private Label label2;
        private Button ExitButton;
    }
}