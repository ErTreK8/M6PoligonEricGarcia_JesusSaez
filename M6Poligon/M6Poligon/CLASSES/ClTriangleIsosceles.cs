﻿using CLASSES;
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
    public class ClTriangleIsosceles : ClPoligon
    {
        private int ancho;
        private int altura;

        public ClTriangleIsosceles(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xancho, int xaltura) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            ancho = xancho;
            altura = xaltura;

            String xsql = $"INSERT INTO tbTriangleIsosceles(idPoligon, x, y) VALUES ({Id}, {ancho}, {altura})";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ClTriangleIsosceles(Panel xpnlPare, int ancho, int altura) : base(xpnlPare)
        {
            this.ancho = ancho;
            this.altura = altura;
            dibuixarFigura();
        }

        public ClTriangleIsosceles(Panel xpnlPare, Color xcolor, int ancho, int altura) : base(xpnlPare, xcolor)
        {
            this.ancho = ancho;
            this.altura = altura;
            dibuixarFigura();
        }

        public ClTriangleIsosceles(ClBDSqlServer xbd, int xid, ref int xaltura, ref int xancho) : base(xbd, xid)
        {
            getPoligons(ref xancho, ref xaltura);
        }

        public bool getPoligons(ref int xancho, ref int xaltura)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbTriangleIsosceles WHERE idPoligon = '{Id}'";

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
                new Point(ancho / 2, 0),
                new Point(0, altura),
                new Point(ancho, altura)
            };
            if (ple) e.Graphics.FillPolygon(new SolidBrush(colorInterior), points);
            e.Graphics.DrawPolygon(p, points);
        }

        public override Double Area() => (ancho * altura) / 2.0;
        public override Double Perimetre() => ancho + 2 * Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(ancho / 2.0, 2));
    }
}
