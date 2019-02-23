using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Forms.TermoCompromisso
{
    public partial class ChangeText : Form
    {
        public string Texto { get; set; }


        public ChangeText()
        {
            DateTime hoje = DateTime.Now;
            CultureInfo culture = new CultureInfo("pt-BR");


            InitializeComponent();

            this.textBox1.Text = "O Escritório Jurídico Dr. Tiago Browne Ferreira, localizado na Avenida Carvalho, Nº 320, Bairro - Santa Tereza, na cidade de Miracema - RJ, vem por meio desta, solicitar o comparecimento de Vossa Senhoria, com intuito de obter uma solução amigável para o problema." + Environment.NewLine + Environment.NewLine +//VbCrLf + VbCrLf
                            "Certos de que seremos prontamente atendidos, desde já agradecemos. " + Environment.NewLine + Environment.NewLine + Environment.NewLine + //VbCrLf+VbCrLf+VbCrLf +                            
                            "Sem mais para o momento, Miracema," + hoje.ToString("dddd", culture) + " " + hoje.Day.ToString() + " de " + hoje.ToString("MMMM", culture) + " de " + hoje.Year.ToString() + ". " + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + //VbCrLf+VbCrLf+VbCrLf+VbCrLf+VbCrLf+VbCrLf +
                            "OBS: Favor entrar em contato, sob pena da adoção das medidas judiciais cabíveis.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Texto = textBox1.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ChangeText_Load(object sender, EventArgs e)
        {

        }
    }
}
