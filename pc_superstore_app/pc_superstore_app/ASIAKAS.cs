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
            MySqlCommand haeKaikki = new MySqlCommand("SELECT kayttajatunnus, salasana FROM kayttajat", yhteys.otaYhteys());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulukko = new DataTable();

            adapter.SelectCommand = haeKaikki;
            adapter.Fill(taulukko);

            return taulukko;

        }
    }
}
