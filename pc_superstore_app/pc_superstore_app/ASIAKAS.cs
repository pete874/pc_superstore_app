using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pc_superstore_app
{
    class ASIAKAS
    {
        YHDISTA yhteys = new YHDISTA();


        public DataTable HaeAsiakkaat()
        {
            MySqlCommand haeKaikki = new MySqlCommand("SELECT kayttajatunnus, salasana, oikeudet FROM kayttajat", yhteys.otaYhteys());


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulukko = new DataTable();

            adapter.SelectCommand = haeKaikki;
            adapter.Fill(taulukko);

            

            return taulukko;

        }

        public bool LisaaAsiakas(String kayttajatunnus, String salasana, String email)
        {

            MySqlCommand kayttajakomento = new MySqlCommand("INSERT INTO kayttajat (kayttajatunnus, salasana, email, oikeudet) VALUES (@ktu, @sal, @ema, 2)", yhteys.otaYhteys()); 

            kayttajakomento.Parameters.AddWithValue("@ktu", kayttajatunnus);
            kayttajakomento.Parameters.AddWithValue("@sal", salasana);
            kayttajakomento.Parameters.AddWithValue("@ema", email);

            yhteys.avaaYhteys();

            if (kayttajakomento.ExecuteNonQuery() == 1)
            {
                yhteys.suljeYhteys();
                return true;
            }
            else
            {
                yhteys.suljeYhteys();
                return false;
            }
        }
    
    }
}
