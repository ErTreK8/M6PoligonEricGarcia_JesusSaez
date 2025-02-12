using CLASSES;
using M6Poligon.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace M6Poligon.FORMS
{
    public partial class FrmAdd : Form
    {
        String poligon = "Cercle";
        ClBDSqlServer bd;
        int ple;
        public FrmAdd(ClBDSqlServer xbd)
        {
            InitializeComponent();

            bd = xbd;
        }

        private void chkPle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPle.Checked) chkPle.Text = "Ple";
            else chkPle.Text = "Buit";
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            tbNom.MaxLength = 50;
            nUDAlcada.Enabled = false;
            nUDAmplada.Enabled = false;
            nupMida.Enabled = true;

        }

        private void rdCercle_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                poligon = ((RadioButton)sender).Text;
            }
            if (poligon=="Cercle" || poligon == "Quadrat" || poligon == "Pentagon" || poligon == "Hexagon" || poligon == "Octagon")
            {
                nUDAlcada.Enabled=false;
                nUDAmplada.Enabled=false;
                nupMida.Enabled = true;
            }
            else
            {
                nUDAlcada.Enabled = true;
                nUDAmplada.Enabled = true;
                nupMida.Enabled = false;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (tbNom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Cal introduir el nom", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                object p;
                if (chkPle.Checked)
                {
                    ple = 1;
                }
                else
                {
                    ple = 0;
                }
                switch (poligon)
                    {
                    case "Cercle":
                        p = new ClCercle(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nupMida.Value);
                        break;
                    case "Quadrat":
                        p = new ClQuadrat(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nupMida.Value);
                        break;
                    case "Rectangle":
                        p = new ClRectangle(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(),(int)nUDAmplada.Value, (int)nUDAlcada.Value);
                        break;
                    case "Elipse":
                        p = new ClElipse(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nUDAmplada.Value, (int)nUDAlcada.Value);
                        break;
                    case "Triangle rectangle":
                        p = new ClTriangleRectangle(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nUDAmplada.Value, (int)nUDAlcada.Value);
                        break;
                    case "Triangle isosceles":
                        p = new ClTriangleIsosceles(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nUDAmplada.Value, (int)nUDAlcada.Value);
                        break;
                    case "Rombe":
                        p = new ClRombo(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nUDAmplada.Value, (int)nUDAlcada.Value);
                        break;
                    case "Pentagon":
                        p = new ClPentagono(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nupMida.Value);
                        break;
                    case "Hexagon":
                        p = new ClHexagono(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nupMida.Value);
                        break;
                    case "Octagon":
                        p = new ClOctogono(bd, tbNom.Text.ToString(), poligon, "#FF5733", ple.ToString(), (int)nupMida.Value);
                        break;
                }
                p = null;
            }
                
        }
    }
}
