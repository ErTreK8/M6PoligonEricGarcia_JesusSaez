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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbGrup = new System.Windows.Forms.Label();
            this.cbGrup = new System.Windows.Forms.ComboBox();
            this.dgPersonatges = new System.Windows.Forms.DataGridView();
            this.lbPersonatges = new System.Windows.Forms.Label();
            this.pnlFormas = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonatges)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInfo
            // 
            this.lbInfo.BackColor = System.Drawing.Color.LightGray;
            this.lbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInfo.Location = new System.Drawing.Point(554, 62);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Padding = new System.Windows.Forms.Padding(3);
            this.lbInfo.Size = new System.Drawing.Size(513, 25);
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
            // dgPersonatges
            // 
            this.dgPersonatges.AllowUserToAddRows = false;
            this.dgPersonatges.AllowUserToDeleteRows = false;
            this.dgPersonatges.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgPersonatges.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPersonatges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgPersonatges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonatges.Location = new System.Drawing.Point(12, 90);
            this.dgPersonatges.MultiSelect = false;
            this.dgPersonatges.Name = "dgPersonatges";
            this.dgPersonatges.ReadOnly = true;
            this.dgPersonatges.RowHeadersVisible = false;
            this.dgPersonatges.RowHeadersWidth = 51;
            this.dgPersonatges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonatges.Size = new System.Drawing.Size(535, 644);
            this.dgPersonatges.TabIndex = 9;
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
            this.pnlFormas.Size = new System.Drawing.Size(499, 401);
            this.pnlFormas.TabIndex = 13;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 745);
            this.Controls.Add(this.pnlFormas);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbGrup);
            this.Controls.Add(this.cbGrup);
            this.Controls.Add(this.dgPersonatges);
            this.Controls.Add(this.lbPersonatges);
            this.Name = "FrmMain";
            this.Text = "Poligons";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonatges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbGrup;
        private System.Windows.Forms.ComboBox cbGrup;
        private System.Windows.Forms.DataGridView dgPersonatges;
        private System.Windows.Forms.Label lbPersonatges;
        private System.Windows.Forms.Panel pnlFormas;
    }
}

