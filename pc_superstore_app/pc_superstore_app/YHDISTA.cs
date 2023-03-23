using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pc_superstore_app
{
    internal class YHDISTA
    {
        private MySqlConnection yhteys = new MySqlConnection("datasource = localhost; port = 3306; username = root; password; database = pc_superstore; convert zero datetime=True");

        public MySqlConnection otaYhteys()
        { 
            return yhteys; 
        }
        
        public void avaaYhteys()
        {
            if (yhteys.State == ConnectionState.Closed)
            {
                yhteys.Open();
            }
        }

        public void suljeYhteys()
        {
            if (yhteys.State == ConnectionState.Open) 
            {
                yhteys.Close();
            }
        }
    }
}
