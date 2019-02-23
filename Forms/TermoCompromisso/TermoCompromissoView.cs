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
using Library.Converter;

namespace Forms.TermoCompromisso
{
    public partial class TermoCompromissoView : Form
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

        public TermoCompromissoView()
        {
            InitializeComponent();
        }

        private void TermoCompromisso_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();

            if (this.cliente == null)
                ShowValues();
            else
                ShowValues(this.TermoCompromisso);
            comboBoxEmpresa.SelectedIndex = -1;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.dataGridViewResultado.Rows.Clear();

                double quantidade = this.textBoxParcelas.Text.ConvertToDouble();

                double valor = this.textBoxValor.Text.ConvertToDouble();


                if (quantidade != 0)
                {
                    DateTime dataParcela = this.dateTimePickerData.Value.AddMonths(-1);

                    double valorParcela = valor / quantidade;

                    for (int i = 0; i < quantidade; i++)
                    {
                        dataParcela = dataParcela.AddMonths(1);

                        this.dataGridViewResultado.Rows.Add(new object[] { valorParcela, dataParcela.ToString("dd/MM/yyyy") });
                    }
                }
                else
                {
                    MessageBox.Show("Digite a quantidade de parcelas.", "Aviso!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;

                Reports.TermoCompromissoR termoCompromisso = new Reports.TermoCompromissoR();
                termoCompromisso.cliente = this.TermoCompromisso.Cliente;
                termoCompromisso.valor = this.textBoxValor.Text.ConvertToDecimal();
                //notificacao.notificacao = 2;
                termoCompromisso.ShowDialog(this);
                if (MessageBox.Show("Deseja salvar?", "Informação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.TermoCompromisso.Status = (int)TCStatus.assinado;
                    this.TermoCompromisso.Valor = this.textBoxValor.Text.ConvertToDouble();

                    Library.TermoCompromissoBD.Update(this.TermoCompromisso);
                    SalvarTermoCompromissoParcela(this.TermoCompromisso);

                    Forms.OpenForm.RefreshNotificacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCliente();
            ShowValues();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cliente = (Library.Cliente)comboBoxCliente.SelectedItem;
            ShowValues(this.TermoCompromisso);
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
            this.panel1.Enabled = true;

            this.dataGridViewResultado.Rows.Clear();
            this.textBoxParcelas.Text = "";
            this.textBoxValor.Text = "";
            this.dateTimePickerData.Value = DateTime.Now;
        }

        public void ShowValues()
        {
            this.panel1.Enabled = false;

            this.dataGridViewResultado.Rows.Clear();
            this.textBoxParcelas.Text = "";
            this.textBoxValor.Text = "";
            this.dateTimePickerData.Value = DateTime.Now;


        }


        public void SalvarTermoCompromissoParcela(Library.TermoCompromisso termo)
        {
            for (int i = 0; i < dataGridViewResultado.Rows.Count; i++)
            {
                //dataGridViewResultado.Rows[i];
                Library.TermoCompromissoParcela tcp = new Library.TermoCompromissoParcela();
                tcp.Valor = (double)dataGridViewResultado.Rows[i].Cells[0].Value;
                tcp.Data = DateTime.Parse(dataGridViewResultado.Rows[i].Cells[1].Value.ToString());
                tcp.TermoCompromisso = termo;

                Library.TermoCompromissoParcelaBD.Save(tcp);
            }
        }

        private void TermoCompromissoView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.OpenStepByStep();
        }
    }
}
