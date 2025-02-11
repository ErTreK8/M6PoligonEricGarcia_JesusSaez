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
    public class ClQuadrat : ClPoligon          // ClPoligons és la superclasse de la que es deriva ClQuadrat
    {
        private int mida{ get; set; }          // midadel costat del quadrat
        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons

        //Constructor vacio
        public ClQuadrat(Panel xpnlPare, int xmida) : base(xpnlPare)
        {
            mida= xmida;
            dibuixarFigura();
        }


        // constructor Con color
        public ClQuadrat(Panel xpnlPare, Color xcolor, int xmida) : base(xpnlPare, xcolor)
        {
            this.mida= xmida;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (mida/ 2)), (int)(posCentre.Y - (mida/ 2)));
            pnl.Size = new Size(mida, mida);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferQuadrat);
            pnlPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferQuadrat(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            Rectangle r = new Rectangle(new Point(0, 0), new Size(mida, mida));
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillRectangle(new SolidBrush(colorInterior), r);
            }
            e.Graphics.DrawRectangle(p, r);


        }

        public ClQuadrat(ClBDSqlServer xbd, string xnom, string xtipo, string xColor, string xPle, int xmida) : base(xbd,xnom,xtipo,xColor,xPle)
        {
            mida = xmida;


            String xsql = $"INSERT INTO Rectangles(id, mida, ) VALUES ({Id}, {xmida},)";

            if (xbd.executarOrdre(xsql))
            {
                MessageBox.Show($"Poligon inserit correctament a la base de dades", "TOT BÉ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No s'ha pogut inserir el {xtipo} a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // retorna l'àrea de la figura mesurada en pixels
        public override Double Area()
        {
            return (mida* mida);
        }
        public override void elimina ()
        {
            //Aqui lo de borrar de la db
        }
        public override Double Perimetre()
        {
            return mida * 4;
        }



        //JESUS TIENES QUE HACERLO ASI MIRALO CHILL


        //public override bool getPoligono(ClBd bd, int id)
        //{
        //    Boolean xb = false;
        //    String xsql = "";
        //    DataSet xdset = new DataSet();

        //    xsql = $"SELECT * FROM Rectangles WHERE id = '{id}'";

        //    if (bd.getDades(xsql, xdset) && xdset.Tables[0].Rows.Count > 0)
        //    {
        //        this.Id = (int)xdset.Tables[0].Rows[0].ItemArray[0];
        //        this.Base = (int)xdset.Tables[0].Rows[0].ItemArray[1];
        //        this.Altura = (int)xdset.Tables[0].Rows[0].ItemArray[2];
        //        xb = true;
        //    }

        //    return xb;
        //}

        public override bool getPoligons(ClBDSqlServer bd, int idPoligon)
        {
            Boolean xb = false;
            return xb;
        }
    }
}
