namespace MagazinOnline
{
    partial class AdminForm1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm1));
            panel1 = new Panel();
            label2 = new Label();
            ExitButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            dataGridViewVanzatori = new DataGridView();
            tabPage2 = new TabPage();
            button4 = new Button();
            dataGridViewProduse = new DataGridView();
            sellerBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVanzatori).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sellerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 18, 18);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ExitButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(953, 37);
            panel1.TabIndex = 2;
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
            ExitButton.Location = new Point(916, 0);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(37, 37);
            ExitButton.TabIndex = 0;
            ExitButton.Tag = "ExitButton";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(236, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(508, 513);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImage = (Image)resources.GetObject("tabPage1.BackgroundImage");
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(dataGridViewVanzatori);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(500, 485);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPageVanzatori";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(352, 446);
            button1.Name = "button1";
            button1.Size = new Size(96, 23);
            button1.TabIndex = 3;
            button1.Text = "Activeaza";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(193, 446);
            button3.Name = "button3";
            button3.Size = new Size(101, 23);
            button3.TabIndex = 2;
            button3.Text = "Dezactiveaza";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(43, 446);
            button2.Name = "button2";
            button2.Size = new Size(101, 23);
            button2.TabIndex = 1;
            button2.Text = "Aproba";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridViewVanzatori
            // 
            dataGridViewVanzatori.BackgroundColor = Color.DarkGray;
            dataGridViewVanzatori.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVanzatori.Location = new Point(-4, 0);
            dataGridViewVanzatori.Name = "dataGridViewVanzatori";
            dataGridViewVanzatori.Size = new Size(504, 426);
            dataGridViewVanzatori.TabIndex = 0;
            dataGridViewVanzatori.CellContentClick += dataGridViewVanzatori_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(dataGridViewProduse);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(500, 485);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPageProduse";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(24, 442);
            button4.Name = "button4";
            button4.Size = new Size(101, 23);
            button4.TabIndex = 3;
            button4.Text = "Sterge Produs";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridViewProduse
            // 
            dataGridViewProduse.BackgroundColor = Color.DarkGray;
            dataGridViewProduse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduse.Location = new Point(-4, 0);
            dataGridViewProduse.Name = "dataGridViewProduse";
            dataGridViewProduse.Size = new Size(504, 427);
            dataGridViewProduse.TabIndex = 0;
            dataGridViewProduse.CellContentClick += dataGridViewProduse_CellContentClick;
            // 
            // sellerBindingSource
            // 
            sellerBindingSource.DataSource = typeof(Clase.Seller);
            // 
            // AdminForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(953, 616);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminForm1";
            Text = "AdminForm1";
            Load += AdminForm1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewVanzatori).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduse).EndInit();
            ((System.ComponentModel.ISupportInitialize)sellerBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Button ExitButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button3;
        private Button button2;
        private DataGridView dataGridViewVanzatori;
        private TabPage tabPage2;
        private Button button4;
        private DataGridView dataGridViewProduse;
        private BindingSource sellerBindingSource;
        private Button button1;
    }
}