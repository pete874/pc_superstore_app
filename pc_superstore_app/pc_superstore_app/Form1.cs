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
            
            MySqlCommand asiakaskomento = new MySqlCommand("SELECT kayttajatunnus, salasana, oikeudet FROM kayttajat WHERE kayttajatunnus = @ktu AND salasana = @sal AND oikeudet = 2");
            
            asiakaskomento.Parameters.Add("@ktu", MySqlDbType.VarChar).Value = KayttajatunnusTB.Text;
            asiakaskomento.Parameters.Add("@sal", MySqlDbType.VarChar).Value = SalasanaTB.Text;
           


            asiakaskomento.Connection = kirjaudu.otaYhteys();
            

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable taulukko = new DataTable();

            adapter.SelectCommand = asiakaskomento;
            adapter.Fill(taulukko);

            kirjaudu.avaaYhteys();

            if (taulukko.Rows.Count > 0 ) 
            {
           
                MessageBox.Show("Tervetuloa asiakas.");
                // Avataan asiakkaille tarkoitettu etusivu
            }
            else
            {
                MessageBox.Show("Väärä salasana tai käyttäjätunnus.", "Virhe!");
            }


            /*MySqlCommand tyontekijakomento = new MySqlCommand("SELECT kayttajatunnus, salasana FROM kayttajat WHERE kayttajatunnus = @ktu AND salasana = @sal AND oikeudet = 1");

            tyontekijakomento.Parameters.Add("@ktu", MySqlDbType.VarChar).Value = KayttajatunnusTB.Text;
            tyontekijakomento.Parameters.Add("@sal", MySqlDbType.VarChar).Value = SalasanaTB.Text;

            tyontekijakomento.Connection = kirjaudu.otaYhteys();


            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            DataTable taulukko2 = new DataTable();

            adapter2.SelectCommand = tyontekijakomento;
            adapter2.Fill(taulukko2);

            kirjaudu.avaaYhteys();

            if (taulukko.Rows.Count > 0)
            {
                MessageBox.Show("Tervetuloa työntekijä.");
                // Avataan työntekijöille tarkoitettu etusivu
            }
            else
            {
                MessageBox.Show("Väärä salasana tai käyttäjätunnus.", "Virhe!");
            }



            //asiakas.HaeAsiakkaat();
            //MessageBox.Show("Asiakkaiden haku onnistui");*/
        }
    }
}
