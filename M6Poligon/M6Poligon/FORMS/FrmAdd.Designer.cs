namespace M6Poligon.FORMS
{
    partial class FrmAdd
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAlcada = new System.Windows.Forms.Label();
            this.lbAmplada = new System.Windows.Forms.Label();
            this.lbNom = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.chkPle = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cdColorPol = new System.Windows.Forms.ColorDialog();
            this.gbGrup = new System.Windows.Forms.GroupBox();
            this.rdOcto = new System.Windows.Forms.RadioButton();
            this.rdHexa = new System.Windows.Forms.RadioButton();
            this.rdPent = new System.Windows.Forms.RadioButton();
            this.rdRombes = new System.Windows.Forms.RadioButton();
            this.rdIsosceles = new System.Windows.Forms.RadioButton();
            this.rdTriangleRect = new System.Windows.Forms.RadioButton();
            this.rdQuadrat = new System.Windows.Forms.RadioButton();
            this.rdRect = new System.Windows.Forms.RadioButton();
            this.rdElipse = new System.Windows.Forms.RadioButton();
            this.rdCercle = new System.Windows.Forms.RadioButton();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbGrup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAlcada);
            this.groupBox1.Controls.Add(this.lbAmplada);
            this.groupBox1.Controls.Add(this.lbNom);
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.chkPle);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(23, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 178);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caracteristiques";
            // 
            // lbAlcada
            // 
            this.lbAlcada.AutoSize = true;
            this.lbAlcada.Location = new System.Drawing.Point(46, 127);
            this.lbAlcada.Name = "lbAlcada";
            this.lbAlcada.Size = new System.Drawing.Size(53, 16);
            this.lbAlcada.TabIndex = 6;
            this.lbAlcada.Text = "Alçada:";
            // 
            // lbAmplada
            // 
            this.lbAmplada.AutoSize = true;
            this.lbAmplada.Location = new System.Drawing.Point(37, 83);
            this.lbAmplada.Name = "lbAmplada";
            this.lbAmplada.Size = new System.Drawing.Size(65, 16);
            this.lbAmplada.TabIndex = 5;
            this.lbAmplada.Text = "Amplada:";
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Location = new System.Drawing.Point(60, 43);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(39, 16);
            this.lbNom.TabIndex = 4;
            this.lbNom.Text = "Nom:";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(114, 37);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(140, 22);
            this.tbNom.TabIndex = 3;
            // 
            // chkPle
            // 
            this.chkPle.AutoSize = true;
            this.chkPle.Location = new System.Drawing.Point(302, 83);
            this.chkPle.Name = "chkPle";
            this.chkPle.Size = new System.Drawing.Size(49, 20);
            this.chkPle.TabIndex = 2;
            this.chkPle.Text = "Ple";
            this.chkPle.UseVisualStyleBackColor = true;
            this.chkPle.CheckedChanged += new System.EventHandler(this.chkPle_CheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(114, 121);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(140, 22);
            this.numericUpDown2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(114, 81);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(140, 22);
            this.numericUpDown1.TabIndex = 0;
            // 
            // gbGrup
            // 
            this.gbGrup.Controls.Add(this.rdOcto);
            this.gbGrup.Controls.Add(this.rdHexa);
            this.gbGrup.Controls.Add(this.rdPent);
            this.gbGrup.Controls.Add(this.rdRombes);
            this.gbGrup.Controls.Add(this.rdIsosceles);
            this.gbGrup.Controls.Add(this.rdTriangleRect);
            this.gbGrup.Controls.Add(this.rdQuadrat);
            this.gbGrup.Controls.Add(this.rdRect);
            this.gbGrup.Controls.Add(this.rdElipse);
            this.gbGrup.Controls.Add(this.rdCercle);
            this.gbGrup.Location = new System.Drawing.Point(23, 13);
            this.gbGrup.Margin = new System.Windows.Forms.Padding(4);
            this.gbGrup.Name = "gbGrup";
            this.gbGrup.Padding = new System.Windows.Forms.Padding(4);
            this.gbGrup.Size = new System.Drawing.Size(449, 237);
            this.gbGrup.TabIndex = 4;
            this.gbGrup.TabStop = false;
            this.gbGrup.Text = " Tria un poligon";
            // 
            // rdOcto
            // 
            this.rdOcto.AutoSize = true;
            this.rdOcto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdOcto.Location = new System.Drawing.Point(302, 196);
            this.rdOcto.Margin = new System.Windows.Forms.Padding(4);
            this.rdOcto.Name = "rdOcto";
            this.rdOcto.Size = new System.Drawing.Size(86, 20);
            this.rdOcto.TabIndex = 9;
            this.rdOcto.Text = "Octògons";
            this.rdOcto.UseVisualStyleBackColor = true;
            this.rdOcto.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdHexa
            // 
            this.rdHexa.AutoSize = true;
            this.rdHexa.Location = new System.Drawing.Point(302, 156);
            this.rdHexa.Margin = new System.Windows.Forms.Padding(4);
            this.rdHexa.Name = "rdHexa";
            this.rdHexa.Size = new System.Drawing.Size(90, 20);
            this.rdHexa.TabIndex = 8;
            this.rdHexa.Text = "Hexàgons";
            this.rdHexa.UseVisualStyleBackColor = true;
            this.rdHexa.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdPent
            // 
            this.rdPent.AutoSize = true;
            this.rdPent.Location = new System.Drawing.Point(302, 117);
            this.rdPent.Margin = new System.Windows.Forms.Padding(4);
            this.rdPent.Name = "rdPent";
            this.rdPent.Size = new System.Drawing.Size(93, 20);
            this.rdPent.TabIndex = 7;
            this.rdPent.Text = "Pentàgons";
            this.rdPent.UseVisualStyleBackColor = true;
            this.rdPent.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdRombes
            // 
            this.rdRombes.AutoSize = true;
            this.rdRombes.Location = new System.Drawing.Point(302, 79);
            this.rdRombes.Margin = new System.Windows.Forms.Padding(4);
            this.rdRombes.Name = "rdRombes";
            this.rdRombes.Size = new System.Drawing.Size(80, 20);
            this.rdRombes.TabIndex = 6;
            this.rdRombes.Text = "Rombes";
            this.rdRombes.UseVisualStyleBackColor = true;
            this.rdRombes.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdIsosceles
            // 
            this.rdIsosceles.AutoSize = true;
            this.rdIsosceles.Location = new System.Drawing.Point(302, 42);
            this.rdIsosceles.Margin = new System.Windows.Forms.Padding(4);
            this.rdIsosceles.Name = "rdIsosceles";
            this.rdIsosceles.Size = new System.Drawing.Size(139, 20);
            this.rdIsosceles.TabIndex = 5;
            this.rdIsosceles.Text = "Triangle Isosceles";
            this.rdIsosceles.UseVisualStyleBackColor = true;
            this.rdIsosceles.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdTriangleRect
            // 
            this.rdTriangleRect.AutoSize = true;
            this.rdTriangleRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rdTriangleRect.Location = new System.Drawing.Point(29, 196);
            this.rdTriangleRect.Margin = new System.Windows.Forms.Padding(4);
            this.rdTriangleRect.Name = "rdTriangleRect";
            this.rdTriangleRect.Size = new System.Drawing.Size(143, 20);
            this.rdTriangleRect.TabIndex = 4;
            this.rdTriangleRect.Text = "Triangle Rectangle";
            this.rdTriangleRect.UseVisualStyleBackColor = true;
            this.rdTriangleRect.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdQuadrat
            // 
            this.rdQuadrat.AutoSize = true;
            this.rdQuadrat.Location = new System.Drawing.Point(29, 156);
            this.rdQuadrat.Margin = new System.Windows.Forms.Padding(4);
            this.rdQuadrat.Name = "rdQuadrat";
            this.rdQuadrat.Size = new System.Drawing.Size(76, 20);
            this.rdQuadrat.TabIndex = 3;
            this.rdQuadrat.Text = "Quadrat";
            this.rdQuadrat.UseVisualStyleBackColor = true;
            this.rdQuadrat.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdRect
            // 
            this.rdRect.AutoSize = true;
            this.rdRect.Location = new System.Drawing.Point(29, 117);
            this.rdRect.Margin = new System.Windows.Forms.Padding(4);
            this.rdRect.Name = "rdRect";
            this.rdRect.Size = new System.Drawing.Size(90, 20);
            this.rdRect.TabIndex = 2;
            this.rdRect.Tag = "";
            this.rdRect.Text = "Rectangle";
            this.rdRect.UseVisualStyleBackColor = true;
            this.rdRect.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdElipse
            // 
            this.rdElipse.AutoSize = true;
            this.rdElipse.Location = new System.Drawing.Point(29, 79);
            this.rdElipse.Margin = new System.Windows.Forms.Padding(4);
            this.rdElipse.Name = "rdElipse";
            this.rdElipse.Size = new System.Drawing.Size(66, 20);
            this.rdElipse.TabIndex = 1;
            this.rdElipse.Tag = "";
            this.rdElipse.Text = "Elipse";
            this.rdElipse.UseVisualStyleBackColor = true;
            this.rdElipse.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // rdCercle
            // 
            this.rdCercle.AutoSize = true;
            this.rdCercle.Checked = true;
            this.rdCercle.Location = new System.Drawing.Point(29, 42);
            this.rdCercle.Margin = new System.Windows.Forms.Padding(4);
            this.rdCercle.Name = "rdCercle";
            this.rdCercle.Size = new System.Drawing.Size(67, 20);
            this.rdCercle.TabIndex = 0;
            this.rdCercle.TabStop = true;
            this.rdCercle.Tag = "";
            this.rdCercle.Text = "Cercle";
            this.rdCercle.UseVisualStyleBackColor = true;
            this.rdCercle.CheckedChanged += new System.EventHandler(this.rdCercle_CheckedChanged);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.LightGreen;
            this.btOK.Location = new System.Drawing.Point(73, 451);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(122, 35);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "ADD";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.Crimson;
            this.btCancel.Location = new System.Drawing.Point(289, 451);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(122, 35);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "CANCEL";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FrmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 498);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbGrup);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAdd";
            this.Text = "FrmAdd";
            this.Load += new System.EventHandler(this.FrmAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbGrup.ResumeLayout(false);
            this.gbGrup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ColorDialog cdColorPol;
        private System.Windows.Forms.CheckBox chkPle;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.GroupBox gbGrup;
        private System.Windows.Forms.RadioButton rdOcto;
        private System.Windows.Forms.RadioButton rdHexa;
        private System.Windows.Forms.RadioButton rdPent;
        private System.Windows.Forms.RadioButton rdRombes;
        private System.Windows.Forms.RadioButton rdIsosceles;
        private System.Windows.Forms.RadioButton rdTriangleRect;
        private System.Windows.Forms.RadioButton rdQuadrat;
        private System.Windows.Forms.RadioButton rdRect;
        private System.Windows.Forms.RadioButton rdElipse;
        private System.Windows.Forms.RadioButton rdCercle;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbAlcada;
        private System.Windows.Forms.Label lbAmplada;
    }
}