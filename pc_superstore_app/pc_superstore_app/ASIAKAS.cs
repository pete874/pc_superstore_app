﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pc_superstore_app
{
    // Luodaan uusi classi asiakkaiden hallintaa varten
    class ASIAKAS
    {
        // Tehdään uusi esiintymä yhdistä-classista
        YHDISTA yhteys = new YHDISTA();

        // Tällä metodilla haetaan tallennetut henkilöt tietokannasta
        public DataTable HaeAsiakkaat()
        {
            MySqlCommand haeKaikki = new MySqlCommand("SELECT kayttajatunnus, salasana, oikeudet FROM kayttajat", yhteys.otaYhteys());


            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable taulukko = new DataTable();

            adapter.SelectCommand = haeKaikki;
            adapter.Fill(taulukko);

            

            return taulukko;

        }

        // Tällä metodilla lisätään uusi asiakas rekisteröitymis- formissa
        // Lisätään metodiin tarvittavat muuttujat (kirjautumistunnukset, email)
        // Luodaan Sql-komento INSERT INTO johon lisätään @-parametrit
        // avataan yhteys
        // suljetaan yhteys
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

        // Tätä metodia kutsutaan henkilön kirjautuessa palveluun        
        // Lisätään metodiin tarvittavat muuttujat (tunnus, salasana)
        // Luodaan Sql-komento SELECT johon lisätään @-parametrit
        // avataan yhteys
        // suljetaan yhteys
        public int KirjautumisenTarkastus(String kayttajatunnus, String salasana)
        {
            MySqlCommand kayttajakomento = new MySqlCommand("SELECT oikeudet FROM kayttajat WHERE kayttajatunnus = @ktu AND salasana = @sal", yhteys.otaYhteys());


            kayttajakomento.Parameters.AddWithValue("@ktu", kayttajatunnus);
            kayttajakomento.Parameters.AddWithValue("@sal", salasana);
            kayttajakomento.Connection = yhteys.otaYhteys();

            yhteys.avaaYhteys();
            int result = Convert.ToInt32(kayttajakomento.ExecuteScalar());                       
            int oikeudet = result;
            yhteys.suljeYhteys();

            if (oikeudet == 1) // työntekijä
            {
                // Ohjataan työntekijöiden sivulle
                return 1;
                
            }
            else if(oikeudet == 2)
            {
                // Ohjataan asiakassivulle
                return 2;
            }
            else
            {
                
                return 3;
            }
            
        }

        // Seuraavaa metodia kutsutaan tilauksen lähettämisen yhteydessä
        // Lisätään metodiin tarvittavat muuttujat (henkilötiedot, tilattavat tuotteet)
        // Luodaan Sql-komento johon lisätään @-parametrit
        // avataan yhteys
        // suljetaan yhteys
        public bool LisaaTilaus(String etunimi, String sukunimi, String puhelin, String sahkoposti, String katuosoite, String postinumero, String tuotteet)
        {
            MySqlCommand tilauslisays = new MySqlCommand("INSERT INTO tilaukset (etunimi, sukunimi, puhelin, sähköposti, katuosoite, postinumero, tilaus) VALUES (@enm, @snm, @puh, @ema, @oso, @pnu, @tuo)", yhteys.otaYhteys());
            
            tilauslisays.Parameters.AddWithValue("@enm", etunimi);
            tilauslisays.Parameters.AddWithValue("@snm", sukunimi);
            tilauslisays.Parameters.AddWithValue("@puh", puhelin);
            tilauslisays.Parameters.AddWithValue("@ema", sahkoposti);
            tilauslisays.Parameters.AddWithValue("@oso", katuosoite);
            tilauslisays.Parameters.AddWithValue("@pnu", postinumero);
            tilauslisays.Parameters.AddWithValue("@tuo", tuotteet);

            yhteys.avaaYhteys();

            if (tilauslisays.ExecuteNonQuery() == 1)
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
