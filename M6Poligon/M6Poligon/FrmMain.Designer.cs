namespace M6Poligon
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbGrup = new System.Windows.Forms.Label();
            this.cbGrup = new System.Windows.Forms.ComboBox();
            this.dgPoligons = new System.Windows.Forms.DataGridView();
            this.lbPersonatges = new System.Windows.Forms.Label();
            this.pnlFormas = new System.Windows.Forms.Panel();
            this.btDel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbPerimetro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPoligons)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.Color.LightGray;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Location = new System.Drawing.Point(554, 62);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Padding = new System.Windows.Forms.Padding(3);
            this.lbInfo.Size = new System.Drawing.Size(745, 25);
            this.lbInfo.TabIndex = 12;
            this.lbInfo.Text = "Poligon";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbGrup
            // 
            this.lbGrup.BackColor = System.Drawing.Color.LightGray;
            this.lbGrup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGrup.Location = new System.Drawing.Point(12, 21);
            this.lbGrup.Name = "lbGrup";
            this.lbGrup.Padding = new System.Windows.Forms.Padding(3);
            this.lbGrup.Size = new System.Drawing.Size(124, 25);
            this.lbGrup.TabIndex = 11;
            this.lbGrup.Text = "Tria un grup";
            this.lbGrup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbGrup
            // 
            this.cbGrup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrup.FormattingEnabled = true;
            this.cbGrup.Items.AddRange(new object[] {
            "Tots",
            "Cercle",
            "Elipse",
            "Hexagon",
            "Octagon",
            "Pentagon",
            "Quadrat",
            "Rectangle",
            "Rombe",
            "Triangle isosceles",
            "Triangle rectangle"});
            this.cbGrup.Location = new System.Drawing.Point(142, 21);
            this.cbGrup.Name = "cbGrup";
            this.cbGrup.Size = new System.Drawing.Size(343, 24);
            this.cbGrup.TabIndex = 10;
            this.cbGrup.SelectedIndexChanged += new System.EventHandler(this.cbGrup_SelectedIndexChanged);
            // 
            // dgPoligons
            // 
            this.dgPoligons.AllowUserToAddRows = false;
            this.dgPoligons.AllowUserToDeleteRows = false;
            this.dgPoligons.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgPoligons.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPoligons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPoligons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPoligons.Location = new System.Drawing.Point(12, 90);
            this.dgPoligons.MultiSelect = false;
            this.dgPoligons.Name = "dgPoligons";
            this.dgPoligons.ReadOnly = true;
            this.dgPoligons.RowHeadersVisible = false;
            this.dgPoligons.RowHeadersWidth = 51;
            this.dgPoligons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPoligons.Size = new System.Drawing.Size(535, 644);
            this.dgPoligons.TabIndex = 9;
            this.dgPoligons.SelectionChanged += new System.EventHandler(this.dgPoligons_SelectionChanged);
            // 
            // lbPersonatges
            // 
            this.lbPersonatges.BackColor = System.Drawing.Color.LightGray;
            this.lbPersonatges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPersonatges.Location = new System.Drawing.Point(12, 62);
            this.lbPersonatges.Name = "lbPersonatges";
            this.lbPersonatges.Padding = new System.Windows.Forms.Padding(3);
            this.lbPersonatges.Size = new System.Drawing.Size(535, 25);
            this.lbPersonatges.TabIndex = 8;
            this.lbPersonatges.Text = "Poligons";
            this.lbPersonatges.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFormas
            // 
            this.pnlFormas.Location = new System.Drawing.Point(568, 105);
            this.pnlFormas.Name = "pnlFormas";
            this.pnlFormas.Size = new System.Drawing.Size(731, 533);
            this.pnlFormas.TabIndex = 13;
            // 
            // btDel
            // 
            this.btDel.BackColor = System.Drawing.Color.Crimson;
            this.btDel.Location = new System.Drawing.Point(861, 644);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(122, 35);
            this.btDel.TabIndex = 15;
            this.btDel.Text = "DELETE";
            this.btDel.UseVisualStyleBackColor = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.LightGreen;
            this.btOK.Location = new System.Drawing.Point(645, 644);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(122, 35);
            this.btOK.TabIndex = 14;
            this.btOK.Text = "ADD";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArea.Location = new System.Drawing.Point(564, 693);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(58, 22);
            this.lbArea.TabIndex = 16;
            this.lbArea.Text = "Area: ";
            // 
            // lbPerimetro
            // 
            this.lbPerimetro.AutoSize = true;
            this.lbPerimetro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPerimetro.Location = new System.Drawing.Point(1000, 693);
            this.lbPerimetro.Name = "lbPerimetro";
            this.lbPerimetro.Size = new System.Drawing.Size(97, 22);
            this.lbPerimetro.TabIndex = 17;
            this.lbPerimetro.Text = "Perimetro: ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 745);
            this.Controls.Add(this.lbPerimetro);
            this.Controls.Add(this.lbArea);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.pnlFormas);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbGrup);
            this.Controls.Add(this.cbGrup);
            this.Controls.Add(this.dgPoligons);
            this.Controls.Add(this.lbPersonatges);
            this.Name = "FrmMain";
            this.Text = "Poligons";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPoligons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbGrup;
        private System.Windows.Forms.ComboBox cbGrup;
        private System.Windows.Forms.DataGridView dgPoligons;
        private System.Windows.Forms.Label lbPersonatges;
        private System.Windows.Forms.Panel pnlFormas;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbPerimetro;
    }
}

