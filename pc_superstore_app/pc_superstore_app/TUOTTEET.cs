using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pc_superstore_app
{
    class TUOTTEET
    {
        YHDISTA yhteys = new YHDISTA();
        public DataTable HaeTietokoneet()
        {
            MySqlCommand haeTietokoneet = new MySqlCommand("SELECT tuote, tuotekategoria, hinta, saldo, tuotetiedot FROM tietokoneet", yhteys.otaYhteys());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapter.SelectCommand = haeTietokoneet;
            adapter.Fill(taulu);

            return taulu;
        }

        public DataTable HaeKomponentit()
        {
            MySqlCommand haeKomponentit = new MySqlCommand("SELECT tuote, tuotekategoria, hinta, saldo, tuotetiedot FROM komponentit", yhteys.otaYhteys());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapter.SelectCommand = haeKomponentit;
            adapter.Fill(taulu);

            return taulu;
        }

        public DataTable HaeOheistuotteet()
        {
            MySqlCommand haeOheistuotteet = new MySqlCommand("SELECT tuote, tuotekategoria, hinta, saldo, tuotetiedot FROM oheistuotteet", yhteys.otaYhteys());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapter.SelectCommand = haeOheistuotteet;
            adapter.Fill(taulu);

            return taulu;
        }


    }
}
