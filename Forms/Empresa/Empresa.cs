using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;



namespace Forms.Empresa
{
    public partial class Empresa : Form
    {
        /******************************************************/
        string fcEmpresaDeletarMsg = "Deseja realmente excluir esta empresa?";
        string fcEmpresaDeletarMsgTitle = "Excluir";
        string fcEmpresaDeletarNoSelected = "Selecione uma empresa";

        string fcEmpresaValidateNome = "Informe um nome.";
        string fcEmpresaValidateEmail = "Informe um email.";
        string fcEmpresaValidateEmailInvalid = "Email com formato inválido.";
        /******************************************************/


        private string Modo{get;set;}

        public int IndexSelecionado { get; set; }

        private Library.Empresa empresa; 

        public Empresa()
        {
            InitializeComponent();
        }


        /*
         * FUNÇÕES DE EVENTOS
         */

        private void Empresa_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.MenuDisabler(true, false, false, false, false);
            this.RefreshForm();
            this.Modo = "visualizar";
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

            codigoTB.Text = Library.EmpresaBD.GetNextId().ToString();
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
            //achando idEmpresa selecionado na grid
            long idEmpresa = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idEmpresa = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando empresa selecionado no formulario
            this.empresa = Library.EmpresaBD.FindById(idEmpresa);
            this.ShowValues(this.empresa);
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


                if (this.Modo == "Cadastrar")
                {
                    //criando um empresa com valores do formulário
                    this.empresa = this.ReturnCargoFromForm();
                    //salvando empresa
                    Library.EmpresaBD.Save(this.empresa);

                    this.dataGridView1.Rows.Add(this.empresa.Id, this.empresa.Nome, this.empresa.DataCadastro);
                }
                else
                {
                    this.empresa = this.UpdateCargoFromForm();
                    //atualizando empresa
                    Library.EmpresaBD.Update(this.empresa);

                    this.dataGridView1.Rows[IndexSelecionado].Cells[0].Value = this.empresa.Id;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[1].Value = this.empresa.Nome;
                    this.dataGridView1.Rows[IndexSelecionado].Cells[2].Value = this.empresa.DataCadastro;
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
            //achando idEmpresa selecionado na grid
            long idEmpresa = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idEmpresa = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            if (MessageBox.Show(this.fcEmpresaDeletarMsg, this.fcEmpresaDeletarMsgTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //se não tiver selecionado mostra mensagem se estiver deleta e atualiza formulario
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show(this.fcEmpresaDeletarNoSelected);
                }
                else
                {
                    Library.EmpresaBD.DeleteById(idEmpresa);
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
            List<Library.Empresa> empresas;
            if (this.filtrosTextBox.Text == "")
            {
                empresas = Library.EmpresaBD.FindAdvanced(new QItem("e.pessoa", "Juridica"));
            }
            else
            {
                long id;
                if (long.TryParse(this.filtrosTextBox.Text, out id))
                {
                    empresas = Library.EmpresaBD.FindAdvanced(new QItem("e.pessoa", "Juridica"), new QItem("e.id", id));
                }
                else
                {
                    empresas = Library.EmpresaBD.FindAdvanced(new QItem("e.pessoa", "Juridica"), new QItem("e.nome LIKE %%", this.filtrosTextBox.Text));
                }
            }

            this.dataGridView1.Rows.Clear();
            if (empresas != null)
            {
                foreach (Library.Empresa c in empresas)
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
            //achando idEmpresa selecionado na grid
            long idEmpresa = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                idEmpresa = (long)this.dataGridView1.SelectedRows[i].Cells["idDGVTBC"].Value;
            }
            //mostrando empresa selecionado no formulario
            this.empresa = Library.EmpresaBD.FindById(idEmpresa);
            this.ShowValues(empresa);
            /*************END*************/
            this.Modo = "Selecionar";
            this.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarButton.PerformClick();
        }

        private void Empresa_FormClosed(object sender, FormClosedEventArgs e)
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
                List<Library.Empresa> empresas = Library.EmpresaBD.FindAdvanced(new QItem("e.pessoa", "Juridica"));

                int i = 0;
                this.dataGridView1.Rows.Clear();
                foreach (Library.Empresa c in empresas)
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
                //    form.FillEmpresa();
                //}
                //if (a is Forms.Venda.Venda)
                //{
                //    Forms.Venda.Venda form = (Forms.Venda.Venda)a;
                //    form.FillEmpresa();
                //}
                //if (a is Forms.Servico.Cadastro)
                //{
                //    Forms.Servico.Cadastro form = (Forms.Servico.Cadastro)a;
                //    form.FillEmpresa();
                //}
                //if (a is Forms.Servico.Entregar)
                //{
                //    Forms.Servico.Entregar form = (Forms.Servico.Entregar)a;
                //    form.FillEmpresa();
                //}
            }
        }
        //mostrar valores no formulario
        private void ShowValues(Library.Empresa empresa)
        {
            this.codigoTB.Text = string.Format("{0}", empresa.Id);
            this.bairroTB.Text = empresa.Bairro;
            this.celularTB.Text = empresa.Celular;
            this.cepTB.Text = empresa.Cep;
            this.cidadeTB.Text = empresa.Cidade;
            this.cnpjTB.Text = empresa.Cnpj;
            this.emailTB.Text = empresa.Email;
            this.enderecoTB.Text = empresa.Endereco;
            this.estadoCB.Text = empresa.Estado;
            this.faxTB.Text = empresa.Fax;
            this.inscricaoEstadualTB.Text = empresa.InscricaoEstadual;
            this.nomeTB.Text = empresa.Nome;
            this.nomeContatoTB.Text = empresa.NomeContato;
            this.nomeFantasiaTB.Text = empresa.NomeFantasia;
            this.observacoesTB.Text = empresa.Observacoes;
            this.siteTB.Text = empresa.Site;
            this.telefoneTB.Text = empresa.Telefone;
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
        }

        //retornar objeto empresa com valores do formulario
        private Library.Empresa ReturnCargoFromForm()
        {
            Library.Empresa empresaTemp = new Library.Empresa();

            //empresaTemp.Id =  long.Parse(this.codigoTB.Text);
            empresaTemp.Bairro =  this.bairroTB.Text;
            empresaTemp.Celular =  this.celularTB.Text;
            empresaTemp.Cep = this.cepTB.Text;
            empresaTemp.Cidade = this.cidadeTB.Text;
            empresaTemp.Cnpj = this.cnpjTB.Text;
            empresaTemp.Email =  this.emailTB.Text;
            empresaTemp.Endereco =  this.enderecoTB.Text;
            empresaTemp.Estado =  this.estadoCB.Text;
            empresaTemp.Fax = this.faxTB.Text;
            empresaTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            empresaTemp.Nome =  this.nomeTB.Text;
            empresaTemp.NomeContato = this.nomeContatoTB.Text;
            empresaTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            empresaTemp.Observacoes = this.observacoesTB.Text;
            empresaTemp.Site =  this.siteTB.Text;
            empresaTemp.Telefone =  this.telefoneTB.Text;
            empresaTemp.DataCadastro = DateTime.Now;

            empresaTemp.Cpf = null;
            empresaTemp.Rg = null;
            empresaTemp.ReferenciaComercial = null;
            empresaTemp.Nascimento = null;
            
            empresaTemp.Pessoa = "Juridica";

            return empresaTemp;
        }

        //atualizar objeto empresa com valores do formulario
        private Library.Empresa UpdateCargoFromForm()
        {
            Library.Empresa empresaTemp = this.empresa;

            empresaTemp.Id =  long.Parse(this.codigoTB.Text);
            empresaTemp.Bairro = this.bairroTB.Text;
            empresaTemp.Celular = this.celularTB.Text;
            empresaTemp.Cep = this.cepTB.Text;
            empresaTemp.Cidade = this.cidadeTB.Text;
            empresaTemp.Cnpj = this.cnpjTB.Text;
            empresaTemp.Email = this.emailTB.Text;
            empresaTemp.Endereco = this.enderecoTB.Text;
            empresaTemp.Estado = this.estadoCB.Text;
            empresaTemp.Fax = this.faxTB.Text;
            empresaTemp.InscricaoEstadual = this.inscricaoEstadualTB.Text;
            empresaTemp.Nome = this.nomeTB.Text;
            empresaTemp.NomeContato = this.nomeContatoTB.Text;
            empresaTemp.NomeFantasia = this.nomeFantasiaTB.Text;
            empresaTemp.Observacoes = this.observacoesTB.Text;
            empresaTemp.Site = this.siteTB.Text;
            empresaTemp.Telefone = this.telefoneTB.Text;
            //empresaTemp.DataCadastro = DateTime.Now;

            return empresaTemp;
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
                this.errorProvider.SetError(nomeTB, this.fcEmpresaValidateNome);
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
                this.warnigProvider.SetError(emailTB, this.fcEmpresaValidateEmail);
                return false;
            }
            else if (Library.Classes.Validacao.BoolEmail(this.emailTB.Text) == false)
            {
                this.warnigProvider.SetError(emailTB, this.fcEmpresaValidateEmailInvalid);
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
        
    }
}
