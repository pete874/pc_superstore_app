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
    public partial class Sisaankirjautuminen_form : Form
    {
        YHDISTA kirjaudu = new YHDISTA();
        ASIAKAS asiakas = new ASIAKAS();
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
            // Luodaan muuttujat, joihin tallennetaan käyttäjän loginsyöttö
            String kayttajatunnus = KayttajatunnusTB.Text;
            String salasana = SalasanaTB.Text;

            if(asiakas.KirjautumisenTarkastus(kayttajatunnus, salasana) == 1) 
            {
                MessageBox.Show("Tervetuloa työntekijä!");
                Tyontekijasivu_form tyontekijasivu = new Tyontekijasivu_form();
                tyontekijasivu.Show();
            }
            else if(asiakas.KirjautumisenTarkastus(kayttajatunnus, salasana) == 2)
            {
                MessageBox.Show("Tervetuloa asiakas!");
                Asiakassivu_form asiakassivu = new Asiakassivu_form();
                asiakassivu.Show();
            }
            else if(asiakas.KirjautumisenTarkastus(kayttajatunnus, salasana) == 3)
            {
                MessageBox.Show("Väärä käyttäjätunnus tai salasana!");
            }


            
        }
    }
}
