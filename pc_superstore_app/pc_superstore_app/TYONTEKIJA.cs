using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace pc_superstore_app
{
    class TYONTEKIJA
    {
        YHDISTA yhteys = new YHDISTA();

        public DataTable HaeTyontekijaAsiakkaat()
        {
            // tehdään uusi mysqlcommand. Sulkeiden sisään tulee itse komento ja otaYhteys funktio. MySqlCommand(String, MySqlConnection)
            MySqlCommand haeKaikki = new MySqlCommand("SELECT kayttajatunnus, salasana, email, oikeudet FROM kayttajat", yhteys.otaYhteys());

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulu = new DataTable();

            adapter.SelectCommand = haeKaikki;
            adapter.Fill(taulu);

            return taulu;
        }

        public bool LisaaTyontekijaAsiakas(int oikeudet, String kayttajatunnus, String salasana, String email)
        {
            MySqlCommand komento = new MySqlCommand();

            //Tallennetaan stringiin SQL kysely. Tämä voidaan myös laittaa suoraan MySqlCommandin sulkeiden sisään yhteys-funktion kanssa, niikuin ylimmässä funktiossa on tehty.
            String lisaysKysely = "INSERT INTO kayttajat (oikeudet, kayttajatunnus, salasana, email) VALUES (@oik, @kay, @sal, @ema); ";

            //Asettaa Stringin SQL komennoksi komento muuttujaan
            komento.CommandText = lisaysKysely;

            //Asettaa otaYhteys funktion SQL yhteydeksi Connection komennolla. Tämä voidaan myös laittaa yhteydeksi MySqlCommandin sisään pilkun jälkeen toiseksi parametriksi
            komento.Connection = yhteys.otaYhteys();

            //Tehdään C# puolelta luettavat muuttujat, joita voidaan käyttää SQL komennossa. Huom. Normaalit C# muuttujat eivät toimi SQL komennossa.
            komento.Parameters.Add("@oik", MySqlDbType.Int32).Value = oikeudet;
            komento.Parameters.Add("@kay", MySqlDbType.VarChar).Value = kayttajatunnus;
            komento.Parameters.Add("@sal", MySqlDbType.VarChar).Value = salasana;
            komento.Parameters.Add("@ema", MySqlDbType.VarChar).Value = email;


            yhteys.avaaYhteys();

            //ExecuteNonQuerya käytetään SQL komentoihin, joilla ei palauteta dataa vaan pelkästään tallennetaan dataa tietokantaan(UPDATE,INSERT,DELETE)
            //Jos SQL-lisäyskysely onnistuu esimerkiksi päivittämään rivin tietokannnassa, palauttaa ExecuteNonQuery int-tyyppinä vaikutuksen alaisena olevien rivien määrän
            // eli kuinka monta riviä esim päivitetty tai poistettu.
            // Tässä kyseisessä komennossa rivejä palautuu aina yksi, jos on onnistuttu muuttamaan dataa. Jos yhtäkään riviä ei muutettu, palautuu numero -1
            //Alhaalla tarkistetaan onko riviä onnistuttu muuttamaan ja palautetaan joko true tai false boolean.
            if (komento.ExecuteNonQuery() == 1)
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

        public bool MuokkaaTyontekijaAsiakas(int oikeudet, String kayttajatunnus, String salasana, String email)
        {
            MySqlCommand komento = new MySqlCommand();

            //Tallennetaan stringiin SQL kysely. Tämä voidaan myös laittaa suoraan MySqlCommandin sulkeiden sisään yhteys-funktion kanssa, niikuin ylimmässä funktiossa on tehty.
            String muokkauskysely = "UPDATE `kayttajat` SET `oikeudet` = @oik, `salasana` = @sal, `email` = @ema WHERE kayttajatunnus = @kay";

            //Asettaa Stringin SQL komennoksi komento muuttujaan
            komento.CommandText = muokkauskysely;

            //Asettaa otaYhteys funktion SQL yhteydeksi Connection komennolla  Tämä voidaan myös laittaa yhteydeksi MySqlCommandin sisään pilkun jälkeen toiseksi parametriksi
            komento.Connection = yhteys.otaYhteys();

            //Tehdään C# puolelta luettavat muuttujat, joita voidaan käyttää SQL komennossa. Huom. Normaalit C# muuttujat eivät toimi SQL komennossa.
            komento.Parameters.Add("@oik", MySqlDbType.Int32).Value = oikeudet;
            komento.Parameters.Add("@kay", MySqlDbType.VarChar).Value = kayttajatunnus;
            komento.Parameters.Add("@sal", MySqlDbType.VarChar).Value = salasana;
            komento.Parameters.Add("@ema", MySqlDbType.VarChar).Value = email;

            yhteys.avaaYhteys();

            //ExecuteNonQuerya käytetään SQL komentoihin, joilla ei palauteta dataa vaan pelkästään tallennetaan dataa tietokantaan(UPDATE,INSERT,DELETE)
            //Jos SQL-lisäyskysely onnistuu esimerkiksi päivittämään rivin tietokannnassa, palauttaa ExecuteNonQuery int-tyyppinä vaikutuksen alaisena olevien rivien määrän
            // eli kuinka monta riviä esim päivitetty tai poistettu.
            // Tässä kyseisessä komennossa rivejä palautuu aina yksi, jos on onnistuttu muuttamaan dataa. Jos yhtäkään riviä ei muutettu, palautuu numero -1
            //Alhaalla tarkistetaan onko riviä onnistuttu muuttamaan ja palautetaan joko true tai false boolean.
            if (komento.ExecuteNonQuery() == 1)
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

        public bool PoistaKayttaja(String kayttajatunnus)
        {
            MySqlCommand komento = new MySqlCommand();

            //Tallennetaan stringiin SQL kysely. Tämä voidaan myös laittaa suoraan MySqlCommandin sulkeiden sisään yhteys-funktion kanssa, niikuin ylimmässä funktiossa on tehty.
            String poistokysely = "DELETE FROM kayttajat WHERE kayttajatunnus = @kay";

            //Asettaa Stringin SQL komennoksi komento muuttujaan
            komento.CommandText = poistokysely;

            //Asettaa otaYhteys funktion SQL yhteydeksi Connection komennolla. Tämä voidaan myös laittaa yhteydeksi MySqlCommandin sisään pilkun jälkeen toiseksi parametriksi
            komento.Connection = yhteys.otaYhteys();

            //Tehdään C# puolelta luettavat muuttujat, joita voidaan käyttää SQL komennossa. Huom. Normaalit C# muuttujat eivät toimi SQL komennossa.
            komento.Parameters.Add("@kay", MySqlDbType.VarChar).Value = kayttajatunnus;

            yhteys.avaaYhteys();

            //ExecuteNonQuerya käytetään SQL komentoihin, joilla ei palauteta dataa vaan pelkästään tallennetaan dataa tietokantaan(UPDATE,INSERT,DELETE)
            //Jos SQL-lisäyskysely onnistuu esimerkiksi päivittämään rivin tietokannnassa, palauttaa ExecuteNonQuery int-tyyppinä vaikutuksen alaisena olevien rivien määrän
            // eli kuinka monta riviä esim päivitetty tai poistettu.
            // Tässä kyseisessä komennossa rivejä palautuu aina yksi, jos on onnistuttu muuttamaan dataa. Jos yhtäkään riviä ei muutettu, palautuu numero -1
            //Alhaalla tarkistetaan onko riviä onnistuttu muuttamaan ja palautetaan joko true tai false boolean.
            if (komento.ExecuteNonQuery() == 1)
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
