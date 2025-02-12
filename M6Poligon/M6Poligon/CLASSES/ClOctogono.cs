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
    public class ClOctogono : ClPoligon
    {
        private int mida;
        private PointF[] vertices;

        public ClOctogono(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO tbOctagon(idPoligon, mida) VALUES ({Id}, {xmida})";

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
            dibuixarFiguraOctagono();
        }

        public ClOctogono(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            mida = xmida;
            dibuixarFiguraOctagono();
        }

        public ClOctogono(ClBDSqlServer xbd, int xid, ref int xmida) : base(xbd, xid)
        {
            getPoligons(ref xmida);
        }
        public bool getPoligons(ref int xmida)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbOctagon WHERE idPoligon = '{Id}'";

            bd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count > 0)
            {
                this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
                xmida = (int)xdset.Tables[0].Rows[0].ItemArray[2];
                xb = true;
            }

            return xb;
        }

        private PointF[] calcularVerticesOctagon(Point posCentre, int mida)
        {
            PointF[] vertices = new PointF[8];
            float radio = mida / 2f; // Distancia desde el centro
            float anguloInicial = -(float)Math.PI / 2; // Empieza en la parte superior

            for (int i = 0; i < 8; i++)
            {
                float angulo = anguloInicial + i * (2 * (float)Math.PI / 8);
                float x = posCentre.X + radio * (float)Math.Cos(angulo);
                float y = posCentre.Y + radio * (float)Math.Sin(angulo);
                vertices[i] = new PointF(x, y);
            }

            return vertices;
        }

        private void dibuixarFiguraOctagono()
        {
            vertices = calcularVerticesOctagon(new Point(mida, mida), mida); // Centra dentro del panel

            pnl.Size = new Size(mida * 2, mida * 2);
            pnl.Location = new Point(posCentre.X - mida, posCentre.Y - mida);
            pnl.Paint += new PaintEventHandler(ferOctogono);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferOctogono(object sender, PaintEventArgs e)
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



        public override double Area() => 2 * (1 + Math.Sqrt(2)) * Math.Pow(mida, 2);
        public override double Perimetre() => 8 * mida;
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
