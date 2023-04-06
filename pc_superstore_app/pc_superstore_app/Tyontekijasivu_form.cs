using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pc_superstore_app
{
    public partial class Tyontekijasivu_form : Form
    {
        TYONTEKIJA tyontekija = new TYONTEKIJA();
        YHDISTA yhteys = new YHDISTA();
        public Tyontekijasivu_form()
        {
            InitializeComponent();
        }

        private void Tyontekijasivu_form_Load(object sender, EventArgs e)
        {
            AsiakkaatDG.DataSource = tyontekija.HaeTyontekijaAsiakkaat();
            TilauksetDG.DataSource = tyontekija.HaeTilaukset();
            VarastoDG.DataSource = tyontekija.HaeVarasto();

            OikeudetCB.ValueMember = "oikeudet";
            OikeudetCB.SelectedIndex = 0;


            PaaKategoriaCB.SelectedIndex = 0;
        }

        private void Tyontekijasivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //eri välilehtien esiin tulot
        private void AsiakkaatBT_Click(object sender, EventArgs e)
        {
            TyontekijaEtusivuPN.Visible = true;
            TilauksetPN.Visible = false;
            AsiakkaatPN.Visible = true;
            VarastoPN.Visible = false;
        }

        private void TilauksetBT_Click(object sender, EventArgs e)
        {
            TilauksetPN.Visible = true;
            AsiakkaatPN.Visible = false;
            VarastoPN.Visible = false;
        }

        private void VarastoBT_Click(object sender, EventArgs e)
        {
            TilauksetPN.Visible = false;
            AsiakkaatPN.Visible = false;
            VarastoPN.Visible = true;
        }

        //Asiakkaan tiedot tekstikenttiin celliä klikkaamalla
        private void AsiakkaatDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OikeudetCB.Text = AsiakkaatDG.CurrentRow.Cells[3].Value.ToString();
            KayttajatunnusTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[0].Value.ToString();
            SalasanaTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[1].Value.ToString();
            EmailTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[2].Value.ToString();
        }

        //lisää käyttäjä
        private void LisaaKayttajaBT_Click(object sender, EventArgs e)
        {
            int oikeudet = Convert.ToInt32(OikeudetCB.Text);
            String kayttajatunnus = KayttajatunnusTyontekijaTB.Text;
            String salasana = SalasanaTyontekijaTB.Text;
            String email = EmailTyontekijaTB.Text;

            if (kayttajatunnus.Trim().Equals("") || salasana.Trim().Equals("") || email.Trim().Equals(""))
            {
                MessageBox.Show("Täytä vaaditut kentät!");
            }
            else
            {
                
                //Try catch lisätty, jottei tyhjistä kentistä ohjelma kaadu
                try
                {
                    if (tyontekija.LisaaTyontekijaAsiakas(oikeudet, kayttajatunnus, salasana, email))
                    {
                        MessageBox.Show("Käyttäjä lisätty", "Käyttäjän lisäys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Käyttäjän lisäys epäonnistui!", "Käyttäjän lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Virhe! Käyttäjätunnus on jo käytössä.", "Käyttäjän lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            AsiakkaatDG.DataSource = tyontekija.HaeTyontekijaAsiakkaat();
        }

        //Muokkaa käyttäjää
        private void MuokkaaKayttajaBT_Click(object sender, EventArgs e)
        {
            try
            {

                int oikeudet = Convert.ToInt32(OikeudetCB.Text);
                String kayttajatunnus = KayttajatunnusTyontekijaTB.Text;
                String salasana = SalasanaTyontekijaTB.Text;
                String email = EmailTyontekijaTB.Text;

                if (tyontekija.MuokkaaTyontekijaAsiakas(oikeudet, kayttajatunnus, salasana, email))
                {
                    MessageBox.Show("Käyttäjän muokkaus onnistui", "Käyttäjän muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Käyttäjän muokkaus epäonnistui!", "Käyttäjän muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Täytä vaaditut kentät!", "Käyttäjän muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            AsiakkaatDG.DataSource = tyontekija.HaeTyontekijaAsiakkaat();
        }

        //Poista käyttäjä
        private void PoistaKayttajaBT_Click(object sender, EventArgs e)
        {
            //Try catch lisätty, jottei tyhjistä kentistä ohjelma kaadu
            try
            {
                String kayttajatunnus = KayttajatunnusTyontekijaTB.Text;
                if (tyontekija.PoistaKayttaja(kayttajatunnus))
                {
                    MessageBox.Show("Käyttäjä poistettu", "Käyttäjän poisto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Käyttäjän poistaminen epäonnistui!", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                AsiakkaatDG.DataSource = tyontekija.HaeTyontekijaAsiakkaat();
            }

            catch (Exception)
            {
                MessageBox.Show("Syötä poistettavan käyttäjän käyttäjätunnus", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Varastosta etsintä
        private void EtsiTB_TextChanged(object sender, EventArgs e)
        {
            DataTable varastoTable = tyontekija.HaeVarasto();

            VarastoDG.DataSource = varastoTable;

            String etsintaTeksti = EtsiTB.Text;

            DataView view = new DataView(varastoTable);

            view.RowFilter = string.Format("tuote LIKE '%{0}%' OR tuotekategoria LIKE '%{0}%' OR tuotetiedot LIKE '%{0}%'", etsintaTeksti);

            
            VarastoDG.DataSource = view;
        }

        //Tiedot Varastopuolen tekstikenttiin celliä klikkaamalla
        private void VarastoDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TuotekategoriaTB.Text = VarastoDG.CurrentRow.Cells[1].Value.ToString();
            TuoteTB.Text = VarastoDG.CurrentRow.Cells[0].Value.ToString();
            VarastosaldoTB.Text = VarastoDG.CurrentRow.Cells[2].Value.ToString();
            HintaTB.Text = VarastoDG.CurrentRow.Cells[3].Value.ToString();
            TuotetiedotRTB.Text = VarastoDG.CurrentRow.Cells[4].Value.ToString();

            String testi = VarastoDG.CurrentRow.Cells[1].Value.ToString();

            if (testi == "prosessorit" || testi == "näytönohjaimet" || testi == "emolevyt" || testi == "kovalevyt")
            {
                PaaKategoriaCB.SelectedIndex = 0;
            }

            if (testi == "kuulokkeet" || testi == "näppäimistöt" || testi == "kuulokkeet")
            {
                PaaKategoriaCB.SelectedIndex = 1;
            }

            if (testi == "pöytäkoneet" || testi == "kannettavat")
            {
                PaaKategoriaCB.SelectedIndex = 2;
            }
        }

        // Lisää tuote
        private void LisaaTuoteBT_Click(object sender, EventArgs e)
        {
            String paakategoria = PaaKategoriaCB.Text.ToString();
            String tuotekategoria = TuotekategoriaTB.Text.ToString();
            String tuote = TuoteTB.Text.ToString();
            String saldo = VarastosaldoTB.Text.ToString();
            String hinta = HintaTB.Text.ToString();
            String tuotetiedot = TuotetiedotRTB.Text.ToString();


            if (paakategoria.Trim().Equals("") || tuotekategoria.Trim().Equals("") || tuote.Trim().Equals("") || saldo.Trim().Equals("") || hinta.Trim().Equals("") || tuotetiedot.Trim().Equals(""))
            {
                MessageBox.Show("Täytä vaaditut kentät!");
            }
            else
            {

                //Try catch lisätty, jottei tyhjistä kentistä ohjelma kaadu
                try
                {
                    if (tyontekija.LisaaTuote(paakategoria, tuotekategoria, tuote, saldo, hinta, tuotetiedot))
                    {
                        MessageBox.Show("Tuote lisätty", "Tuotteen lisäys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tuotteen lisäys epäonnistui!", "Tuotteen lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Virhe! Tuote on jo tietokannassa", "Tuotteen lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            VarastoDG.DataSource = tyontekija.HaeVarasto();
        }

        //Muokkaa tuotetta
        private void MuokkaaTuoteBT_Click(object sender, EventArgs e)
        {
            try
            {

                String paakategoria = PaaKategoriaCB.Text.ToString();
                String tuotekategoria = TuotekategoriaTB.Text.ToString();
                String tuote = TuoteTB.Text.ToString();
                String saldo = VarastosaldoTB.Text.ToString();
                String hinta = HintaTB.Text.ToString();
                String tuotetiedot = TuotetiedotRTB.Text.ToString();

                if (tyontekija.MuokkaaTuotetta(paakategoria, tuotekategoria, tuote, saldo, hinta, tuotetiedot))
                {
                    MessageBox.Show("Tuotteen muokkaus onnistui", "Tuotteen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tuotteen muokkaus epäonnistui!", "Tuotteen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Täytä vaaditut kentät!", "Tuotteen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            VarastoDG.DataSource = tyontekija.HaeVarasto();
        }

        //poista tuote
        private void PoistaTuoteBT_Click(object sender, EventArgs e)
        {
            //Try catch lisätty, jottei tyhjistä kentistä ohjelma kaadu
            try
            {
                String paakategoria = PaaKategoriaCB.Text.ToString();
                String tuote = TuoteTB.Text.ToString();
                if (tyontekija.PoistaTuote(paakategoria, tuote))
                {
                    MessageBox.Show("Tuote poistettu", "Tuotteen poisto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tuotteen poistaminen epäonnistui!", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                VarastoDG.DataSource = tyontekija.HaeVarasto();
            }

            catch (Exception)
            {
                MessageBox.Show("Syötä poistettavan tuotteen nimi", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //tilauksen tiedot tekstikenttiin klikkaamalla celliä
        private void TilauksetDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TilausnumeroTB.Text = TilauksetDG.CurrentRow.Cells[0].Value.ToString();
            TilausEtunimiTB.Text = TilauksetDG.CurrentRow.Cells[1].Value.ToString();
            TilausSukunimiTB.Text = TilauksetDG.CurrentRow.Cells[2].Value.ToString();
            TilausPuhTB.Text = TilauksetDG.CurrentRow.Cells[3].Value.ToString();
            TilausEmailTB.Text = TilauksetDG.CurrentRow.Cells[4].Value.ToString();
            TilausKatuosoiteTB.Text = TilauksetDG.CurrentRow.Cells[5].Value.ToString();
            TilausPnumTB.Text = TilauksetDG.CurrentRow.Cells[6].Value.ToString();
            TilatutTuotteetRTB.Text = TilauksetDG.CurrentRow.Cells[7].Value.ToString();

            
        }

        //poista tilaus
        private void PoistaTilausBT_Click(object sender, EventArgs e)
        {
            //Try catch lisätty, jottei tyhjistä kentistä ohjelma kaadu
            try
            {
                String tilausnumero = TilausnumeroTB.Text.ToString();
                if (tyontekija.PoistaTilaus(tilausnumero))
                {
                    MessageBox.Show("Tilaus poistettu", "Tilauksen poisto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tilauksen poistaminen epäonnistui!", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TilauksetDG.DataSource = tyontekija.HaeTilaukset();
            }

            catch (Exception)
            {
                MessageBox.Show("Syötä poistettavan tilauksen tilausnumero", "Virhe!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //muokkaa tilausta
        private void MuokkaaTilausBT_Click(object sender, EventArgs e)
        {
            try
            {

                String tilausnumero = TilausnumeroTB.Text.ToString();
                String etunimi = TilausEtunimiTB.Text.ToString();
                String sukunimi = TilausSukunimiTB.Text.ToString();
                String puhelin = TilausPuhTB.Text.ToString();
                String email = TilausEmailTB.Text.ToString();
                String katuosoite = TilausKatuosoiteTB.Text.ToString();
                String postinumero = TilausPnumTB.Text.ToString();
                String tilaus = TilatutTuotteetRTB.Text.ToString();

                if (tyontekija.MuokkaaTilausta(tilausnumero, etunimi, sukunimi, puhelin, email, katuosoite, postinumero, tilaus))
                {
                    MessageBox.Show("Tilauksen muokkaus onnistui", "Tilauksen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tilauksen muokkaus epäonnistui!", "Tilauksen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Täytä vaaditut kentät!", "Tilauksen muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            TilauksetDG.DataSource = tyontekija.HaeTilaukset();
        }

        //Tilauksistä etsintä
        private void TilauksetEtsiTB_TextChanged(object sender, EventArgs e)
        {
            DataTable tilausTable = tyontekija.HaeTilaukset();

            TilauksetDG.DataSource = tilausTable;

            String etsintaTeksti = TilauksetEtsiTB.Text.ToString();

            DataView view = new DataView(tilausTable);

            //pystytäänkö etsintatekstiä parseemaan intiksi tilausnumerolla hakua varten?
            if (int.TryParse(etsintaTeksti, out int etsintaNumero))
            {
                view.RowFilter = string.Format("tilausnro = {0}", etsintaNumero);
            }
            //jos ei pystytä, etsitään stringinä
            else
            {
                view.RowFilter = string.Format("etunimi LIKE '%{0}%' OR sukunimi LIKE '%{0}%' OR puhelin LIKE '%{0}%' OR sähköposti LIKE '%{0}%' OR katuosoite LIKE '%{0}%' OR postinumero LIKE '%{0}%' OR tilaus LIKE '%{0}%'", etsintaTeksti);
            }

            TilauksetDG.DataSource = view;
        }

        private void NaytaTyontekijatBT_Click(object sender, EventArgs e)
        {
            DataTable tyontekijat = (DataTable)tyontekija.HaeTyontekijaAsiakkaat();

            DataView tyontekijat2 = tyontekijat.DefaultView;

            tyontekijat2.RowFilter = "oikeudet = 1";

            AsiakkaatDG.DataSource = tyontekijat2;
        }

        private void NaytaAsiakkaatBT_Click(object sender, EventArgs e)
        {
            DataTable asiakkaat = (DataTable)tyontekija.HaeTyontekijaAsiakkaat();

            DataView asiakkaat2 = asiakkaat.DefaultView;

            asiakkaat2.RowFilter = "oikeudet = 2";

            AsiakkaatDG.DataSource = asiakkaat2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            DataTable kayttajat = tyontekija.HaeTyontekijaAsiakkaat();

            AsiakkaatDG.DataSource = kayttajat;

            String etsintaTeksti = KayttajatEtsiTB.Text.ToString();

            DataView view = new DataView(kayttajat);

            view.RowFilter = string.Format("kayttajatunnus LIKE '%{0}%' OR email LIKE '%{0}%'", etsintaTeksti);


            AsiakkaatDG.DataSource = view;
        }

        private void TyontekjiaKirjauduUlosBT_Click(object sender, EventArgs e)
        {
            

            Sisaankirjautuminen_form sisaankirjautuminen = new Sisaankirjautuminen_form();
            sisaankirjautuminen.Show();

            this.Hide();
        }
    }
}
