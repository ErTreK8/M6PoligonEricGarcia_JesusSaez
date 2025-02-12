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
    public class ClCercle : ClPoligon
    {

        private int mida { get; set; }          // midadel costat del quadrat
        // midadel costat del quadrat

        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons

        //Constructor vacio
        public ClCercle(Panel xpnlPare, int xmida) : base(xpnlPare)
        {
            mida = xmida;
            dibuixarFigura();
        }

        public ClCercle(ClBDSqlServer xbd, int xid, ref int xmida) : base(xbd, xid)
        {
            getPoligons(ref xmida);
        }

        // constructor Con color
        public ClCercle(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            this.mida = xmida;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (mida / 2)), (int)(posCentre.Y - (mida / 2)));
            pnl.Size = new Size(mida+5,mida+5);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferCercle);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferCercle(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            Rectangle r = new Rectangle(new Point(0, 0), new Size(mida, mida));
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillEllipse(new SolidBrush(colorInterior), r);
            }
            e.Graphics.DrawEllipse(p, r);
        }

        public ClCercle(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd, xnom, xtipo, xColor, xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO tbCercle(idPoligon, mida) VALUES ({Id}, {xmida})";

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
            double radio = mida / 2.0;
            // Área = π * a * b
            return Math.PI * (radio*radio);
        }
        public override Double Perimetre()
        {
            double radio = mida / 2.0;

            return 2*Math.PI*radio;
        }
        public bool getPoligons(ref int xmida)
        {
            Boolean xb = false;
            String xsql = "";
            DataSet xdset = new DataSet();

            xsql = $"SELECT * FROM tbCercle WHERE idPoligon = '{Id}'";

            bd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count > 0)
            {
                this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[1];
                xmida = (int)xdset.Tables[0].Rows[0].ItemArray[2];
                xb = true;
            }

            return xb;
        }

    }
}
