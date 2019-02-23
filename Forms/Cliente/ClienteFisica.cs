using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;
using Library.Converter;




namespace Forms.Cliente
{
    public partial class ClienteFisica : Form
    {
        /******************************************************/
        private delegate void InvokeDelegate(int index);

        //private string RemoverEmpresaMsg = "Deseja realmente remover esta empresa?";
        //private string RemoverEmpresaMsgTitle = "Remover empresa";

        private string fcClienteFisicaDeletarMsg = "Deseja realmente excluir este cliente?";
        private string fcClienteFisicaDeletarMsgTitle = "Excluir";
        private string fcClienteFisicaDeletarNoSelected = "Selecione um cliente";

        private string fcClienteFisicaValidateNome = "Informe um nome.";
        private string fcClienteFisicaValidateCpf = "Informe um CPF.";
        private string fcClienteFisicaValidateCpfInvalid = "CPF com formato inválido.";
        private string fcClienteFisicaValidateEmail = "Informe um email.";
        private string fcClienteFisicaValidateEmailInvalid = "Email com formato inválido.";
        /******************************************************/


        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Cliente cliente;

        public ClienteFisica()
        {
            InitializeComponent();
        }

        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.RefreshForm();
            this.Cursor = Cursors.Default;
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(false, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            this.ShowValues();
            //this.EnableEdit();

            this.nomeTB.Focus();

            codigoTB.Text = Library.ClienteBD.GetNextId().ToString();
            /*************END*************/
            this.Modo = "Cadastrar";
            this.Cursor = Cursors.Default;
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, true, true, false);
            this.InputDisabler(true);
            /************BEGIN************/
            //achando idCliente selecionado na grid
            long idCliente = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCliente = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando cliente selecionado no formulario
            this.cliente = Library.ClienteBD.FindById(idCliente);
            this.ShowValues(this.cliente);
            /*************END*************/
            this.Modo = "Editar";
            this.Cursor = Cursors.Default;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            /************BEGIN************/
            if (ValidateForm())
            {
                bool cadastrar = false;

                if (this.modo == "Cadastrar")
                {
                    //criando um cliente com valores do formulário
                    this.cliente = this.ReturnClienteFromForm();
                    //salvando cliente


                    List<Library.Cliente> clitemp = Library.ClienteBD.FindAdvanced(new QItem("c.cpf", cliente.Cpf));


                    if (clitemp.Count >= 1)
                        if (MessageBox.Show("Existe um cliente já cadastrado com esse CPF. Deseja cadastrar assim mesmo?", "Aviso!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            cadastrar = true;
                        else
                            cadastrar = false;
                    else
                        cadastrar = true;


                    if (cadastrar == true)
                    {
                        Library.ClienteBD.Save(this.cliente);

                        this.dataGridView1.Rows.Add(this.cliente.Id, this.cliente.Nome, this.cliente.DataCadastro);
                    }
                }
                else
                {
                    this.cliente = this.UpdateClienteFromForm();

                    cadastrar = true;
                    //atualizando cliente
                    Library.ClienteBD.Update(this.cliente);

                    foreach (DataGridViewRow d in dataGridView1.Rows)
                    {
                        if ((long)d.Cells[0].Value == this.cliente.Id)
                        {
                            d.Cells[0].Value = this.cliente.Id;
                            d.Cells[1].Value = this.cliente.Nome;
                            d.Cells[2].Value = this.cliente.DataCadastro;
                        }
                    }
                }

                if (cadastrar == true)
                {
                    this.MenuDisabler(true, false, false, false, false);
                    this.InputDisabler(false);

                    //atualizando formulário
                    //RefreshForm();
                    RefreshChilds();

                    this.Modo = "Salvar";
                }
            }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.InputDisabler(false);
            /************BEGIN************/
            this.RefreshForm();
            /*************END*************/
            this.Modo = "Cancelar";
            this.Cursor = Cursors.Default;
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.InputDisabler(false);
            /************BEGIN************/
            //achando idCliente selecionado na grid
            long idCliente = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCliente = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fcClienteFisicaDeletarMsg, this.fcClienteFisicaDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fcClienteFisicaDeletarNoSelected);
                }
                else
                {
                    Library.ClienteBD.DeleteById(idCliente);
                    this.RefreshForm();
                }
            }

            /*************END*************/
            this.Modo = "Excluir";
            this.Cursor = Cursors.Default;
        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.InputDisabler(false);
            /************BEGIN************/
            List<Library.Cliente> clientes;
            if (this.filtrosTextBox.Text == "")
            {
                clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Fisica"));
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Fisica"), new QItem("c.id", id));
                }
                else
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Fisica"), new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            if (clientes != null)
            {
                foreach (Library.Cliente c in clientes)
                {
                    this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);
                }
            }
            /*************END*************/
            this.Modo = "Pesquisar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, true, false, false, true);
            this.InputDisabler(false);
            /************BEGIN************/
            //achando idCliente selecionado na grid
            long idCliente = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idCliente = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando cliente selecionado no formulario
            this.cliente = Library.ClienteBD.FindById(idCliente);
            this.ShowValues(cliente);
            /*************END*************/
            this.Modo = "Selecionar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void Cliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

        private void juridicaButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteJuridica();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
                IndexSelecionado = this.dataGridView1.Rows.IndexOf(this.dataGridView1.SelectedRows[0]);
        }


        /*
         * 
         * FUNÇÕES DO FORMULÁRIO
         * 
         */

        //atualizar formulario
        private void RefreshForm()
        {
            try
            {
                //desabilitando certos menus e campos
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);

                //preenchendo um dataset e ligando-o na grid
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Fisica"));

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Cliente c in clientes)
                {
                    if (i == 0)
                        this.ShowValues(c);

                    this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);

                    i++;
                }
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
        }
        private void RefreshChilds()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                //if (a is Forms.Orcamento.Orcamento)
                //{
                //    Forms.Orcamento.Orcamento form = (Forms.Orcamento.Orcamento)a;
                //    form.FillCliente();
                //}
                //if (a is Forms.Venda.Venda)
                //{
                //    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                //    form.FillCliente();
                //}
                //if (a is Forms.Servico.Cadastro)
                //{
                //    Forms.Servico.Cadastro form = (Forms.Servico.Cadastro)a;
                //    form.FillCliente();
                //}
                //if (a is Forms.Servico.Entregar)
                //{
                //    Forms.Servico.Entregar form = (Forms.Servico.Entregar)a;
                //    form.FillCliente();
                //}
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Cliente cliente)
        {
            this.codigoTB.Text = string.Format("{0}", cliente.Id);
            this.bairroTB.Text = cliente.Bairro;
            this.celularTB.Text = cliente.Celular;
            this.cepTB.Text = cliente.Cep;
            this.cidadeTB.Text = cliente.Cidade;
            this.cpfTB.Text = cliente.Cpf;
            this.emailTB.Text = cliente.Email;
            this.enderecoTB.Text = cliente.Endereco;
            this.estadoCB.Text = cliente.Estado;
            this.nascimentoDTP.Value = cliente.Nascimento.Value;
            this.nomeTB.Text = cliente.Nome;
            this.observacoesTB.Text = cliente.Observacoes;
            this.referenciaComercialTB.Text = cliente.ReferenciaComercial;
            this.rgTB.Text = cliente.Rg;
            this.siteTB.Text = cliente.Site;
            this.telefoneTB.Text = cliente.Telefone;
            this.textBoxNumero.Text = cliente.EnderecoNumero.ToString();

            //List<Library.Empresa> empresastmp = new List<Library.Empresa>();
            //foreach (Library.ClienteEmpresa ce in Library.ClienteEmpresaBD.FindAdvanced(new QItem("c.id",cliente.Id)))
            //{
            //    empresastmp.Add(ce.Empresa);
            //}
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.bairroTB.Text = "";
            this.celularTB.Text = "";
            this.cepTB.Text = "";
            this.cidadeTB.Text = "";
            this.cpfTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.nascimentoDTP.Text = "";
            this.nomeTB.Text = "";
            this.observacoesTB.Text = "";
            this.referenciaComercialTB.Text = "";
            this.rgTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";
            this.textBoxNumero.Text = "";
        }

        //retornar objeto cliente com valores do formulario
        private Library.Cliente ReturnClienteFromForm()
        {
            Library.Cliente clienteTemp = new Library.Cliente();

            //clienteTemp.Id =  long.Parse(this.codigoTB.Text);
            clienteTemp.Bairro = this.bairroTB.Text;
            clienteTemp.Celular = this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cpf = this.cpfTB.Text;
            clienteTemp.Email = this.emailTB.Text;
            clienteTemp.Endereco = this.enderecoTB.Text;
            clienteTemp.Estado = this.estadoCB.Text;
            DateTime nascimento;
            if (DateTime.TryParse(this.nascimentoDTP.Text, out nascimento))
                clienteTemp.Nascimento = nascimento;
            else
                clienteTemp.Nascimento = null;
            clienteTemp.Nome = this.nomeTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
            clienteTemp.ReferenciaComercial = this.referenciaComercialTB.Text;
            clienteTemp.Rg = this.rgTB.Text;
            clienteTemp.Site = this.siteTB.Text;
            clienteTemp.Telefone = this.telefoneTB.Text;
            clienteTemp.DataCadastro = DateTime.Now;

            clienteTemp.Cnpj = null;
            clienteTemp.Fax = null;
            clienteTemp.InscricaoEstadual = null;
            clienteTemp.NomeContato = null;
            clienteTemp.NomeFantasia = null;
            clienteTemp.Pessoa = "Fisica";

            clienteTemp.EnderecoNumero = this.textBoxNumero.Text;
            return clienteTemp;
        }

        //atualizar objeto cliente com valores do formulario
        private Library.Cliente UpdateClienteFromForm()
        {
            Library.Cliente clienteTemp = this.cliente;

            clienteTemp.Id = long.Parse(this.codigoTB.Text);
            clienteTemp.Bairro = this.bairroTB.Text;
            clienteTemp.Celular = this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cpf = this.cpfTB.Text;
            clienteTemp.Email = this.emailTB.Text;
            clienteTemp.Endereco = this.enderecoTB.Text;
            clienteTemp.Estado = this.estadoCB.Text;
            clienteTemp.Nascimento = DateTime.Parse(this.nascimentoDTP.Text);
            clienteTemp.Nome = this.nomeTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
            clienteTemp.ReferenciaComercial = this.referenciaComercialTB.Text;
            clienteTemp.Rg = this.rgTB.Text;
            clienteTemp.Site = this.siteTB.Text;
            clienteTemp.Telefone = this.telefoneTB.Text;
            clienteTemp.EnderecoNumero = this.textBoxNumero.Text;
            //clienteTemp.DataCadastro = DateTime.Now;

            return clienteTemp;
        }

        private void MenuDisabler(bool novo, bool editar, bool salvar, bool cancelar, bool excluir)
        {
            this.novoButton.Enabled = novo;
            this.editarButton.Enabled = editar;
            this.salvarButton.Enabled = salvar;
            this.cancelarButton.Enabled = cancelar;
            this.excluirButton.Enabled = excluir;
        }
        private void InputDisabler(bool habilitado = true)
        {
            panel1.Enabled = habilitado;
            tableLayoutPanel1.Enabled = !habilitado;
        }


        /*
         * 
         * FUNÇÕES DE VALIDAÇÕS
         * 
         */
        private void cpfTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateCpf();
        }
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }
        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }

        private void cpfTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateCpf();
        }
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }


        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                errorProvider.SetError(nomeTB, this.fcClienteFisicaValidateNome);
                return false;
            }
            else
            {
                errorProvider.SetError(nomeTB, "");
            }
            return true;
        }
        private bool ValidateCpf()
        {
            if (this.cpfTB.Text == "")
            {
                warnigProvider.SetError(cpfTB, this.fcClienteFisicaValidateCpf);
                return false;
            }
            else if (Library.Classes.Validacao.BoolCPF(this.cpfTB.Text) == false)
            {
                warnigProvider.SetError(cpfTB, this.fcClienteFisicaValidateCpfInvalid);
            }
            else
            {
                warnigProvider.SetError(cpfTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (this.emailTB.Text == "")
            {
                warnigProvider.SetError(emailTB, this.fcClienteFisicaValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                warnigProvider.SetError(emailTB, this.fcClienteFisicaValidateEmailInvalid);
            }
            else
            {
                warnigProvider.SetError(emailTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidNome = ValidateNome();

            if (bValidNome)
                return true;

            return false;
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EnableEdit();
        }
    }
}
