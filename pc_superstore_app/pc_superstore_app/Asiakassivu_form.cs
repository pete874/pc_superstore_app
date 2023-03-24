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

        }

        private void Asiakassivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
