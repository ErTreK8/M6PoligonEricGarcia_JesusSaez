using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6Poligon.CLASSES
{
    public class ClTriangleIsosceles : ClPoligon                 // ClPoligons és la superclasse de la que es deriva ClQuadrat
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private String Tipus { get; set; }
        private Point posVertex { get; set; }   // posició on quedarà el vèrtex superior esquerre depenent del centre i la mida

        // constructor per a un quadrat sense interior 
        // : base(.....) ve determinat per l'herència del constructor genèric de la superclasse ClPoligons
        public ClTriangleIsosceles(Form xfrmMain, Point xcentre, String xtipus, int xwidth, int xheight) : base(xfrmMain, xcentre)
        {
            Width = xwidth;
            Height = xheight;
            Tipus = xtipus;
            dibuixarFigura();
        }


        // constructor per a un quadrat amb interior (2on constructor - sobrecàrrega)
        public ClTriangleIsosceles(Form xfrmMain, Point xcentre, Color xcolor, String xtipus, int xwidth, int xheight) : base(xfrmMain, xcentre, xcolor)
        {
            Width = xwidth;
            Height = xheight;
            Tipus = xtipus;
            dibuixarFigura();
        }

        private void dibuixarFigura()
        {
            posVertex = new Point((int)(posCentre.X - (Width / 2)), (int)(posCentre.Y - (Height / 2)));
            pnl.Size = new Size(Width, Height);
            pnl.Location = posVertex;
            pnl.Paint += new PaintEventHandler(ferTriangleRectangle);
            frmPare.Controls.Add(pnl);
            pnl.BringToFront();
        }

        // pinta el quadrat dins el Panel
        private void ferTriangleRectangle(object sender, PaintEventArgs e)
        {
            Point[] vPunts = null;
            Pen p = new Pen(Color.Black, 2);   // Pen per a traçar el contorn que farem de color negre i de 2 pixels de gruix

            switch (Tipus)
            {
                case "Rectangle":
                    vPunts = new Point[4] { new Point(0, 0), new Point(0, Height), new Point(Width, Height), new Point(0, 0) };
                    break;
            }
            if (colorInterior != Color.Empty)
            {
                e.Graphics.FillPolygon(new SolidBrush(colorInterior), vPunts);
            }
            e.Graphics.DrawPolygon(p, vPunts);


        }

        // retorna l'àrea de la figura mesurada en pixels
        public override Double Area()
        {
            return (Width * Height / 2.0);
        }
    }
}
