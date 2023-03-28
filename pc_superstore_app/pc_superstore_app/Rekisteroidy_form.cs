using MySql.Data.MySqlClient;
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
    public partial class Rekisteroidy_form : Form
    {
        YHDISTA register = new YHDISTA();
        ASIAKAS asiakas = new ASIAKAS();
        public Rekisteroidy_form()
        {
            InitializeComponent();
        }

        private void Rekisteroidy_form_Load(object sender, EventArgs e)
        {

        }

        private void RekisteroidyBT_Click(object sender, EventArgs e)
        {
            String kayttajatunnus = KayttajatunnusTB.Text.ToString();
            String salasana = SalasanaTB.Text.ToString();
            String email = EmailTB.Text.ToString();

            if (kayttajatunnus.Trim().Equals("") || salasana.Trim().Equals("") || email.Trim().Equals(""))
            {
                MessageBox.Show("Täytä kaikki kentät!");
                
            }
            else
            {
                Boolean LisaaAsiakas = asiakas.LisaaAsiakas(kayttajatunnus, salasana, email);

                if(LisaaAsiakas)
                {
                    MessageBox.Show("Rekisteröinti onnistui!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Rekisteröinti ei onnistunut! Yritä uudestaan.");
                    this.Close();
                }
                
            }
            
        }
    }
}
