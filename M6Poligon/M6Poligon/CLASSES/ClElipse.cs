using CLASSES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6Poligon.CLASSES
{
    public class ClElipse : ClPoligon
    {
        private int altura { get; set; }          // midadel costat del quadrat

        private int ancho { get; set; }          // midadel costat del quadrat

        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons

        //Constructor vacio
        public ClElipse(Panel xpnlPare, int xaltura, int xancho) : base(xpnlPare)
        {
            altura = xaltura;
            ancho = xancho;
            dibuixarFigura();
        }


        // constructor Con color
        public ClElipse(Panel xpnlPare, Color xcolor, int xaltura, int xancho) : base(xpnlPare, xcolor)
        {
            altura = xaltura;
            ancho = xancho;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (ancho / 2)), (int)(posCentre.Y - (altura / 2)));
            pnl.Size = new Size(ancho+5, altura+5);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferCercle);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferCercle(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            Rectangle r = new Rectangle(new Point(0, 0), new Size(ancho, altura));
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillEllipse(new SolidBrush(colorInterior), r);
            }
            e.Graphics.DrawEllipse(p, r);
        }

        public ClElipse(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xancho, int xaltura) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            ancho = xancho;
            altura = xaltura;

            String xsql = $"INSERT INTO Rectangles(id, base, altura) VALUES ({Id}, {ancho}, {altura})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override Double Area()
        {
            double a = ancho / 2.0;
            double b = altura / 2.0;
            // Área = π * a * b
            return Math.PI * a * b;
        }
        public override void elimina()
        {

        }
        public override Double Perimetre()
        {
            double a = ancho / 2.0;
            double b = altura / 2.0;

            // Aproximación de Ramanujan para el perímetro de una elipse 
            // Jaume no me pongas mates porfa q dan pereza :(
            return Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
        }
        //public bool getPoligons(ref int xancho, ref int xaltura)
        //{
        //    Boolean xb = false;
        //    String xsql = "";
        //    DataSet xdset = new DataSet();

        //    xsql = $"SELECT * FROM tbRectangles WHERE id = '{Id}'";

        //    bd.Consulta(xsql, ref xdset);

        //    if (xdset.Tables[0].Rows.Count > 0)
        //    {
        //        this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
        //        xancho = (int)xdset.Tables[0].Rows[0].ItemArray[2];
        //        xaltura = (int)xdset.Tables[0].Rows[0].ItemArray[3];
        //        xb = true;
        //    }

        //    return xb;
        //}
    }
}
