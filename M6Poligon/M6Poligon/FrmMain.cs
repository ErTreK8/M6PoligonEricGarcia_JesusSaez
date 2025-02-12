using CLASSES;
using M6Poligon.CLASSES;
using M6Poligon.FORMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace M6Poligon
{
    public partial class FrmMain : Form
    {
        String cadenaConnexio = @"Data Source=PORTATIL-ERIC;Initial Catalog=bdPoligons;Integrated Security=True;MultipleActiveResultSets=True";
        ClBDSqlServer bd;
        DataSet dset;
        Boolean tots = true;
        ClQuadrat quadrats { get; set; }
        ClRectangle rectangles { get; set; }
        ClPentagono pentagons { get; set; }
        ClRombo rombos { get; set; }
        ClTriangleIsosceles trianglesIsosceles { get; set; }
        ClTriangleRectangle trianglesRectangles { get; set; }
        ClCercle cercles { get; set; }
        ClElipse elipses { get; set; }
        ClHexagono hexagons { get; set; } 
        ClOctogono octogons { get; set; }

        int idPoligon;
        int mida;
        int altura;
        int ancho;
        Color color;


        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bd = new ClBDSqlServer(cadenaConnexio);
            dset = new DataSet();
            if (bd.Connectar())
            {
                cbGrup.SelectedIndex = 0;
                getDades();
                customDgrid();
            }
            else
            {
                MessageBox.Show("No em puc connectar a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void getDades()
        {
            String xsql = "";

            if (tots)
            {
                xsql = "SELECT * from tbPoligon;";
            }
            else
            {
                xsql = $"SELECT p.* from tbPoligon p RIGHT join tb{cbGrup.SelectedItem.ToString().Replace(" ", "")} t on t.idPoligon=p.idPoligon ORDER BY nombre";
            }

            
            bd.Consulta(xsql,ref dset);
            dgPoligons.DataSource = dset.Tables[0];
            //omplirLlistes();

        }

        private void cbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrup.SelectedItem.ToString() != "Tots")
            {
                tots = false;
            }
            else tots = true;
            getDades();
        }

        private void customDgrid()
        {
            dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgPoligons.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPoligons.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgPoligons.Columns["idPoligon"].Visible = false;
            dgPoligons.Columns["nombre"].HeaderText = "nom";
            dgPoligons.Columns["color"].HeaderText = "color";
            dgPoligons.Columns["color"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgPoligons.Columns["forma"].HeaderText = "forma";
            dgPoligons.Columns["forma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgPoligons.Columns["ple"].HeaderText = "ple";

        }

        private void dgPoligons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPoligons.SelectedRows.Count > 0)
            {
                mostrarDades();
                mostrarPoligon();
            }
        }

        private void mostrarDades()
        {
            object p;
            idPoligon = (int)dgPoligons.SelectedRows[0].Cells["idPoligon"].Value;
            string colorHex = dgPoligons.SelectedRows[0].Cells["color"].Value.ToString().Trim();

            // Si no tiene '#', lo añadimos
            if (!colorHex.StartsWith("#"))
            {
                colorHex = "#" + colorHex;
            }
            color = ColorTranslator.FromHtml(colorHex);
            switch (dgPoligons.SelectedRows[0].Cells["forma"].Value.ToString())
            {
                case "Quadrat":
                    p = new ClQuadrat(bd, idPoligon, ref mida);
                    break;
                case "Rectangle":
                    p = new ClRectangle(bd, idPoligon, ref altura, ref ancho);
                    break;
                case "Cercle":
                    p = new ClCercle(bd, idPoligon, ref mida);
                    break;
                case "Elipse":
                    p = new ClElipse(bd, idPoligon, ref altura, ref ancho);
                    break;
                case "Triangle rectangle":
                    p = new ClTriangleRectangle(bd, idPoligon, ref altura, ref ancho);
                    break;
                case "Triangle isosceles":
                    p = new ClTriangleIsosceles(bd, idPoligon, ref altura, ref ancho);
                    break;
                case "Rombe":
                    p = new ClRombo(bd, idPoligon, ref altura, ref ancho);
                    break;
                case "Pentagon":
                    p = new ClPentagono(bd, idPoligon, ref mida);
                    break;
                case "Hexagon":
                    p = new ClHexagono(bd, idPoligon, ref mida);
                    break;
                case "Octagon":
                    p = new ClOctogono(bd, idPoligon, ref mida);
                    break;
            }
        }

        private void mostrarPoligon()
        {
            try
            {
                pnlFormas.Controls.Clear();
                quadrats = null;
                rectangles = null;
                cercles = null;
                elipses = null;
                trianglesRectangles = null;
                trianglesIsosceles = null;
                hexagons = null;
                pentagons = null;
                octogons = null;
                rombos = null;

                if ((bool)dgPoligons.SelectedRows[0].Cells["ple"].Value == true)
                {
                    switch (dgPoligons.SelectedRows[0].Cells["forma"].Value.ToString())
                    {
                        case "Quadrat":
                            quadrats = new ClQuadrat(pnlFormas, color,mida);
                            lbPerimetro.Text = "Perimetro: " + quadrats.Perimetre().ToString();
                            lbArea.Text = "Area: " + quadrats.Area().ToString();
                            break;
                        case "Rectangle":
                            rectangles = new ClRectangle(pnlFormas,color, altura, ancho);
                            lbPerimetro.Text = "Perimetro: " + rectangles.Perimetre().ToString();
                            lbArea.Text = "Area: " + rectangles.Area().ToString();
                            break;
                        case "Cercle":
                            cercles = new ClCercle(pnlFormas, color, mida);
                            lbPerimetro.Text = "Perimetro: " + cercles.Perimetre().ToString();
                            lbArea.Text = "Area: " + cercles.Area().ToString();
                            break;
                        case "Elipse":
                            elipses = new ClElipse(pnlFormas, color, altura, ancho);
                            lbPerimetro.Text = "Perimetro: " + elipses.Perimetre().ToString();
                            lbArea.Text = "Area: " + elipses.Area().ToString();
                            break;
                        case "Triangle rectangle":
                            trianglesRectangles = new ClTriangleRectangle(pnlFormas, color, altura, ancho);
                            lbPerimetro.Text = "Perimetro: " + trianglesRectangles.Perimetre().ToString();
                            lbArea.Text = "Area: " + trianglesRectangles.Area().ToString();
                            break;
                        case "Triangle isosceles":
                            trianglesIsosceles = new ClTriangleIsosceles(pnlFormas, color, altura, ancho);
                            lbPerimetro.Text = "Perimetro: " + trianglesIsosceles.Perimetre().ToString();
                            lbArea.Text = "Area: " + trianglesIsosceles.Area().ToString();
                            break;
                        case "Rombe":
                            rombos = new ClRombo(pnlFormas, color, altura, ancho);
                            lbPerimetro.Text = "Perimetro: " + rombos.Perimetre().ToString();
                            lbArea.Text = "Area: " + rombos.Area().ToString();
                            break;
                        case "Pentagon":
                            pentagons = new ClPentagono(pnlFormas, color, mida);
                            lbPerimetro.Text = "Perimetro: " + pentagons.Perimetre().ToString();
                            lbArea.Text = "Area: " + pentagons.Area().ToString();
                            break;
                        case "Hexagon":
                            hexagons = new ClHexagono(pnlFormas, color, mida);
                            lbPerimetro.Text = "Perimetro: " + hexagons.Perimetre().ToString();
                            lbArea.Text = "Area: " + hexagons.Area().ToString();
                            break;
                        case "Octagon":
                            octogons = new ClOctogono(pnlFormas, color, mida);
                            lbPerimetro.Text = "Perimetro: " + octogons.Perimetre().ToString();
                            lbArea.Text = "Area: " + octogons.Area().ToString();
                            break;
                    }
                }
                else
                {
                    switch (dgPoligons.SelectedRows[0].Cells["forma"].Value.ToString())
                    {
                        case "Quadrat":
                            quadrats = new ClQuadrat(pnlFormas, mida);
                            break;
                        case "Rectangle":
                            rectangles = new ClRectangle(pnlFormas, altura, ancho);
                            break;
                        case "Cercle":
                            cercles = new ClCercle(pnlFormas, mida);
                            break;
                        case "Elipse":
                            elipses = new ClElipse(pnlFormas, altura, ancho);
                            break;
                        case "Triangle rectangle":
                            trianglesRectangles = new ClTriangleRectangle(pnlFormas, altura, ancho);
                            break;
                        case "Triangle isosceles":
                            trianglesIsosceles = new ClTriangleIsosceles(pnlFormas, altura, ancho);
                            break;
                        case "Rombe":
                            rombos = new ClRombo(pnlFormas, altura, ancho);
                            break;
                        case "Pentagon":
                            pentagons = new ClPentagono(pnlFormas, mida);
                            break;
                        case "Hexagon":
                            hexagons = new ClHexagono(pnlFormas, mida);
                            break;
                        case "Octagon":
                            octogons = new ClOctogono(pnlFormas, mida);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString() + "," + dgPoligons.SelectedRows[0].Cells["y"].Value.ToString());
            }
            
        }
        

        private void btDel_Click(object sender, EventArgs e)
        {
            String xsql = "";

            if (dgPoligons.SelectedRows[0] != null)
            {
                if (MessageBox.Show($"Segur que vols eliminar el {dgPoligons.SelectedRows[0].Cells["forma"].Value} amb idPoligon {dgPoligons.SelectedRows[0].Cells["idPoligon"].Value}", "ELIMINAR", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    xsql = $"DELETE FROM tbPoligon WHERE idPoligon={dgPoligons.SelectedRows[0].Cells["idPoligon"].Value}";
                    bd.executarOrdre(xsql);
                    getDades();
                }
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            FrmAdd fAdd = new FrmAdd(bd);

            fAdd.ShowDialog();
            fAdd.Dispose();
            fAdd = null;
            getDades();
        }
    }
}
