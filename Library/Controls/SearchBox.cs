using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Library.Classes;

namespace Library.Controls
{

    public enum tipo { Cargo, ClienteFisica, ClienteJuridica, Fornecedor, Funcionario, Produto, Seguranca, Setor, Veiculo };

    public partial class SearchBox : UserControl
    {
        public SearchBox()
        {
            InitializeComponent();
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;


            this.resultadoDGV.Rows.Clear();
            
            List<Library.Cliente> clientes;
            List<Library.Funcionario> funcionarios;


            switch (this.Tipo)
            {
                case tipo.ClienteFisica:
                
                    if (this.filtrosTextBox.Text == "")
                        clientes = Library.ClienteBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.id", id));
                        else
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Cliente s in clientes)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.ClienteJuridica:
                   
                    if (this.filtrosTextBox.Text == "")
                        clientes = Library.ClienteBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.id", id));
                        else
                            clientes = Library.ClienteBD.FindAdvanced(new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Cliente s in clientes)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                case tipo.Funcionario:

                    if (this.filtrosTextBox.Text == "")
                        funcionarios = Library.FuncionarioBD.FindAdvanced();
                    else
                    {
                        long id;
                        if (long.TryParse(this.filtrosTextBox.Text, out id))
                            funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.id", id));
                        else
                            funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                    }

                    foreach (Library.Funcionario s in funcionarios)
                        this.resultadoDGV.Rows.Add(s.Id, s.Nome, s.DataCadastro);

                    break;
                default:
                    break;

            }




            this.Cursor = Cursors.Default;
        }

        public long idSelecionado()
        {
            if (this.resultadoDGV.SelectedRows.Count == 1)
            {
                long idTMP = 0;
                long.TryParse(this.resultadoDGV.SelectedRows[0].Cells[0].Value.ToString(), out idTMP);
                return idTMP;
            }
            return 0;
        }

        public void PerformLoad()
        {
            this.pesquisarButton.PerformClick();
        }
    }
}
