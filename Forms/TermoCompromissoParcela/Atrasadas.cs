using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.TermoCompromissoParcela
{
    public partial class Atrasadas : Form
    {
        public Atrasadas()
        {
            InitializeComponent();
        }

        private void Atrasadas_Load(object sender, EventArgs e)
        {
            Carregar();
        }
        public void Carregar()
        {

            dataGridView1.Rows.Clear();
            foreach (Library.Cliente c in Library.ClienteBD.FindAdvanced())
            {
                foreach (Library.TermoCompromissoParcela tcp in Library.ClienteBD.GetParcelasAtrasadasById(c.Id))
                {
                    dataGridView1.Rows.Add(tcp.TermoCompromisso.Cliente.Nome,tcp.TermoCompromisso.Empresa.Nome,tcp.Valor,tcp.Data);
                }
            }

        }
    }
}
