﻿using System;
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
    public partial class Tyontekijasivu_form : Form
    {
        public Tyontekijasivu_form()
        {
            InitializeComponent();
        }

        private void Tyontekijasivu_form_Load(object sender, EventArgs e)
        {

        }

        private void Tyontekijasivu_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}