﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace pc_superstore_app
{
    public partial class Asiakassivu_form : Form
    {
        // luodaan heti alkuun uudet esiintymät yhdistä, tuotteet ja asiakas- classeista

        YHDISTA yhteys = new YHDISTA();
        TUOTTEET tuotteet = new TUOTTEET();
        ASIAKAS asiakas = new ASIAKAS();
        public Asiakassivu_form()
        {
            InitializeComponent();
        }

        // Form-loadissa määritellään, mikä paneeli näytetään ja mitkä paneelit pidetään piilotettuina
        // Lisätään Ostoskori datagridiin kaksi saraketta: tuote ja hinta
        private void Asiakassivu_form_Load(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = true;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
            OstoskoriPN.Visible = false;
            SummatekstiLB.Visible = false;
            SummaLB.Visible = false;

            OstoskoriDG.Columns.Add("tuote", "tuote");
            OstoskoriDG.Columns.Add("hinta", "hinta");



        }    

        private void Asiakassivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void EtusivuLB_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = true;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
            OstoskoriPN.Visible = false;
            SummatekstiLB.Visible = false;
            SummaLB.Visible = false;
        }

        // Tietokoneet- välilehden avautuessa haetaan kyseiseen datagridiin tietokannasta myynnissä olevat tietokoneet
        // tuotetiedot piilotetaan 
        private void TietokoneetBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = true;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
            OstoskoriPN.Visible = false;
            SummatekstiLB.Visible = false;
            SummaLB.Visible = false;

            TietokoneetDG.DataSource = tuotteet.HaeTietokoneet();
            TietokoneetDG.Columns["tuotetiedot"].Visible = false;
        }

        // Samat toimenpiteet tehdään myös klikattaessa komponentit- ja oheistuotteet-välilehtiä
        private void KomponentitBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = true;
            OheistuotteetPN.Visible = false;
            OstoskoriPN.Visible = false;
            SummatekstiLB.Visible = false;
            SummaLB.Visible = false;

            KomponentitDG.DataSource = tuotteet.HaeKomponentit();
            KomponentitDG.Columns["tuotetiedot"].Visible = false;
        }

        private void OheistuotteetBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = true;
            OstoskoriPN.Visible = false;
            SummatekstiLB.Visible = false;
            SummaLB.Visible = false;

            OheistuotteetDG.DataSource = tuotteet.HaeOheistuotteet();
            OheistuotteetDG.Columns["tuotetiedot"].Visible = false;
        }

        // Itse tuotetta klikattaessa haetaan rich text boxiin tuotteen tiedot
        private void TietokoneetDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TietokoneetRTB.Text = TietokoneetDG.CurrentRow.Cells[4].Value.ToString();
        }

        private void KomponentitDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KomponentitRTB.Text = KomponentitDG.CurrentRow.Cells[4].Value.ToString();
        }

        private void OheistuotteetDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OheistuotteetRTB.Text = OheistuotteetDG.CurrentRow.Cells[4].Value.ToString();
        }

        // Luodaan muuttuja loppusummalle
        // Tuotteiden lisäykset
        public int loppusumma = 0;
        public int kappalemaara = 0;
       
        // Tietokonepakettien lisäys ostoskoriin. Haetaan Ostoskorin datagridiin vain tuotteen nimi ja hinta. Lopuksi tehdään ostoskorin yhteishinnan ja kappalemäärän lisäys, joka näkyy footerissa.
        private void LisaaTietokoneetBT_Click(object sender, EventArgs e)
        {

            String tuote = TietokoneetDG.CurrentRow.Cells[0].Value.ToString();
            String hinta = TietokoneetDG.CurrentRow.Cells[2].Value.ToString();
            int summahinta = Convert.ToInt32(hinta);

            OstoskoriMaaraLB.Text = OstoskoriDG.RowCount.ToString();

            OstoskoriDG.Rows.Add(tuote, hinta);

            
            loppusumma += summahinta;
            MessageBox.Show(tuote + " lisätty ostoskoriin.");
            SummaLB.Text = loppusumma.ToString() + " €";

            kappalemaara++;
        }

        // Komponenttien lisäys
        private void LisaaKomponentitBT_Click(object sender, EventArgs e)
        {
            String tuote = KomponentitDG.CurrentRow.Cells[0].Value.ToString();
            String hinta = KomponentitDG.CurrentRow.Cells[2].Value.ToString();
            int summahinta = Convert.ToInt32(hinta);

            OstoskoriMaaraLB.Text = OstoskoriDG.RowCount.ToString();

            OstoskoriDG.Rows.Add(tuote, hinta);

            loppusumma += summahinta;
            MessageBox.Show(tuote + " lisätty ostoskoriin.");
            SummaLB.Text = loppusumma.ToString() + " €";

            kappalemaara++;
        }

        // Oheistuotteiden lisäys

        private void LisaaOheistuotteetBT_Click(object sender, EventArgs e)
        {
            String tuote = OheistuotteetDG.CurrentRow.Cells[0].Value.ToString();
            String hinta = OheistuotteetDG.CurrentRow.Cells[2].Value.ToString();
            int summahinta = Convert.ToInt32(hinta);

            OstoskoriMaaraLB.Text = OstoskoriDG.RowCount.ToString();

            OstoskoriDG.Rows.Add(tuote, hinta);

            loppusumma += summahinta;
            MessageBox.Show(tuote + " lisätty ostoskoriin.");
            SummaLB.Text = loppusumma.ToString() + " €";

            kappalemaara++;
        }

        // -- Ostoskorin toiminnot --
        private void OstoskoriBT_Click(object sender, EventArgs e)
        {
            EtusivuAsiakasPN.Visible = false;
            TietokoneetPN.Visible = false;
            KomponentitPN.Visible = false;
            OheistuotteetPN.Visible = false;
            OstoskoriPN.Visible = true;
            SummatekstiLB.Visible = true;
            SummaLB.Visible = true;
        }

        // Asiakas voi poistaa tuotteen klikkaamalla haluttua riviä ja painamalla poista-nappia
        // Luodaan poistettavalle hinnalle muuttuja
        // Jos valittuja rivejä on enemmän kuin 0, loopataan rivit läpi
        // Tässä joutuu jostain syystä luomaan ensin string-muuttujan tuotehinnalle, jonka jälkeen se konvertoidaan int-muuttujaan.
        // Poistetaan valittu rivi datagridistä
        // vähennetään kappalemäärästä 1 ja loppusummasta poistettava hinta

        private void PoistaTuoteBT_Click(object sender, EventArgs e)
        {
            int poistahinta = 0;
            

            

            if (OstoskoriDG.SelectedRows.Count > 0)
             {
                OstoskoriMaaraLB.Text = OstoskoriDG.RowCount.ToString();
                //Loopataan läpi valitut rivit
                foreach (DataGridViewRow row in OstoskoriDG.SelectedRows)
                 {
                    String tuotehinta = Convert.ToString(OstoskoriDG.SelectedCells[1].Value);
                    int tuotehinta2 = Convert.ToInt32(tuotehinta);

                    OstoskoriDG.Rows.Remove(row);

                    poistahinta += tuotehinta2;

                    kappalemaara--;

                }

                loppusumma -= poistahinta;
                
     
             }
            
            SummaLB.Text = loppusumma.ToString();
            OstoskoriMaaraLB.Text = kappalemaara.ToString();
            
        }

        // Tilauksen lähetyksessä luodaan muuttujat textboxeille, sekä erillinen muuttuja tuotteille
        // Loopataan datagridin rivit ja lisätään tuotteen nimi tuotteet-muuttujaan
        // Tehdään tekstikenttätarkistus(ei tyhjiä kenttiä)
        // Jos kentät täytetty oikein, kutsutaan LisaaTilaus metodia ASIAKAS-classista 
        private void LahetaTilausBT_Click(object sender, EventArgs e)
        {
            String etunimi = EtunimiTB.Text;
            String sukunimi = SukunimiTB.Text;
            String puhelin  = PuhelinTB.Text;
            String sahkoposti = EmailTB.Text;
            String katuosoite = OsoiteTB.Text;
            String postinumero = PnumTB.Text;
            String tuotteet = "";

            for (int i = 0; i < OstoskoriDG.Rows.Count; i++)
            {
                tuotteet += OstoskoriDG.Rows[i].Cells["tuote"].Value + "\n";
            }
            
            //Tarkistetaan että tekstikentät eivät ole tyhjiä
            if (etunimi.Trim().Equals("") || sukunimi.Trim().Equals("") || puhelin.Trim().Equals("") || katuosoite.Trim().Equals("") || postinumero.Trim().Equals("") || sahkoposti.Trim().Equals("") || tuotteet.Trim().Equals(""))
            {
                MessageBox.Show("Täytä kaikki kentät", "Virhe syötössä", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean lisaaTilaus = asiakas.LisaaTilaus(etunimi, sukunimi, puhelin, sahkoposti, katuosoite, postinumero, tuotteet);

                if (lisaaTilaus)
                {
                    MessageBox.Show("Uusi tilaus lisätty!", "Tilaus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EtunimiTB.Text = "";
                    SukunimiTB.Text = "";
                    PuhelinTB.Text = "";
                    EmailTB.Text = "";
                    OsoiteTB.Text = "";
                    PnumTB.Text = "";
                    tuotteet = "";
                    loppusumma = 0;
                    SummaLB.Text = loppusumma.ToString();
                    kappalemaara = 0;
                    OstoskoriMaaraLB.Text = kappalemaara.ToString();
                    OstoskoriDG.Rows.Clear();

                }
                else
                {
                    MessageBox.Show("Virhe! Tilausta ei pystytty lähettämään");
                }
            }
        }
    }
}
