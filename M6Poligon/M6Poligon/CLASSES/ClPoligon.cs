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
using System.Data;
using CLASSES;
using System.Globalization;
using System.Xml.Linq;

namespace M6Poligon.CLASSES
{
    public abstract class ClPoligon
    {
        protected Panel pnlPare { get; set; }                    // Form on es dibuixarà el polígon
        protected private Panel pnl { get; set; } = new Panel(); // panell dins el qual es dibuixa el polígon
        protected Point posCentre { get; set; }                // posició del centre del Panel   
        public Color colorInterior { get; set; }             // color de l'interior
        public Boolean ple { get; set; }              // indica si té interior
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Forma { get; set; }
        public ClBDSqlServer bd { get; set; }

        // Declarem constructors genèrics per a totes les subclasses que es derivin d'aquesta
        // Quan s'executi el constructor de qualsevol de les subclasses aquest s'executarà abans

        // Constructor 1 - No hi ha color interior
        protected ClPoligon(Panel xpnlPare)
        {
            pnlPare = xpnlPare;
            colorInterior = Color.Empty;
            ple = false;
            posCentre = new Point(pnlPare.Width / 2, pnlPare.Height / 2);
        }

        // Constructor 2 - Hi ha color interior
        protected ClPoligon(Panel xpnlPare, Color xcolor)
        {
            pnlPare = xpnlPare;
            colorInterior = xcolor;
            ple = true;
            posCentre = new Point(pnlPare.Width / 2, pnlPare.Height / 2);
        }

        public ClPoligon(ClBDSqlServer xbd, int xid)
        {
            Id = xid;
            bd = xbd;
        }
        //CONSTRUCTOR PER FER L'INSERT

        public ClPoligon(ClBDSqlServer xbd, String xname, String xtipo, String xColor, String xPle)
        {
            DataSet xdset = new DataSet();
            String xsql = $"SELECT nombre from tbPoligon where nombre ='{xname}'";
            xbd.Consulta(xsql, ref xdset);

            if (xdset.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Ya hi ha un Poligon amb aquest nom", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                xdset=new DataSet();
                xsql = $"INSERT INTO tbPoligon(nombre, color, forma, ple) VALUES ('{xname}','{xColor}','{xtipo}','{xPle}')";

                if (xbd.executarOrdre(xsql))
                {
                    xsql = "SELECT TOP 1 idPoligon FROM tbPoligon ORDER BY idPoligon DESC";
                    xbd.Consulta(xsql, ref xdset);

                    if (xdset.Tables[0].Rows.Count == 0)
                    {
                        Id = -1;
                        MessageBox.Show("No s'ha pogut recuperar l'Id del nou poligono", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Id = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                    }
                }
            }
        }

        public abstract Double Area();
        public abstract Double Perimetre();
    }
}
