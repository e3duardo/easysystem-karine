using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Forms.Funcionario
{
    public partial class MudarSenha : Form
    {
        private Library.Funcionario funcionario;

        public MudarSenha()
        {
            InitializeComponent();
        }

        private void MudarSenha_Load(object sender, EventArgs e)
        {
            this.senhaNovaTB.Enabled = false;
            this.senhaNovaConfirmarTB.Enabled = false;
        }

        private void logarButton_Click(object sender, EventArgs e)
        {
            string message = "";

            if (Library.FuncionarioBD.Logar(this.loginTB.Text, this.senhaTB.Text, out funcionario, out message))
            {
                this.mensagemL.Text = message;
                this.senhaNovaTB.Enabled = true;
                this.senhaNovaConfirmarTB.Enabled = true;
            }
            else
            {
                this.mensagemL.Text = message;
                this.senhaNovaTB.Enabled = false;
                this.senhaNovaConfirmarTB.Enabled = false;
            }
        }

        private void aplicarButton_Click(object sender, EventArgs e)
        {
            this.funcionario.Senha = senhaNovaTB.Text;

            Library.FuncionarioBD.Update(this.funcionario);

            this.senhaNovaTB.Enabled = false;
            this.senhaNovaConfirmarTB.Enabled = false;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MudarSenha_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.RemoveForm(this);
        }

    }
}
