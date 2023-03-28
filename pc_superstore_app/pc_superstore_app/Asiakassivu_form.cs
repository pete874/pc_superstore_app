using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pc_superstore_app
{
    public partial class Asiakassivu_form : Form
    {
        public Asiakassivu_form()
        {
            InitializeComponent();
        }

        private void Asiakassivu_form_Load(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = true;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
        }

        private void Asiakassivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EtusivuLB_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = true;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
        }


        private void TietokoneetBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = true;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
        }

        private void KomponentitBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = true;
            OheistuotteetPN.Visible = false;
        }

        private void OheistuotteetBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = true;
        }
    }
}
