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
    public partial class ClienteJuridica : Form
    {
        /******************************************************/
        private delegate void InvokeDelegate(int index);

        //private string RemoverEmpresaMsg = "Deseja realmente remover esta empresa?";
        //private string RemoverEmpresaMsgTitle = "Remover empresa";

        string fcClienteJuridicaDeletarMsg = "Deseja realmente excluir este cliente?";
        string fcClienteJuridicaDeletarMsgTitle = "Excluir";
        string fcClienteJuridicaDeletarNoSelected = "Selecione um cliente";

        string fcClienteJuridicaValidateNome = "Informe um nome.";
        string fcClienteJuridicaValidateEmail = "Informe um email.";
        string fcClienteJuridicaValidateEmailInvalid = "Email com formato inválido.";
        /******************************************************/

        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Cliente cliente;

        public ClienteJuridica()
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

            this.nomeTB.Focus();

            codigoTB.Text = Library.ClienteBD.GetNextId().ToString();

            //this.EnableEdit();
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
                this.MenuDisabler(true, false, false, false, false);
                this.InputDisabler(false);


                if (this.modo == "Cadastrar")
                {
                    //criando um cliente com valores do formulário
                    this.cliente = this.ReturnCargoFromForm();
                    //salvando cliente
                    Library.ClienteBD.Save(this.cliente);

                    this.dataGridView1.Rows.Add(this.cliente.Id, this.cliente.Nome, this.cliente.DataCadastro);
                }
                else
                {
                    this.cliente = this.UpdateCargoFromForm();
                    //atualizando cliente
                    Library.ClienteBD.Update(this.cliente);

                    this.dataGridView1.Rows[IndexSelecionado].Cells[0].Value = this.cliente.Id;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[1].Value = this.cliente.Nome;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[2].Value = this.cliente.DataCadastro;
                }

                //atualizando formulário
                //RefreshForm();
                RefreshChilds();

                this.Modo = "Salvar";
            }
            else
            {
                //mensagem de erro
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
            if (MessageBox.Show(this.fcClienteJuridicaDeletarMsg, this.fcClienteJuridicaDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fcClienteJuridicaDeletarNoSelected);
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
                clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"));
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"), new QItem("c.id", id));
                }
                else
                {
                    clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"), new QItem("c.nome LIKE %%", this.filtrosTextBox.Text));
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

        private void fisicaButton_Click(object sender, EventArgs e)
        {
            Forms.OpenForm.OpenClienteFisica();
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
                List<Library.Cliente> clientes = Library.ClienteBD.FindAdvanced(new QItem("c.pessoa", "Juridica"));

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
            this.cnpjTB.Text = cliente.Cnpj;
            this.emailTB.Text = cliente.Email;
            this.enderecoTB.Text = cliente.Endereco;
            this.estadoCB.Text = cliente.Estado;
            this.faxTB.Text = cliente.Fax;
            this.inscricaoEstadualTB.Text = cliente.InscricaoEstadual;
            this.nomeTB.Text = cliente.Nome;
            this.nomeContatoTB.Text = cliente.NomeContato;
            this.nomeFantasiaTB.Text = cliente.NomeFantasia;
            this.observacoesTB.Text = cliente.Observacoes;
            this.siteTB.Text = cliente.Site;
            this.telefoneTB.Text = cliente.Telefone;
            this.textBoxNumero.Text = cliente.EnderecoNumero.ToString();

            //List<Library.Empresa> empresastmp = new List<Library.Empresa>();
            //foreach (Library.ClienteEmpresa ce in Library.ClienteEmpresaBD.FindAdvanced(new QItem("c.id", cliente.Id)))
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
            this.cnpjTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.faxTB.Text = "";
            this.inscricaoEstadualTB.Text = "";
            this.nomeTB.Text = "";
            this.nomeContatoTB.Text = "";
            this.nomeFantasiaTB.Text = "";
            this.observacoesTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";
            this.textBoxNumero.Text = "";
        }

        //retornar objeto cliente com valores do formulario
        private Library.Cliente ReturnCargoFromForm()
        {
            Library.Cliente clienteTemp = new Library.Cliente();

            //clienteTemp.Id =  long.Parse(this.codigoTB.Text);
            clienteTemp.Bairro =  this.bairroTB.Text;
            clienteTemp.Celular =  this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cnpj = this.cnpjTB.Text;
            clienteTemp.Email =  this.emailTB.Text;
            clienteTemp.Endereco =  this.enderecoTB.Text;
            clienteTemp.Estado =  this.estadoCB.Text;
            clienteTemp.Fax = this.faxTB.Text;
            clienteTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            clienteTemp.Nome =  this.nomeTB.Text;
            clienteTemp.NomeContato = this.nomeContatoTB.Text;
            clienteTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
            clienteTemp.Site =  this.siteTB.Text;
            clienteTemp.Telefone =  this.telefoneTB.Text;
            clienteTemp.DataCadastro = DateTime.Now;

            clienteTemp.Cpf = null;
            clienteTemp.Rg = null;
            clienteTemp.ReferenciaComercial = null;
            clienteTemp.Nascimento = null;
            
            clienteTemp.Pessoa = "Juridica";

            clienteTemp.EnderecoNumero = this.textBoxNumero.Text;

            return clienteTemp;
        }

        //atualizar objeto cliente com valores do formulario
        private Library.Cliente UpdateCargoFromForm()
        {
            Library.Cliente clienteTemp = this.cliente;

            clienteTemp.Id =  long.Parse(this.codigoTB.Text);
            
            clienteTemp.Bairro = this.bairroTB.Text;
            clienteTemp.Celular = this.celularTB.Text;
            clienteTemp.Cep = this.cepTB.Text;
            clienteTemp.Cidade = this.cidadeTB.Text;
            clienteTemp.Cnpj = this.cnpjTB.Text;
            clienteTemp.Email = this.emailTB.Text;
            clienteTemp.Endereco = this.enderecoTB.Text;
            clienteTemp.Estado = this.estadoCB.Text;
            clienteTemp.Fax = this.faxTB.Text;
            clienteTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            clienteTemp.Nome = this.nomeTB.Text;
            clienteTemp.NomeContato = this.nomeContatoTB.Text;
            clienteTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            clienteTemp.Observacoes = this.observacoesTB.Text;
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
        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }
        private void nomeTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNome();
        }
            
        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private bool ValidateNome()
        {
            if (this.nomeTB.Text == "")
            {
                this.errorProvider.SetError(nomeTB, this.fcClienteJuridicaValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(nomeTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (this.emailTB.Text == "")
            {
                this.warnigProvider.SetError(emailTB, this.fcClienteJuridicaValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(emailTB, this.fcClienteJuridicaValidateEmailInvalid);
            }
            else
            {
                this.warnigProvider.SetError(emailTB, "");
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
