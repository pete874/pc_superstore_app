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
    public partial class Sisaankirjautuminen_form : Form
    {
        public Sisaankirjautuminen_form()
        {
            InitializeComponent();
        }

        private void RekisteroidyLB_Click(object sender, EventArgs e)
        {
            Rekisteroidy_form rekisteroidy = new Rekisteroidy_form();
            rekisteroidy.Show();

        }

        private void KirjauduBT_Click(object sender, EventArgs e)
        {
            
        }
    }
}
