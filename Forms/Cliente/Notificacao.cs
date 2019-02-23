using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.Cliente
{
    public partial class Notificacao : Form
    {
        public Library.Cliente cliente { get; set; }

        public Notificacao()
        {
            InitializeComponent();
        }

        
        // /////////

        private void Notificacao_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();

            Atualizar();
            
        }


        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCliente();
            Atualizar();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Atualizar();
        }


        private void buttonNotificacao1_Click(object sender, EventArgs e)
        {
            if (cliente.Notificacao == 0)
            {
                Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                notificacao.cliente = cliente;
                notificacao.notificacao = 1;
                notificacao.ShowDialog(this);
                Atualizar();
            }
            else
            {
                MessageBox.Show("Erro desconhecido.");
            }
        }

        private void buttonNotificacao2_Click(object sender, EventArgs e)
        {
            if (cliente.Notificacao == 1)
            {
                Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                notificacao.cliente = cliente;
                notificacao.notificacao = 2;
                notificacao.ShowDialog(this);
                Atualizar();
            }
            else
            {
                MessageBox.Show("Você deve mandar as notificações anteriores.");
            }
        }

        private void buttonNotificacao3_Click(object sender, EventArgs e)
        {
            if (cliente.Notificacao == 2)
            {
                Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                notificacao.cliente = cliente;
                notificacao.notificacao = 3;
                notificacao.ShowDialog(this);
                Atualizar();
            }
            else
            {
                MessageBox.Show("Você deve mandar as notificações anteriores.");
            }
        }


        private void buttonReimprimir_Click(object sender, EventArgs e)
        {
            Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
            notificacao.cliente = cliente;
            notificacao.notificacao = 300;
            notificacao.ShowDialog(this);
            Atualizar();
        }



        // /////////

        public void FillEmpresa()
        {
            comboBoxEmpresa.DisplayMember = "nome";
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DataSource = Library.EmpresaBD.FindAdvanced();
        }

        public void FillCliente()
        {
            comboBoxCliente.DisplayMember = "nome";
            comboBoxCliente.ValueMember = "id";
            comboBoxCliente.DataSource = Library.ClienteBD.FindAdvanced(new Library.Classes.QItem("e.id", comboBoxEmpresa.SelectedValue));
        }

        public void Atualizar()
        {
            if (cliente != null)
            {
                switch (cliente.Notificacao)
                {
                    case 0:
                        buttonNotificacao1.Enabled = true;
                        buttonNotificacao2.Enabled = true;
                        buttonNotificacao3.Enabled = true;
                        break;
                    case 1:
                        buttonNotificacao1.Enabled = false;
                        buttonNotificacao2.Enabled = true;
                        buttonNotificacao3.Enabled = true;
                        break;
                    case 2:
                        buttonNotificacao1.Enabled = false;
                        buttonNotificacao2.Enabled = false;
                        buttonNotificacao3.Enabled = true;
                        break;
                    case 3:
                        buttonNotificacao1.Enabled = false;
                        buttonNotificacao2.Enabled = false;
                        buttonNotificacao3.Enabled = false;
                        break;
                }



                DateTime dn1 = cliente.DataNotificacao1.GetValueOrDefault(DateTime.MinValue);
                DateTime dn2 = cliente.DataNotificacao2.GetValueOrDefault(DateTime.MinValue);
                DateTime dn3 = cliente.DataNotificacao3.GetValueOrDefault(DateTime.MinValue);


                if (dn1 != DateTime.MinValue)
                    labelNotificacao1.Text = dn1.ToString("dd/MM/yyyy");
                else
                    labelNotificacao1.Text = "";

                if (dn2 != DateTime.MinValue)
                    labelNotificacao2.Text = dn2.ToString("dd/MM/yyyy");
                else
                    labelNotificacao2.Text = "";

                if (dn3 != DateTime.MinValue)
                    labelNotificacao3.Text = dn3.ToString("dd/MM/yyyy");
                else
                    labelNotificacao3.Text = "";
            }
        }
    }
}
