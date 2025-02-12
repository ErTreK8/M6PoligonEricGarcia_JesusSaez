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
    public class ClTriangleRectangle : ClPoligon
    {
        private int ancho;
        private int altura;

        public ClTriangleRectangle(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xancho, int xaltura) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            ancho = xancho;
            altura = xaltura;

            String xsql = $"INSERT INTO tbTriangleRectangle(idPoligon, base, altura) VALUES ({Id}, {ancho}, {altura})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ClTriangleRectangle(Panel xpnlPare, int ancho, int altura) : base(xpnlPare)
        {
            this.ancho = ancho;
            this.altura = altura;
            dibuixarFigura();
        }

        public ClTriangleRectangle(Panel xpnlPare, Color xcolor, int ancho, int altura) : base(xpnlPare, xcolor)
        {
            this.ancho = ancho;
            this.altura = altura;
            dibuixarFigura();
        }


        public ClTriangleRectangle(ClBDSqlServer xbd, int xid, ref int xaltura, ref int xancho) : base(xbd, xid)
        {
            getPoligons(ref xancho, ref xaltura);
        }

        public bool getPoligons(ref int xancho, ref int xaltura)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbTriangleRectangle WHERE idPoligon = '{Id}'";

            bd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count > 0)
            {
                this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
                xancho = (int)xdset.Tables[0].Rows[0].ItemArray[2];
                xaltura = (int)xdset.Tables[0].Rows[0].ItemArray[3];
                xb = true;
            }

            return xb;
        }

        private void dibuixarFigura()
        {
            pnl.Size = new Size(ancho, altura);
            pnl.Location = new Point(posCentre.X - ancho / 2, posCentre.Y - altura / 2);
            pnl.Paint += new PaintEventHandler(ferTriangle);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferTriangle(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);
            Point[] points = {
                new Point(0, altura),
                new Point(ancho, altura),
                new Point(0, 0)
            };
            if (ple) e.Graphics.FillPolygon(new SolidBrush(colorInterior), points);
            e.Graphics.DrawPolygon(p, points);
        }

        public override Double Area() => (ancho * altura) / 2.0;
        public override Double Perimetre() => ancho + altura + Math.Sqrt(Math.Pow(ancho, 2) + Math.Pow(altura, 2));
        public override void elimina() { }
        
    }
}
