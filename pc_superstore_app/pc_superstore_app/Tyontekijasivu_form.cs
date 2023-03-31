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
        }

        private void Tyontekijasivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

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

        private void AsiakkaatDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OikeudetCB.Text = AsiakkaatDG.CurrentRow.Cells[3].Value.ToString();
            KayttajatunnusTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[0].Value.ToString();
            SalasanaTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[1].Value.ToString();
            EmailTyontekijaTB.Text = AsiakkaatDG.CurrentRow.Cells[2].Value.ToString();
        }

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


        private void EtsiTB_TextChanged(object sender, EventArgs e)
        {
            DataTable varastoTable = tyontekija.HaeVarasto();

            VarastoDG.DataSource = varastoTable;

            String etsintaTeksti = EtsiTB.Text;

            DataView view = new DataView(varastoTable);

            view.RowFilter = string.Format("tuote LIKE '%{0}%' OR tuotekategoria LIKE '%{0}%' OR tuotetiedot LIKE '%{0}%'", etsintaTeksti);

            // Set the DataView as the DataSource of the DataGridView control
            VarastoDG.DataSource = view;
        }
    }
}
