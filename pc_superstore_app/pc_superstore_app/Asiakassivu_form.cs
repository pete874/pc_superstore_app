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
    public partial class Asiakassivu_form : Form
    {
        YHDISTA yhteys = new YHDISTA();
        TUOTTEET tuotteet = new TUOTTEET();
        public Asiakassivu_form()
        {
            InitializeComponent();
        }

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


        // Tuotteiden lisäykset
        // Luodaan muuttuja loppusummalle
        public int loppusumma = 0;
       
        // Tietokonepakettien lisäys. Haetaan Ostoskorin datagridiin vain tuotteen nimi ja hinta
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
        }

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
        private void PoistaTuoteBT_Click(object sender, EventArgs e)
        {
             if (OstoskoriDG.SelectedRows.Count > 0)
             {
                //Loopataan läpi valitut rivit
                 foreach (DataGridViewRow row in OstoskoriDG.SelectedRows)
                 {
                   OstoskoriDG.Rows.Remove(row);
                 }

             }
        }
    }
}
