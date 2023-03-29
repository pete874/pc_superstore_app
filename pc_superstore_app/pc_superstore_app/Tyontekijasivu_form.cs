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
    public partial class Tyontekijasivu_form : Form
    {
        public Tyontekijasivu_form()
        {
            InitializeComponent();
        }

        private void Tyontekijasivu_form_Load(object sender, EventArgs e)
        {

        }

        private void Tyontekijasivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AsiakkaatBT_Click(object sender, EventArgs e)
        {
            TyontekijaEtusivuPN.Visible = true;
            TilauksetPN.Visible = false;
            AsiakkaatPN.Visible = true;
            VarastoPN.Visible = false;
        }

        private void TilauksetBT_Click(object sender, EventArgs e)
        {
            TilauksetPN.Visible = true;
            AsiakkaatPN.Visible = false;
            VarastoPN.Visible = false;
        }

        private void VarastoBT_Click(object sender, EventArgs e)
        {
            TilauksetPN.Visible = false;
            AsiakkaatPN.Visible = false;
            VarastoPN.Visible = true;
        }
    }
}
