using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace M6Poligon.CLASSES
{
    public abstract class ClPoligon
    {
        
        protected Form frmPare { get; set; }                    // Form on es dibuixarà el polígon
        protected private Panel pnl { get; set; } = new Panel(); // panell dins el qual es dibuixa el polígon
        protected Point posCentre { get; set; }                // posició del centre del Panel   
        protected Color colorInterior { get; set; }             // color de l'interior
        protected Boolean teInterior { get; set; }              // indica si té interior

        
        protected ClPoligon(Form xfrmMain, Point xpos)
        {
            frmPare = xfrmMain;
            colorInterior = Color.Empty;
            teInterior = false;
            posCentre = xpos;
            iniPanell();
        }

        // Constructor 2 - Hi ha color interior
        protected ClPoligon(Form xfrmMain, Point xpos, Color xcolor)
        {
            frmPare = xfrmMain;
            colorInterior = xcolor;
            teInterior = true;
            posCentre = xpos;
            iniPanell();
        }

        protected private void iniPanell()
        {
            pnl.Click += new EventHandler(nouColor);        // si es fa clic a la figura canvia el color
        }

        protected private void nouColor(object sender, EventArgs e)
        {
            Random R = new Random();
            List<Color> llColors = new List<Color> { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Cyan, Color.Magenta, Color.Black, Color.White, Color.Gray, Color.Orange, Color.Pink, Color.Purple, Color.Brown, Color.Lime, Color.Teal, Color.Olive, Color.Navy, Color.Maroon, Color.Silver, Color.Goldenrod, Color.DarkRed, Color.DarkGreen, Color.DarkBlue, Color.DarkCyan, Color.DarkMagenta, Color.DarkGray, Color.LightGray, Color.LightPink, Color.LightBlue, Color.LightGreen, Color.LightYellow, Color.LightCyan, Color.LightCoral, Color.LightSeaGreen, Color.LightGoldenrodYellow, Color.MidnightBlue, Color.MistyRose, Color.LavenderBlush, Color.Honeydew, Color.ForestGreen, Color.Fuchsia, Color.AliceBlue, Color.AntiqueWhite, Color.Aquamarine, Color.Beige, Color.Bisque, Color.BlanchedAlmond, Color.Chartreuse, Color.Coral, Color.CornflowerBlue, Color.Cornsilk };

            if (colorInterior != Color.Empty)
            {
                colorInterior = llColors[R.Next(0, llColors.Count)];        // busquem un nou color aleatòriament
                pnl.Refresh();  // redibuixem el Panel
            }
        }

        public abstract Double Area();      // retorna l'àrea de la figura mesurada en "pixels quadrats"
    }
}
