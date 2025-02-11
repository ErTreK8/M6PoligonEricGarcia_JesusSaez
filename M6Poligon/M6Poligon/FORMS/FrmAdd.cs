using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M6Poligon.FORMS
{
    public partial class FrmAdd : Form
    {
        bdPoligonsEntities poligonsContext;

        public FrmAdd()
        {
            InitializeComponent();
        }

        private void chkPle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPle.Checked) chkPle.Text = "Ple";
            else chkPle.Text = "Buit";
        }

        private void FrmAdd_Load(object sender, EventArgs e)
        {
            getDades();
        }

        private void getDades()
        {
            var poligons = (from p in poligonsContext.);

        }
    }
}
