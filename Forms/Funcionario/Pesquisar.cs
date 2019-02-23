using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;

namespace Forms.Funcionario
{
    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            InitializeComponent();
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {

        }

        private void pesquisarButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            /************BEGIN************/
            List<Library.Funcionario> funcionarios = null;
            long idCargo = 0;
            long.TryParse(this.codigoTB.Text, out idCargo);

            if (this.nomeTB.Text != "")
                funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.nome LIKE %%", this.nomeTB.Text));

            if (idCargo != 0)
                funcionarios = Library.FuncionarioBD.FindAdvanced(new QItem("f.id", this.codigoTB.Text));

            if (this.nomeTB.Text == "" & idCargo == 0)
                funcionarios = Library.FuncionarioBD.FindAdvanced();

            this.resultadoDGV.Rows.Clear();
            if (funcionarios != null)
                foreach (Library.Funcionario cg in funcionarios)
                {
                    this.resultadoDGV.Rows.Add(cg.Id, cg.Nome, cg.DataCadastro);
                }
            /*************END*************/
            this.Cursor = Cursors.Default;
        }

        private void selecionarButton_Click(object sender, EventArgs e)
        {
            
        }



        /*
        Library.Classes.Seguranca seguranca = new Library.Classes.Seguranca("funcionarioPesquisar");
        
        private long _idFuncionario;
        public long idFuncionario
        {
            get { return _idFuncionario; }
            set { _idFuncionario = value; }
        }
        
        public Pesquisar()
        {
            InitializeComponent();
        }
        
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {
                if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Key Overrided Events Error:" + Ex.Message);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void pesquisarButton_Click(object sender, EventArgs e)
        {

        }
        
        private void funcionarioPesquisar_Load(object sender, EventArgs e)
        {
            //.Fill(//this.dataset.Seguranca);
            //.Fill(//this.dataset.Funcionario);
            //.Fill(//this.dataset.System);

            if (seguranca.VerificaSeguranca())
            {
                //panel.Enabled = true;
            }
            else
            {
                //panel.Enabled = false;
            }
        }
        */
    }
}
