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
        private PointF[] vertices;

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

        public ClPentagono(ClBDSqlServer xbd, int xid, ref int xmida) : base(xbd, xid)
        {
            getPoligons(ref xmida);
        }
        public bool getPoligons(ref int xmida)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbPentagon WHERE idPoligon = '{Id}'";

            bd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count > 0)
            {
                this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
                xmida = (int)xdset.Tables[0].Rows[0].ItemArray[2];
                xb = true;
            }

            return xb;
        }

        private PointF[] calcularVerticesPentagon(Point posCentre, int mida)
        {
            PointF[] vertices = new PointF[5];
            float radio = mida / 2f; // La distancia desde el centro a los vértices
            float anguloInicial = -(float)Math.PI / 2; // Inicia con el vértice superior

            for (int i = 0; i < 5; i++)
            {
                float angulo = (float)(anguloInicial + i * (2 * Math.PI / 5));
                float x = posCentre.X + radio * (float)Math.Cos(angulo);
                float y = posCentre.Y + radio * (float)Math.Sin(angulo);
                vertices[i] = new PointF(x, y);
            }

            return vertices;
        }

        private void dibuixarFigura()
        {
            vertices = calcularVerticesPentagon(new Point(mida, mida), mida); // Centra dentro del panel

            pnl.Size = new Size(mida * 2, mida * 2);
            pnl.Location = new Point(posCentre.X - mida, posCentre.Y - mida);
            pnl.Paint += new PaintEventHandler(ferPentagono);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferPentagono(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // Suaviza los bordes

            if (colorInterior != Color.Empty)
            {
                g.FillPolygon(new SolidBrush(colorInterior), vertices);
            }
            g.DrawPolygon(p, vertices);
        }

        public ClPentagono(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO tbPentagon(idPoligon, mida) VALUES ({Id}, {xmida})";

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
