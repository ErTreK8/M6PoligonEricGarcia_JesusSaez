using CLASSES;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6Poligon.CLASSES
{
    public class ClOctogono : ClPoligon
    {
        private int mida;
        private Point[] vertices;

        public ClOctogono(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
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

        public ClOctogono(Panel xpnlPare, int xmida) : base(xpnlPare)
        {
            mida = xmida;
            dibuixarFigura();
        }

        public ClOctogono(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            mida = xmida;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            vertices = calcularVerticesOctagon(posCentre, mida);
            pnl.Size = new Size(mida * 2, mida * 2);
            pnl.Location = new Point(posCentre.X - mida, posCentre.Y - mida);
            pnl.Paint += new PaintEventHandler(ferOctogono);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferOctogono(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillPolygon(new SolidBrush(colorInterior), vertices);
            }
            e.Graphics.DrawPolygon(p, vertices);
        }

        private Point[] calcularVerticesOctagon(Point center, int size)
        {
            Point[] points = new Point[8];
            for (int i = 0; i < 8; i++)
            {
                double angle = Math.PI / 8 + (2 * Math.PI * i / 8);
                points[i] = new Point(
                    center.X + (int)(size * Math.Cos(angle)),
                    center.Y + (int)(size * Math.Sin(angle))
                );
            }
            return points;
        }

        public override double Area() => 2 * (1 + Math.Sqrt(2)) * Math.Pow(mida, 2);
        public override double Perimetre() => 8 * mida;
        public override void elimina() { }
        public override bool getPoligons(ClBDSqlServer bd, int idPoligon) => false;
    }
}
