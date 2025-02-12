﻿using CLASSES;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace M6Poligon.CLASSES
{
    public class ClHexagono : ClPoligon
    {
        private int mida;
        private PointF[] vertices;

        public ClHexagono(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO tbHexagon(idPoligon, mida) VALUES ({Id}, {xmida})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ClHexagono(Panel xpnlPare, int xmida) : base(xpnlPare)
        {
            mida = xmida;
            dibuixarFiguraHexagono();
        }

        public ClHexagono(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            mida = xmida;
            dibuixarFiguraHexagono();
        }

        public ClHexagono(ClBDSqlServer xbd, int xid, ref int xmida) : base(xbd, xid)
        {
            getPoligons(ref xmida);
        }
        public bool getPoligons(ref int xmida)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbHexagon WHERE idPoligon = '{Id}'";

            bd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count > 0)
            {
                this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
                xmida = (int)xdset.Tables[0].Rows[0].ItemArray[2];
                xb = true;
            }

            return xb;
        }

        private PointF[] calcularVerticesHexagon(Point posCentre, int mida)
        {
            PointF[] vertices = new PointF[6];
            float radio = mida / 2f; // La distancia desde el centro a los vértices
            float anguloInicial = -(float)Math.PI / 2; // Iniciar en la parte superior

            for (int i = 0; i < 6; i++)
            {
                float angulo = anguloInicial + i * (2 * (float)Math.PI / 6);
                float x = posCentre.X + radio * (float)Math.Cos(angulo);
                float y = posCentre.Y + radio * (float)Math.Sin(angulo);
                vertices[i] = new PointF(x, y);
            }

            return vertices;
        }

        private void dibuixarFiguraHexagono()
        {
            vertices = calcularVerticesHexagon(new Point(mida, mida), mida); // Centra dentro del panel

            pnl.Size = new Size(mida * 2, mida * 2);
            pnl.Location = new Point(posCentre.X - mida, posCentre.Y - mida);
            pnl.Paint += new PaintEventHandler(ferHexagono);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        private void ferHexagono(object sender, PaintEventArgs e)
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



        public override double Area() => (3 * Math.Sqrt(3) / 2) * Math.Pow(mida, 2);
        public override double Perimetre() => 6 * mida;
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