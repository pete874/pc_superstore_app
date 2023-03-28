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

            // Valitaan tietokannasta oikeudet-sarake tarkasteltavaksi ja käytetään käyttäjätunnusta / salasanaa määrittelyyn
            MySqlCommand kayttajakomento = new MySqlCommand("SELECT oikeudet FROM kayttajat WHERE kayttajatunnus = @ktu AND salasana = @sal", kirjaudu.otaYhteys());
            
            
            kayttajakomento.Parameters.AddWithValue("@ktu", kayttajatunnus);
            kayttajakomento.Parameters.AddWithValue("@sal", salasana);
            kayttajakomento.Connection = kirjaudu.otaYhteys();

            kirjaudu.avaaYhteys();
            // Luodaan objekti joka palauttaa kyselyn ensimmäisen rivin ensimmäisen sarakkeen(tässä tapauksessa oikeudet)
            int result = Convert.ToInt32(kayttajakomento.ExecuteScalar());
            kirjaudu.suljeYhteys();
 
            // Tarkistetaan if- lauseilla onko kirjautujan oikeudet 1 - työntekijä, vai 2 - asiakas.  
            
            
                int oikeudet = result;
                if (oikeudet == 1) // työntekijä
                {
                    // Ohjataan työntekijöiden sivulle
                    MessageBox.Show("Tervetuloa työntekijä!");
                    Tyontekijasivu_form tyontekijasivu = new Tyontekijasivu_form();
                    tyontekijasivu.Show();
                    this.Hide();
                }
                else if (oikeudet == 2) // asiakas
                {
                    // Ohjataan asiakassivulle
                    MessageBox.Show("Tervetuloa asiakas!");
                    Asiakassivu_form asiakassivu = new Asiakassivu_form();
                    asiakassivu.Show();
                    this.Hide();
                }
                else
                {
                   MessageBox.Show("Väärä käyttäjätunnus tai salasana!");
                }

            
        }
    }
}
