using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Samples.Aspnet;
using Library.Converter;
using Library.Configuration;

namespace Forms.Opcoes
{
    public partial class Opcoes : Form
    {
        public Opcoes()
        {
            InitializeComponent();
        }


        private void Opcoes_Load(object sender, EventArgs e)
        {
            Refreshs();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            DSettings set = new DSettings();

            set.textBoxNotificacao1 = this.textBoxNotificacao1.Text.ConvertToInt();
            set.textBoxNotificacao2 = this.textBoxNotificacao2.Text.ConvertToInt();
            set.textBoxNotificacao3 = this.textBoxNotificacao3.Text.ConvertToInt();

            DAppSettings.Save(set);

            Refreshs();

            Forms.OpenForm.RefreshNotificacoes();
        }


        private void Refreshs()
        {
            DSettings set = new DSettings();

            DAppSettings.Load(set);

            this.textBoxNotificacao1.Text = set.textBoxNotificacao1.ToString();
            this.textBoxNotificacao2.Text = set.textBoxNotificacao2.ToString();
            this.textBoxNotificacao3.Text = set.textBoxNotificacao3.ToString();
        }

        private void Opcoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Forms.OpenForm.RefreshNotificacoes();
        }
    }
}
