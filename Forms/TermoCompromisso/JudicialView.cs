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
using Library.Configuration;

namespace Forms.TermoCompromisso
{
    public partial class JudicialView : Form
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

        public JudicialView()
        {
            InitializeComponent();
        }



        private void JudicialView_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();
            comboBoxEmpresa.SelectedIndex = -1;
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCliente();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cliente = (Library.Cliente)comboBoxCliente.SelectedItem;
        }


        public void FillEmpresa()
        {
            comboBoxEmpresa.DisplayMember = "nome";
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DataSource = Library.EmpresaBD.FindAdvanced(new QItem("ORDER BY", "e.nome"));
        }

        public void FillCliente()
        {
            try
            {
                if (comboBoxEmpresa.SelectedIndex != -1)
                {
                    DSettings set = new DSettings();
                    DAppSettings.Load(set);

                    comboBoxCliente.Text = "";

                    Library.Empresa empresa = (Library.Empresa)comboBoxEmpresa.SelectedItem;

                    comboBoxCliente.DisplayMember = "nome";
                    comboBoxCliente.ValueMember = "id";

                    comboBoxCliente.Items.Clear();
                    foreach (Library.TermoCompromisso tc in Library.TermoCompromissoBD.FindAdvanced(new QItem("e.id", empresa.Id), new QItem("tc.status", (int)Library.TCStatus.notificando), new QItem("ORDER BY", "c.nome")))
                    {
                        List<Library.Notificacao> notificacoes = Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", tc.Id));
                        if (notificacoes != null)
                        {
                            if (notificacoes.Count == 3)
                            {
                                DateTime data33 = notificacoes[2].Data.AddDays(set.textBoxNotificacao2).Date;

                                if (data33 <= DateTime.Today)
                                    comboBoxCliente.Items.Add(tc.Cliente);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            if ((comboBoxEmpresa.SelectedIndex != -1) & (comboBoxCliente.SelectedIndex != -1))
            {
                if (MessageBox.Show("Deseja referenciar como um termo de compromisso não comprido?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Library.TermoCompromisso termo = this.TermoCompromisso;
                    termo.Status = (int)Library.TCStatus.descomprido;
                    Library.TermoCompromissoBD.Update(termo);
                    Forms.OpenForm.RefreshNotificacoes();

                    //notificacao
                    Forms.TermoCompromisso.ChangeText ct = new Forms.TermoCompromisso.ChangeText();

                    if (ct.ShowDialog(this) == DialogResult.OK)
                    {
                        if (this.notificacoes.Count == 3)
                        {
                            Reports.NotificacaoR notificacao = new Reports.NotificacaoR();
                            notificacao.cliente = this.TermoCompromisso.Cliente;
                            notificacao.Texto = ct.Texto;

                            if (notificacao.ShowDialog(this) == DialogResult.Yes)
                            {
                                Library.NotificacaoBD.Save(NovaNotificacao(ct.Texto));

                                //Library.TermoCompromisso termo = this.TermoCompromisso;
                                //termo.Status = (int)Library.TCStatus.notificando;
                                //Library.TermoCompromissoBD.Update(termo);

                                Forms.OpenForm.RefreshNotificacoes();
                            }
                            //ShowValues(this.TermoCompromisso);
                        }
                        else
                        {
                           // MessageBox.Show("Você deve imprimir as notificações anteriores.");
                        }
                    }
                    //endnotificacao

                    this.Close();
                }
            }
        }

        private Library.Notificacao NovaNotificacao(string texto)
        {
            Library.Notificacao notificacao = new Library.Notificacao();
            notificacao.Data = DateTime.Now;
            notificacao.Texto = texto;
            notificacao.TermoCompromisso = this.TermoCompromisso;
            notificacao.isJudicial = true;
            return notificacao;
        }
    }
}
