using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.TermoCompromissoParcela
{
    public partial class Quitar : Form
    {
        public Quitar()
        {
            InitializeComponent();
        }

        private void Quitar_Load(object sender, EventArgs e)
        {
            
            FillEmpresa();
            FillCliente();

            descontarParcelaCB.Checked = false;
            descontarParcelaTB.Text = "";
            descontarParcelaTB.Enabled = false;
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }


        private void dataGridViewTermos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Selecionado(e.RowIndex);
        }

        private void descontarParcelaCB_Click(object sender, EventArgs e)
        {

        }

        private void descontarParcelaCB_CheckedChanged(object sender, EventArgs e)
        {
            this.descontarParcelaTB.Enabled = this.descontarParcelaCB.Checked;
            this.descontarParcelaTB.Text = "";
        }

        private void buttonReceber_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Library.TermoCompromisso termoCompromisso = Library.TermoCompromissoBD.FindById((long)this.dataGridViewTermos.SelectedRows[0].Cells[0].Value);

                if (this.descontarParcelaCB.Checked == true)
                {
                    Library.TermoCompromissoParcela parcela = Library.TermoCompromissoParcelaBD.FindById((long)this.dataGridViewParcelas.SelectedRows[0].Cells[0].Value);

                    double valor = 0;
                    double.TryParse(this.descontarParcelaTB.Text, out valor);

                    double valor2 = (double)parcela.Valor - valor;

                    if (valor2 == 0)//pagando parcela inteira pois descontou um valor do tamanho da parcela
                    {
                        parcela.Pago = 1;

                        Library.TermoCompromissoParcelaBD.Update(parcela);

                    }
                    else if (valor2 > 0)//pagando um valor em uma parcela
                    {
                        parcela.Pago = 0;
                        parcela.Valor = valor2;

                        Library.TermoCompromissoParcelaBD.Update(parcela);

                    }
                    else
                    {
                        //MessageBox.Show(this.fvQuitarParcelaValorInvalid);
                    }

                }
                else//pagando parcela inteira pois não foi selecionado o checkbox
                {
                    Library.TermoCompromissoParcela parcela = Library.TermoCompromissoParcelaBD.FindById((long)this.dataGridViewParcelas.SelectedRows[0].Cells[0].Value);

                    parcela.Pago = 1;

                    Library.TermoCompromissoParcelaBD.Update(parcela);

                }

                //conferindo se todas parcelas estão pagas
                List<Library.TermoCompromissoParcela> vendasparcelas = Library.TermoCompromissoParcelaBD.FindAdvanced(new QItem("v.id", termoCompromisso.Id));
                int count = 0;
                foreach (Library.TermoCompromissoParcela vp in vendasparcelas)
                {
                    if (vp.Pago == 1)
                        count++;
                }
                if (count == vendasparcelas.Count)
                {
                    //termoCompromisso.Pago = 1;
                    //Library.TermoCompromissoBD.Update(termoCompromisso);
                }

                //Pesquisar();
                Selecionado(dataGridViewTermos.SelectedRows[0].Index);
                descontarParcelaCB.Checked = false;
                descontarParcelaTB.Text = "";
                Forms.OpenForm.RefreshParcelas();
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
            this.Cursor = Cursors.Default;
        }

        public void Pesquisar()
        {
            if ((comboBoxEmpresa.SelectedIndex != -1) & (comboBoxCliente.SelectedIndex != -1))
            {
                Library.Empresa empresa = (Library.Empresa)comboBoxEmpresa.SelectedItem;
                Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;



                QItem queryData1 = new QItem(null, null);
                QItem queryData2 = new QItem(null, null);

                //dataEntrega
                if (empresa != null)
                    queryData1 = new QItem("e.id", empresa.Id);
                else
                    queryData1 = new QItem(null, null);

                if (cliente != null)
                    queryData2 = new QItem("c.id", cliente.Id);
                else
                    queryData2 = new QItem(null, null);



                List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced(queryData1, queryData2);

                if (termos != null)
                {
                    this.dataGridViewTermos.Rows.Clear();
                    this.dataGridViewParcelas.Rows.Clear();

                    foreach (Library.TermoCompromisso tc in termos)
                    {
                        this.dataGridViewTermos.Rows.Add(tc.Id, tc.Cliente.Nome, tc.Empresa.Nome, tc.Data);
                    }
                }
            }
        }

        public void Selecionado(int index)
        {
            if (index >= 0)
            {
                Library.TermoCompromisso TermoCompromisso = Library.TermoCompromissoBD.FindById((long)dataGridViewTermos[0, index].Value);

                this.dataGridViewParcelas.Rows.Clear();
                int i = 1;
                foreach (Library.TermoCompromissoParcela tcp in Library.TermoCompromissoParcelaBD.FindAdvanced(new QItem("tc.id", TermoCompromisso.Id), new QItem("ORDER BY", "tcp.data")))
                {
                    int row = this.dataGridViewParcelas.Rows.Add(tcp.Id, i, tcp.Valor, tcp.Data);

                    //dgvic.Value = global::Forms.Properties.Resources.blank;
                    if (tcp.Data < DateTime.Today)
                    {
                        this.dataGridViewParcelas.Rows[row].Cells[4].Value = global::Forms.Properties.Resources.exclamation;
                    }
                    if (tcp.Pago == 1)
                    {
                        this.dataGridViewParcelas.Rows[row].Cells[4].Value = global::Forms.Properties.Resources.accept;
                    }

                    i++;
                }
            }
        }

        public void FillEmpresa()
        {
            comboBoxEmpresa.DisplayMember = "nome";
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DataSource = Library.EmpresaBD.FindAdvanced();
            comboBoxEmpresa.SelectedIndex = -1;
        }

        public void FillCliente()
        {
            comboBoxCliente.Text = "";
            comboBoxCliente.DisplayMember = "nome";
            comboBoxCliente.ValueMember = "id";
            comboBoxCliente.DataSource = Library.ClienteBD.FindAdvanced();
            comboBoxCliente.SelectedIndex = -1;
        }


    }
}
