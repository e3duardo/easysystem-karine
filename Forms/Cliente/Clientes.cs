using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Cliente
{
    public partial class Clientes : Form
    {
        private delegate void InvokeDelegate(int index);

        public Clientes()
        {
            InitializeComponent();
        }



        private void Clientes_Load(object sender, EventArgs e)
        {
        }


        // /////

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewResultado.Rows.Clear();

                QItem queryCodigo = new QItem(null, null);
                //QItem queryEmpresaNome = new QItem(null, null);
                QItem queryClienteNome = new QItem(null, null);

                //codigo
                if (this.textBoxCodigo.Text != "")
                    queryCodigo = new QItem("c.id", this.textBoxCodigo.Text);
                else
                    queryCodigo = new QItem(null, null);

                //cliente
                if (this.textBoxClienteNome.Text != "")
                    queryClienteNome = new QItem("c.nome LIKE %%", this.textBoxClienteNome.Text);
                else
                    queryClienteNome = new QItem(null, null);

                //empresa
                //if (this.textBoxEmpresaNome.Text != "")
                //    queryClienteNome = new QItem("e.nome LIKE %%", this.textBoxEmpresaNome.Text);
                //else
                //    queryClienteNome = new QItem(null, null);



                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced(queryCodigo, queryClienteNome);//, queryEmpresaNome);




                if (clientes != null)
                {
                    foreach (Library.Cliente c in clientes)
                    {
                        /*string status = "";
                        if (c.Notificacao != 0)
                        {
                            status = "Notificação " + c.Notificacao;
                        }*/
                        dataGridViewResultado.Rows.Add(c.Id, c.Nome, "");//status);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void dataGridViewResultado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (e.RowIndex != -1)
                {
                    Library.Cliente cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", e.RowIndex].Value);

                    this.dataGridViewResultado.BeginInvoke(new InvokeDelegate(OpenTermos), new object[] { e.RowIndex });
                    /*
                    if (cliente.Notificacao < 3)
                        this.dataGridViewResultado.BeginInvoke(new InvokeDelegate(OpenNotificacao), new object[] { e.RowIndex });
                    else
                        this.dataGridViewResultado.BeginInvoke(new InvokeDelegate(OpenTermoCompromisso), new object[] { e.RowIndex });
                     */
                }
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }

            this.Cursor = Cursors.Default;
        }

        private void buttonNotificacao_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultado.SelectedRows.Count >= 1)
            {
                int index = dataGridViewResultado.SelectedRows[0].Index;

                Forms.TermoCompromisso.NotificacaoView notificacao = new Forms.TermoCompromisso.NotificacaoView();
                notificacao.cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", index].Value);
                notificacao.ShowDialog(this);
            }
        }

        private void buttonTermoCompromisso_Click(object sender, EventArgs e)
        {
            if (dataGridViewResultado.SelectedRows.Count >= 1)
            {
                int index = dataGridViewResultado.SelectedRows[0].Index;

                Forms.TermoCompromisso.TermoCompromissoView termoCompromisso = new Forms.TermoCompromisso.TermoCompromissoView();
                termoCompromisso.cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", index].Value);
                termoCompromisso.ShowDialog(this);
            }
        }

        private void dataGridViewResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Library.Cliente cliente = Library.ClienteBD.FindById((long)dataGridViewResultado.SelectedRows[0].Cells["ColumnId"].Value);

            /*
            if (cliente.Notificacao < 3)
            {
                buttonNotificacao.Enabled = true;
            }
            else
            {
                buttonNotificacao.Enabled = false;
            }*/
        }


        // //////

        public void OpenNotificacao(int index)
        {
            Forms.TermoCompromisso.NotificacaoView notificacao = new Forms.TermoCompromisso.NotificacaoView();
            notificacao.cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", index].Value);
            notificacao.ShowDialog(this);
        }

        public void OpenTermoCompromisso(int index)
        {
            Forms.TermoCompromisso.TermoCompromissoView termoCompromisso = new Forms.TermoCompromisso.TermoCompromissoView();
            termoCompromisso.cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", index].Value);
            termoCompromisso.ShowDialog(this);
        }

        public void OpenTermos(int index)
        {
            Forms.Cliente.Termos termos = new Forms.Cliente.Termos();
            termos.Cliente = Library.ClienteBD.FindById((long)dataGridViewResultado["ColumnId", index].Value);
            termos.ShowDialog(this);
        }


    }
}
