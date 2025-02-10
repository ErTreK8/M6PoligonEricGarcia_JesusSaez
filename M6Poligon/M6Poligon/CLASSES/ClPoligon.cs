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

        public ClPoligon(ClBDSqlServer xbd, String xnom, String xforma, String xcolor, int xple)
        {

            DataSet xdset = new DataSet();
            String xsql = $"INSERT INTO Poligon(Nom, Forma, Color, Ple) VALUES('{xnom}', '{xforma}', '{xcolor}', {xple})";

            if (xbd.executarOrdre(xsql))
            {
                // Si la inserció ha anat bé recuperem l'Id generat perquè el necessitem per a fer la inserció en la taula de la subclasse
                // ALERTA!!!! En un entorn multiusuari, aquesta operació s'hauria de fer amb una TRANSACTION per a garantir que el resultat és correcte
                xsql = "SELECT TOP 1 Id FROM Poligon ORDER BY Id DESC";
                //CAMBIAR A ID AUTOINCREMENTAL???????
                xbd.Consulta(xsql, ref xdset);
                if (xdset.Tables[0].Rows.Count == 0)
                {
                    Id = -1;
                    MessageBox.Show("No s'ha pogut recuperar l'Id del nou polígon", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Id = (int)xdset.Tables[0].Rows[0].ItemArray[0];
                }
            }
        }


        public abstract void elimina();
        public abstract Double Area();
        public abstract Double Perimetre();
        public abstract bool getPoligons(ClBDSqlServer bd, int idPoligon);
    }
}
