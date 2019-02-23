using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.TermoCompromisso
{
    public partial class stepbystep : Form
    {

        public stepbystep()
        {
            InitializeComponent();
        }


        private void stepbystep_Load(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenVincularTermosCompromissoView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenNotificacaoView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenTermoCompromissoView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenJudicialView();
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::Forms.Properties.Resources.hover;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackgroundImage = global::Forms.Properties.Resources.normal;
        }

    }
}
