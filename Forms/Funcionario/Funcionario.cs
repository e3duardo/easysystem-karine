using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Converter;
using Library.Classes;


namespace Forms.Funcionario
{
    public partial class Funcionario : Form
    {
        /******************************************************/
        string ffFuncionarioDeletarMsg = "Deseja realmente excluir este funcionário?";
        string ffFuncionarioDeletarMsgTitle = "Excluir";
        string ffFuncionarioDeletarNoSelected = "Selecione um funcionário";

        string ffFuncionarioValidateCpf = "Informe um CPF.";
        string ffFuncionarioValidateCpfInvalid = "CPF com formato inválido.";
        string ffFuncionarioValidateEmail = "Informe um email.";
        string ffFuncionarioValidateEmailInvalid = "Email com formato inválido.";
        string ffFuncionarioValidateNome = "Informe um nome.";
        string ffFuncionarioValidateLogin = "Informe um login.";
        string ffFuncionarioValidateSenha = "Informe uma senha.";
        string ffFuncionarioValidateSenhaLength = "As senhas devem conter no mínimo 4 e no máximo 8 caracteres.";
        string ffFuncionarioValidateSenhaIncompatible = "As senhas não conferem.";
        /******************************************************/
        
        
        private string modo = "visualizar";
        private string Modo
        {
            get { return modo; }
            set { this.modo = value; }
        }

        public int IndexSelecionado { get; set; }

        private Library.Funcionario funcionario;

        public Funcionario()
        {
            InitializeComponent();
        }



        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Funcionario_Load(object sender, EventArgs e)
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

            codigoTB.Text = Library.FuncionarioBD.GetNextId().ToString();
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
            //achando idFuncionario selecionado na grid
            long idFuncionario = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFuncionario = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando funcionario selecionado no formulario
            this.funcionario = Library.FuncionarioBD.FindById(idFuncionario);
            this.ShowValues(this.funcionario);
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
                    //criando um funcionario com valores do formulário
                    this.funcionario = this.ReturnFuncionarioFromForm();
                    //salvando funcionario
                    Library.FuncionarioBD.Save(this.funcionario);

                    this.dataGridView1.Rows.Add(this.funcionario.Id, this.funcionario.Nome, this.funcionario.DataCadastro);
                }
                else
                {
                    this.funcionario = this.UpdateFuncionarioFromForm();
                    //atualizando funcionario
                    Library.FuncionarioBD.Update(this.funcionario);

                    this.dataGridView1.Rows[IndexSelecionado].Cells[0].Value = this.funcionario.Id;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[1].Value = this.funcionario.Nome;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[2].Value = this.funcionario.DataCadastro;
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
            //achando idFuncionario selecionado na grid
            long idFuncionario = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFuncionario = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.ffFuncionarioDeletarMsg, this.ffFuncionarioDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.ffFuncionarioDeletarNoSelected);
                }
                else
                {
                    Library.FuncionarioBD.DeleteById(idFuncionario);
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
            List<Library.Funcionario> funcionarios;
            if (this.filtrosTextBox.Text == "")
            {
                funcionarios = Library.FuncionarioBD.FindAdvanced();
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.id", id));
                }
                else
                {
                    funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            if (funcionarios != null)
            {
                foreach (Library.Funcionario c in funcionarios)
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
            //achando idFuncionario selecionado na grid
            long idFuncionario = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idFuncionario = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando funcionario selecionado no formulario
            this.funcionario = Library.FuncionarioBD.FindById(idFuncionario);
            this.ShowValues(funcionario);
            /*************END*************/
            this.Modo = "Selecionar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void segurancaButton_Click(object sender, EventArgs e)
        {
          
        }

        private void Funcionario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
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
                List<Library.Funcionario> funcionarios = Library.FuncionarioBD.FindAdvanced();

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Funcionario c in funcionarios)
                {
                    if (i == 0)
                        this.ShowValues(c);

                    this.dataGridView1.Rows.Add(c.Id, c.Nome, c.DataCadastro);

                    i++;
                }

            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex);
            }
        }
        private void RefreshChilds()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                //if (a is Forms.Orcamento.Orcamento)
                //{
                //    Forms.Orcamento.Orcamento form = (Forms.Orcamento.Orcamento)a;
                //    form.FillFuncionario();
                //}
                //if (a is Forms.Venda.Venda)
                //{
                //    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                //    form.FillFuncionario();
                //}
                //if (a is Forms.Servico.Cadastro)
                //{
                //    Forms.Servico.Cadastro form = (Forms.Servico.Cadastro)a;
                //    form.FillFuncionario();
                //}
                //if (a is Forms.Servico.Entrega)
                //{
                //    Forms.Servico.Entrega form = (Forms.Servico.Entrega)a;
                //    form.FillFuncionario();
                //}
            }
        }

        //mostrar valores no formulario
        private void ShowValues(Library.Funcionario funcionario)
        {
            this.codigoTB.Text = string.Format("{0}", funcionario.Id);
            //this.idCargoCB.SelectedItem = string.Format("{0}", funcionario.Cargo.Id);
            //this.idSegurancaCB.SelectedItem = string.Format("{0}", funcionario.Seguranca.Id);
            this.loginTB.Text = funcionario.Login;
            this.senhaTB.Text = funcionario.Senha;
            this.bairroTB.Text = funcionario.Bairro;
            this.cepTB.Text = funcionario.Cep;
            this.celularTB.Text = funcionario.Celular;
            this.cpfTB.Text = funcionario.Cpf;
            this.emailTB.Text = funcionario.Email;
            this.enderecoTB.Text = funcionario.Endereco;
            this.estadoCB.Text = funcionario.Estado;
            this.nascimentoDTP.Text = funcionario.Nascimento.GetValueOrDefault(DateTime.MinValue).ToShortDateString();
            this.nomeTB.Text = funcionario.Nome;
            this.rgTB.Text = funcionario.Rg;
            this.siteTB.Text = funcionario.Site;
            this.telefoneTB.Text = funcionario.Telefone;
        }
        private void ShowValues()
        {
            this.codigoTB.Text = "";
            this.loginTB.Text = "";
            this.senhaTB.Text = "";
            this.senhaConfirmarTB.Text = "";
            this.bairroTB.Text = "";
            this.cepTB.Text = "";
            this.celularTB.Text = "";
            this.cpfTB.Text = "";
            this.emailTB.Text = "";
            this.enderecoTB.Text = "";
            this.estadoCB.Text = "";
            this.nascimentoDTP.Text = "";
            this.nomeTB.Text = "";
            this.rgTB.Text = "";
            this.siteTB.Text = "";
            this.telefoneTB.Text = "";
        }

        //retornar objeto funcionario com valores do formulario
        private Library.Funcionario ReturnFuncionarioFromForm()
        {
            Library.Funcionario funcionarioTemp = new Library.Funcionario();

            //funcionarioTemp.Id =  long.Parse(this.codigoTB.Text);
            funcionarioTemp.Login =  this.loginTB.Text;
            funcionarioTemp.Senha =  this.senhaTB.Text;
            funcionarioTemp.Bairro =  this.bairroTB.Text;
            funcionarioTemp.Cep =  this.cepTB.Text;
            funcionarioTemp.Celular =  this.celularTB.Text;
            funcionarioTemp.Cpf =  this.cpfTB.Text;
            funcionarioTemp.Email =  this.emailTB.Text;
            funcionarioTemp.Endereco =  this.enderecoTB.Text;
            funcionarioTemp.Estado =  this.estadoCB.Text;
            DateTime nascimento;
            if(DateTime.TryParse(this.nascimentoDTP.Text, out nascimento))
                funcionarioTemp.Nascimento = nascimento;
            else
                funcionarioTemp.Nascimento = null;
            funcionarioTemp.Nome =  this.nomeTB.Text;
            funcionarioTemp.Rg =  this.rgTB.Text;
            funcionarioTemp.Site =  this.siteTB.Text;
            funcionarioTemp.Telefone =  this.telefoneTB.Text;
            funcionarioTemp.DataCadastro = DateTime.Now;

            return funcionarioTemp;
        }

        //atualizar objeto funcionario com valores do formulario
        private Library.Funcionario UpdateFuncionarioFromForm()
        {
            Library.Funcionario funcionarioTemp = this.funcionario;

            funcionarioTemp.Id = long.Parse(this.codigoTB.Text);
            funcionarioTemp.Login = this.loginTB.Text;
            funcionarioTemp.Senha = this.senhaTB.Text;
            funcionarioTemp.Bairro = this.bairroTB.Text;
            funcionarioTemp.Cep = this.cepTB.Text;
            funcionarioTemp.Celular = this.celularTB.Text;
            funcionarioTemp.Cpf = this.cpfTB.Text;
            funcionarioTemp.Email = this.emailTB.Text;
            funcionarioTemp.Endereco = this.enderecoTB.Text;
            funcionarioTemp.Estado = this.estadoCB.Text;
            DateTime nascimento;
            if (DateTime.TryParse(this.nascimentoDTP.Text, out nascimento))
                funcionarioTemp.Nascimento = nascimento;
            else
                funcionarioTemp.Nascimento = null;
            funcionarioTemp.Nome = this.nomeTB.Text;
            funcionarioTemp.Rg = this.rgTB.Text;
            funcionarioTemp.Site = this.siteTB.Text;
            funcionarioTemp.Telefone = this.telefoneTB.Text;
            //funcionarioTemp.DataCadastro = DateTime.Now;

            return funcionarioTemp;
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
            this.panel1.Enabled = habilitado;
            this.tableLayoutPanel1.Enabled = !habilitado;
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
        private void loginTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateLogin();
        }
        private void senhaTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateSenha();
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
                this.errorProvider.SetError(this.nomeTB, this.ffFuncionarioValidateNome);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.nomeTB, "");
            }
            return true;
        }
        private bool ValidateLogin()
        {
            if (this.loginTB.Text == "")
            {
                this.errorProvider.SetError(this.loginTB, this.ffFuncionarioValidateLogin);
                return false;
            }
            else
            {
                this.errorProvider.SetError(this.loginTB, "");
            }
            return true;
        }
        private bool ValidateSenha()
        {
            if (this.modo == "Cadastrar")
            {
                if (this.senhaTB.Text == "")
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenha);
                    return false;
                }
                else if ((this.senhaTB.TextLength < 4) || (this.senhaTB.TextLength > 8))
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenhaLength);
                    return false;
                }
                else if (this.senhaTB.Text != this.senhaConfirmarTB.Text)
                {
                    this.errorProvider.SetError(this.senhaTB, this.ffFuncionarioValidateSenhaIncompatible);
                    return false;
                }
                else
                {
                    this.errorProvider.SetError(this.senhaTB, "");
                }
            }
            return true;
        }
        private bool ValidateCpf()
        {
            if (this.cpfTB.Text == "")
            {
                this.warnigProvider.SetError(this.cpfTB, this.ffFuncionarioValidateCpf);
                return false;
            }
            else if (Library.Classes.Validacao.BoolCPF(this.cpfTB.Text) == false)
            {
                this.warnigProvider.SetError(this.cpfTB, this.ffFuncionarioValidateCpfInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.cpfTB, "");
            }
            return true;
        }
        private bool ValidateEmail()
        {
            if (this.emailTB.Text == "")
            {
                this.warnigProvider.SetError(this.emailTB, this.ffFuncionarioValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(this.emailTB, this.ffFuncionarioValidateEmailInvalid);
            }
            else
            {
                this.warnigProvider.SetError(this.emailTB, "");
            }
            return true;
        }

        private bool ValidateForm()
        {
            bool bValidNome = ValidateNome();
            bool bValidLogin = ValidateLogin();
            bool bValidSenha = ValidateSenha();


            if (bValidNome & bValidLogin & bValidSenha)
                return true;

            return false;
        }
        
        
    }
}
