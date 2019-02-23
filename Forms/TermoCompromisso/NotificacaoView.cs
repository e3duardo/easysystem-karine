using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;
using Library;

namespace Forms.TermoCompromisso
{
    public partial class NotificacaoView : Form
    {
        public List<Library.TermoCompromisso> termos
        {
            get
            {

                Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;
                Library.Empresa empresa = (Library.Empresa)comboBoxEmpresa.SelectedItem;

                List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced(new QItem("e.id", empresa.Id), new QItem("c.id", cliente.Id));

                return termos;

            }
            set
            {
                this.termos = value;
            }
        }

        public Library.TermoCompromisso TermoCompromisso
        {
            get
            {
                if (this.termos.Count >= 1)
                {
                    return this.termos[0];
                }
                return null;
            }
            set
            {
                this.TermoCompromisso = value;
            }
        }

        public List<Library.Notificacao> notificacoes
        {
            get
            {
                List<Library.Notificacao> notificacoes = Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", TermoCompromisso.Id));
                return notificacoes;
            }
        }

        public Library.Cliente cliente { get; set; }

        public NotificacaoView()
        {
            InitializeComponent();
        }


        // /////////

        private void Notificacao_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();

            if (this.cliente == null)
                ShowValues();
            //else
            //ShowValues(this.cliente);
            comboBoxEmpresa.SelectedIndex = -1;
        }


        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCliente();
            ShowValues();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.TermoCompromisso != null)
            {
                ShowValues(this.TermoCompromisso);
            }
        }


        private void buttonNotificacao1_Click(object sender, EventArgs e)
        {
            Forms.TermoCompromisso.ChangeText ct = new Forms.TermoCompromisso.ChangeText();

            if (ct.ShowDialog(this) == DialogResult.OK)
            {
                if (this.notificacoes.Count == 0)//cliente.Notificacao == 0)
                {
                    Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                    notificacao.cliente = this.TermoCompromisso.Cliente;
                    notificacao.Texto = ct.Texto;

                    if (notificacao.ShowDialog(this) == DialogResult.Yes)
                    {
                        Library.NotificacaoBD.Save(NovaNotificacao(ct.Texto));

                        Library.TermoCompromisso termo = this.TermoCompromisso;
                        termo.Status = (int)Library.TCStatus.notificando;
                        Library.TermoCompromissoBD.Update(termo);

                        Forms.OpenForm.RefreshNotificacoes();
                    }
                    ShowValues(this.TermoCompromisso);
                }
                else
                {
                    MessageBox.Show("Erro desconhecido.");
                }
            }
        }

        private void buttonNotificacao2_Click(object sender, EventArgs e)
        {
            Forms.TermoCompromisso.ChangeText ct = new Forms.TermoCompromisso.ChangeText();

            if (ct.ShowDialog(this) == DialogResult.OK)
            {
                if (this.notificacoes.Count == 1)//cliente.Notificacao == 1)
                {
                    Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                    notificacao.cliente = this.TermoCompromisso.Cliente;
                    notificacao.Texto = ct.Texto;

                    if (notificacao.ShowDialog(this) == DialogResult.Yes)
                    {
                        Library.NotificacaoBD.Save(NovaNotificacao(ct.Texto));

                        Library.TermoCompromisso termo = this.TermoCompromisso;
                        termo.Status = (int)Library.TCStatus.notificando;
                        Library.TermoCompromissoBD.Update(termo);

                        Forms.OpenForm.RefreshNotificacoes();
                    }
                    ShowValues(this.TermoCompromisso);
                }
                else
                {
                    MessageBox.Show("Você deve imprimir as notificações anteriores.");
                }
            }
        }

        private void buttonNotificacao3_Click(object sender, EventArgs e)
        {
            Forms.TermoCompromisso.ChangeText ct = new Forms.TermoCompromisso.ChangeText();

            if (ct.ShowDialog(this) == DialogResult.OK)
            {
                if (this.notificacoes.Count == 2)//cliente.Notificacao == 2)
                {
                    Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                    notificacao.cliente = this.TermoCompromisso.Cliente;
                    notificacao.Texto = ct.Texto;

                    if (notificacao.ShowDialog(this) == DialogResult.Yes)
                    {
                        Library.NotificacaoBD.Save(NovaNotificacao(ct.Texto));

                        Library.TermoCompromisso termo = this.TermoCompromisso;
                        termo.Status = (int)Library.TCStatus.notificando;
                        Library.TermoCompromissoBD.Update(termo);

                        Forms.OpenForm.RefreshNotificacoes();
                    }
                    ShowValues(this.TermoCompromisso);
                }
                else
                {
                    MessageBox.Show("Você deve imprimir as notificações anteriores.");
                }
            }
        }


        private void buttonReimprimir_Click(object sender, EventArgs e)
        {
            Forms.TermoCompromisso.ChangeText ct = new Forms.TermoCompromisso.ChangeText();

            if (ct.ShowDialog(this) == DialogResult.OK)
            {
                Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                notificacao.cliente = this.TermoCompromisso.Cliente;
                notificacao.Texto = ct.Texto;

                notificacao.ShowDialog(this);
            }
        }

        private Library.Notificacao NovaNotificacao(string texto)
        {
            Library.Notificacao notificacao = new Library.Notificacao();
            notificacao.Data = DateTime.Now;
            notificacao.Texto = texto;
            notificacao.TermoCompromisso = this.TermoCompromisso;
            return notificacao;
        }

        // /////////

        public void FillEmpresa()
        {
            comboBoxEmpresa.DisplayMember = "nome";
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DataSource = Library.TermoCompromissoBD.FindEmpresasDistinct();
            //comboBoxEmpresa.Sorted = true;
        }

        public void FillCliente()
        {
            try
            {
                if (comboBoxEmpresa.SelectedIndex != -1)
                {
                    comboBoxCliente.Text = "";

                    Library.Empresa empresa = (Library.Empresa)comboBoxEmpresa.SelectedItem;

                    comboBoxCliente.DisplayMember = "nome";
                    comboBoxCliente.ValueMember = "id";

                    comboBoxCliente.Items.Clear();
                    foreach (Library.TermoCompromisso tc in Library.TermoCompromissoBD.FindAdvanced(new QItem("e.id", empresa.Id), new QItem("ORDER BY", "c.nome")))
                    {
                        if (tc.Status == (int)TCStatus.aberto || tc.Status == (int)TCStatus.notificando)
                        {
                            comboBoxCliente.Items.Add(tc.Cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void ShowValues(Library.TermoCompromisso termoCompromisso)
        {
            List<Library.Notificacao> notificacoes = Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", termoCompromisso.Id));

            switch (notificacoes.Count)
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

            labelNotificacao1.Text = "";
            labelNotificacao2.Text = "";
            labelNotificacao3.Text = "";

            if (notificacoes.Count >= 1)
            {
                DateTime dn1 = notificacoes[0].Data;
                if (dn1 > DateTime.MinValue)
                    labelNotificacao1.Text = dn1.ToString("dd/MM/yyyy");
                else
                    labelNotificacao1.Text = "";
            }

            if (notificacoes.Count >= 2)
            {
                DateTime dn2 = notificacoes[1].Data;
                if (dn2 > DateTime.MinValue)
                    labelNotificacao2.Text = dn2.ToString("dd/MM/yyyy");
                else
                    labelNotificacao2.Text = "";
            }

            if (notificacoes.Count >= 3)
            {
                DateTime dn3 = notificacoes[2].Data;
                if (dn3 > DateTime.MinValue)
                    labelNotificacao3.Text = dn3.ToString("dd/MM/yyyy");
                else
                    labelNotificacao3.Text = "";
            }


            buttonReimprimir.Enabled = true;



            string stat = "";
            if (termoCompromisso.Status == (int)TCStatus.aberto)
                stat = "Vinculado";
            else if (termoCompromisso.Status == (int)TCStatus.notificando)
            {
                stat = string.Format("Nodificado ({0})", Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", termoCompromisso.Id)).Count);
            }


            textBoxData.Text = termoCompromisso.Data.ToShortDateString();
            textBoxStatus.Text = stat;
        }

        public void ShowValues()
        {
            buttonNotificacao1.Enabled = false;
            buttonNotificacao2.Enabled = false;
            buttonNotificacao3.Enabled = false;

            labelNotificacao1.Text = "";
            labelNotificacao2.Text = "";
            labelNotificacao3.Text = "";

            buttonReimprimir.Enabled = false;

            textBoxData.Text = "";
            textBoxStatus.Text = "";
        }

        private void NotificacaoView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.OpenStepByStep();
        }
    }
}
