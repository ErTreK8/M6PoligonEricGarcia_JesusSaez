using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6Poligon.CLASSES
{
    public class ClElipse : ClPoligon
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons
        public ClElipse(Form xfrmMain, Point xcentre, int xwidth, int xheight) : base(xfrmMain, xcentre)
        {
            Width = xwidth;
            Height = xheight;
            dibuixarFigura();
        }


        // constructor per a un quadrat amb interior (2on constructor - sobrecàrrega)
        public ClElipse(Form xfrmMain, Point xcentre, Color xcolor, int xwidth, int xheight) : base(xfrmMain, xcentre, xcolor)
        {
            Width = xwidth;
            Height = xheight;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (Width / 2)), (int)(posCentre.Y - (Height / 2)));
            pnl.Size = new Size(Width + 5, Height + 5);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferCercle);
            frmPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferCercle(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            Rectangle r = new Rectangle(new Point(0, 0), new Size(Width, Height));
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillEllipse(new SolidBrush(colorInterior), r);
            }
            e.Graphics.DrawEllipse(p, r);
        }


        public override Double Area()
        {
            double a = Width / 2.0;
            double b = Height / 2.0;
            // Área = π * a * b
            return Math.PI * a * b;
        }
    }
}
