using CLASSES;
using M6Poligon.CLASSES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace M6Poligon
{
    public partial class FrmMain : Form
    {
        String cadenaConnexio = @"Data Source=localhost;Initial Catalog=bdPoligons;Integrated Security=True";
        ClBDSqlServer bd;
        DataSet dset;
        Boolean tots = true;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bd = new ClBDSqlServer(cadenaConnexio);
            dset = new DataSet();
            if (bd.Connectar())
            {
                cbGrup.SelectedIndex = 0;
                getDades(true);
                //customDgrid();
            }
            else
            {
                MessageBox.Show("No em puc connectar a la base de dades", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void getDades(bool xbTots)
        {
            String xsql = "";

            if (tots)
            {
                xsql = "SELECT * FROM tbPoligon ORDER BY nombre";
            }
            else
            {
                xsql = $"SELECT * from tbPoligon p inner join tb{cbGrup.SelectedIndex.ToString().Replace(" ", "")} t on t.idPoligon=p.idPoligon ORDER BY nombre";
            }

            
            bd.Consulta(xsql,ref dset);

            //omplirLlistes();

        }

        private void cbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGrup.SelectedIndex.ToString() != "Tots")
            {
                tots = false;
            }
            else tots = true;
        }
    }
}
