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
    public partial class TermoCompromisso : Form
    {
        public Library.Cliente cliente { get; set; }

        public TermoCompromisso()
        {
            InitializeComponent();
        }

        private void TermoCompromisso_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.dataGridViewResultado.Rows.Clear();

                decimal quantidade = 0;
                decimal.TryParse(textBoxParcelas.Text, out quantidade);

                decimal valor = 0;
                decimal.TryParse(this.textBoxValor.Text, out valor);


                if (quantidade != 0)
                {
                    DateTime dataParcela = this.dateTimePickerData.Value.AddMonths(-1);

                    decimal valorParcela = valor / quantidade;

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
                Library.Classes.Logger.Error(ex.Message, ex.StackTrace, ex.HelpLink, ex);
            }
            this.Cursor = Cursors.Default;
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
                Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;

                Reports.TermoCompromissoR termoCompromisso = new Reports.TermoCompromissoR();
                termoCompromisso.cliente = cliente;
                //notificacao.notificacao = 2;
                termoCompromisso.ShowDialog(this);
        }

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
    }
}
