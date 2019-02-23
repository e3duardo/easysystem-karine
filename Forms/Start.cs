using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using Library.Configuration;
using Library.Classes;

namespace Forms
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }



        private void Start_Load(object sender, EventArgs e)
        {
            //RefreshJanelaMenu();
            this.labelVersion.Text = String.Format("v{0}", AssemblyVersion);
            LoadParcelasAtrasadas();
            LoadNotificacaoStatus();
            //this.RefreshStatusProdutos();
        }


        private void empresaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenEmpresa();
        }

        private void pessoaFisicaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteFisica();
        }

        private void pessoaJuridicaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteJuridica();
        }

        private void funcionario_TSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenFuncionario();
        }

        private void mudarSenhaTSMI_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenMudarSenha();
        }

        private void sobreTSMI_Click(object sender, EventArgs e)
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.About)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Form form = new Forms.About();
                form.Show();
                //RefreshJanelaMenu();
            }
        }

        private void receberParcelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenTermoCompromissoParcelaQuitar();
            LoadParcelasAtrasadas();
        }

        private void toolStripAtrasadas_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenTermoCompromissoParcelaAtrasadas();
        }


        private void toolStripMenuItemClientesEmAtraso_Click(object sender, EventArgs e)
        {
            new Reports.RClienteAtraso().Show();
        }

        private void toolStripMenuItemClientes_Click(object sender, EventArgs e)
        {
            new Reports.RClienteStatus().Show();
        }

        private void toolStripMenuItemRelatorioEmpresa_Click(object sender, EventArgs e)
        {
            new Reports.REmpresaReceber().Show();
        }


        private void buttonNotificacaoTermo_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenStepByStep();
        }



        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public void LoadNotificacaoStatus()
        {
            try
            {
                int countNotificacoes = 0;
                DSettings set = new DSettings();
                DAppSettings.Load(set);


                List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced();


                foreach (Library.TermoCompromisso termo in termos)
                {
                    List<Library.Notificacao> notificacoes = Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", termo.Id), new QItem("tc.status", (int)Library.TCStatus.notificando));
                    if (notificacoes != null)
                    {
                        switch (notificacoes.Count)
                        {
                            case 0:
                                break;
                            case 1:
                                if (DateTime.Parse(notificacoes[0].Data.AddDays(set.textBoxNotificacao1).ToShortDateString()) <= DateTime.Today)
                                    countNotificacoes++;
                                break;
                            case 2:
                                if (DateTime.Parse(notificacoes[1].Data.AddDays(set.textBoxNotificacao2).ToShortDateString()) <= DateTime.Today)
                                    countNotificacoes++;
                                break;
                            case 3:
                                if (DateTime.Parse(notificacoes[2].Data.AddDays(set.textBoxNotificacao2).ToShortDateString()) <= DateTime.Today)
                                    countNotificacoes++;
                                break;
                        }
                    }
                }

                string str = "";

                //int total = Library.ProdutoBD.GetCountByTipoEstoque();
                if (countNotificacoes == 0)
                    str += "Nenhuma notificação fora do prazo de comparecimento. ";
                else if (countNotificacoes == 1)
                    str += "Uma notificação fora do prazo de comparecimento. ";
                else
                    str += string.Format("{0} notificações fora do prazo de comparecimento. ", countNotificacoes);

                this.toolStripStatusLabel3.Text = str;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
        }

        public void LoadParcelasAtrasadas()
        {
            try
            {
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced();

                //int total = 0;
                decimal totalDividas = 0;
                foreach (Library.Cliente c in clientes)
                {
                    List<Library.TermoCompromissoParcela> vendasparcelas = Library.ClienteBD.GetParcelasAtrasadasById(c.Id);
                    totalDividas += vendasparcelas.Count;
                }

                string str = "";

                //int total = Library.ProdutoBD.GetCountByTipoEstoque();
                if (totalDividas == 0)
                    str += "Nenhum cliente com parcelas em atraso. ";
                else if (totalDividas == 1)
                    str += "Um cliente com parcelas em atraso. ";
                else
                    str += string.Format("{0} clientes com parcelas em atraso. ", totalDividas);

                this.toolStripAtrasadas.Text = str;
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
        }

        private void opcoesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Forms.Opcoes.Opcoes().Show();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            new Forms.Notificacao.Notificacao().Show();
        }
    }
}
