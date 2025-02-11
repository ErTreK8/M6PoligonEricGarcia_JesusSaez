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
    public class ClPentagono : ClPoligon
    {
        private int mida;
        private Point[] vertices;

        public ClPentagono(Panel xpnlPare, int xmida) : base(xpnlPare)
        {
            mida = xmida;
            dibuixarFigura();
        }

        public ClPentagono(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            mida = xmida;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            vertices = calcularVerticesPentagon(posCentre, mida);
            pnl.Size = new Size(mida * 2, mida * 2);
            pnl.Location = new Point(posCentre.X - mida, posCentre.Y - mida);
            pnl.Paint += new PaintEventHandler(ferPentagono);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferPentagono(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillPolygon(new SolidBrush(colorInterior), vertices);
            }
            e.Graphics.DrawPolygon(p, vertices);
        }

        private Point[] calcularVerticesPentagon(Point center, int size)
        {
            Point[] points = new Point[5];
            for (int i = 0; i < 5; i++)
            {
                double angle = -Math.PI / 2 + (2 * Math.PI * i / 5);
                points[i] = new Point(
                    center.X + (int)(size * Math.Cos(angle)),
                    center.Y + (int)(size * Math.Sin(angle))
                );
            }
            return points;
        }

        public ClPentagono(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO tbPentagono(id, mida, ) VALUES ({Id}, {xmida},)";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override double Area() => (5 * mida * mida) / (4 * Math.Tan(Math.PI / 5));
        public override double Perimetre() => 5 * mida;
        public override void elimina() { }
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
