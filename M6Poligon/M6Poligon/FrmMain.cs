using CLASSES;
using M6Poligon.CLASSES;
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
        String cadenaConnexio = @"Data Source=localhost;Initial Catalog=bdPoligons;Integrated Security=True";
        ClBDSqlServer bd;
        DataSet dset;
        Boolean tots = true;
        List<ClPoligon> llPoligons { get; set; } = new List<ClPoligon>();
        List<ClQuadrat> llQuadrats { get; set; } = new List<ClQuadrat>();
        List<ClRectangle> llRectangles { get; set; } = new List<ClRectangle>();
        List<ClPentagono> llPentagons { get; set; } = new List<ClPentagono>();
        List<ClRombo> llRombos { get; set; } = new List<ClRombo>();
        List<ClTriangleIsosceles> llTrianglesIsosceles { get; set; } = new List<ClTriangleIsosceles>();
        List<ClTriangleRectangle> llTrianglesRectangles { get; set; } = new List<ClTriangleRectangle>();
        List<ClCercle> llCercles { get; set; } = new List<ClCercle>();
        List<ClElipse> llElipses { get; set; } = new List<ClElipse>();
        List<ClHexagono> llHexagons { get; set; } = new List<ClHexagono>();
        List<ClOctogono> llOctogons { get; set; } = new List<ClOctogono>();
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
                xsql = "SELECT p.*, q.mida, r.x, r.y FROM tbPoligon p LEFT JOIN tbQuadrat q ON q.idPoligon = p.idPoligon LEFT JOIN tbRectangle r ON r.idPoligon = p.idPoligon ORDER BY p.nombre;";
            }
            else
            {
                xsql = $"SELECT p.* from tbPoligon p inner join tb{cbGrup.SelectedItem.ToString().Replace(" ", "")} t on t.idPoligon=p.idPoligon ORDER BY nombre";
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
            dgPoligons.Columns["mida"].Visible = false;
            dgPoligons.Columns["x"].Visible = false;
            dgPoligons.Columns["y"].Visible = false;

        }

        private void dgPoligons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPoligons.SelectedRows.Count > 0)
            {
                //mostrarDades(dgPoligons.SelectedRows[0].Index);
                mostrarPoligon();
            }
        }

        private void mostrarPoligon()
        {
            object p = null;
            switch (dgPoligons.SelectedRows[0].Cells["forma"].Value.ToString())
            {
                case "Quadrat":
                    p = new ClQuadrat(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["mida"].Value.ToString()));
                    break;
                case "Rectangle":
                    p = new ClRectangle(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["y"].Value.ToString()), int.Parse(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString()));
                    break;
                case "Cercle":
                    p = new ClCercle(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["mida"].Value.ToString()));
                    break;
                case "Elipse":
                    p = new ClElipse(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["y"].Value.ToString()), int.Parse(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString()));
                    break;
                case "Triangle rectangle":
                    p = new ClTriangleRectangle(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["y"].Value.ToString()), int.Parse(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString()));
                    break;
                case "Triangle isosceles":
                    p = new ClTriangleIsosceles(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["y"].Value.ToString()), int.Parse(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString()));
                    break;
                case "Rombe":
                    p = new ClRombo(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["y"].Value.ToString()), int.Parse(dgPoligons.SelectedRows[0].Cells["x"].Value.ToString()));
                    break;
                case "Pentagon":
                    p = new ClPentagono(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["mida"].Value.ToString()));
                    break;
                case "Hexagon":
                    p = new ClHexagono(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["mida"].Value.ToString()));
                    break;
                case "Octagon":
                    p = new ClOctogono(pnlFormas, int.Parse(dgPoligons.SelectedRows[0].Cells["mida"].Value.ToString()));
                    break;
            }
        }

        //private void omplirLlistes()
        //{
        //    // generem una instància per a cada fila del DataGridView i les posem a les llistes corresponents
        //    int id;
        //    ClPoligon p = null;

        //    //iniLlistes();
        //    foreach (DataGridViewRow fila in dgPoligons.Rows)
        //    {

        //        id = (int)fila.Cells["idPoligon"].Value;
        //        switch (fila.Cells["forma"].Value.ToString())
        //        {
        //            case "Quadrat":
        //                p = new ClQuadrat(bd, id);
        //                llQuadrats.Add((ClQuadrat)p);
        //                break;
        //            case "Rectangle":
        //                p = new ClRectangle(bd, id);
        //                llRectangles.Add((ClRectangle)p);
        //                break;
        //            case "Cercle":
        //                p = new ClCercle(bd, id);
        //                llCercles.Add((ClCercle)p);
        //                break;
        //            case "Elipse":
        //                p = new ClElipse(bd, id);
        //                llElipses.Add((ClElipse)p);
        //                break;
        //            case "Triangle rectangle":
        //                p = new ClTriangleRectangle(bd, id);
        //                llTrianglesRectangles.Add((ClTriangleRectangle)p);
        //                break;
        //            case "Triangle isosceles":
        //                p = new ClTriangleIsosceles(bd, id);
        //                llTrianglesIsosceles.Add((ClTriangleIsosceles)p);
        //                break;
        //            case "Rombe":
        //                p = new ClRombo(bd, id);
        //                llRombos.Add((ClRombo)p);
        //                break;
        //            case "Pentagon":
        //                p = new ClPentagono(bd, id);
        //                llPentagons.Add((ClPentagono)p);
        //                break;
        //            case "Hexagon":
        //                p = new ClHexagono(bd, id);
        //                llHexagons.Add((ClHexagono)p);
        //                break;
        //            case "Octagon":
        //                p = new ClOctogono(bd, id);
        //                llOctogons.Add((ClOctogono)p);
        //                break;
        //        }
        //        p.Id = id;
        //        p.Nom = fila.Cells["nombre"].Value.ToString();
        //        p. = (int)fila.Cells["Strength"].Value;
        //        p.Intelligence = (int)fila.Cells["Intelligence"].Value;
        //        p.GrupPersonatges = fila.Cells["GrupPersonatges"].Value.ToString();
        //        p.getPersonatge(bd, id);
        //        llPersonatges.Add(p);
        //    }
        //}
        private void mostrarDades(int xfila)
        {
            ClPoligon p;

            if (xfila >= 0)
            {
                //p = new ClPoligon(xfila.);
            }
        }
    }
}
