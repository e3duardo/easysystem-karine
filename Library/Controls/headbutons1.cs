using System;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class headbutons1 : UserControl
    {
        public headbutons1()
        {
            InitializeComponent();
        }

        //load's
        private void headbutons1_Load(object sender, EventArgs e)
        {
            this.MenuDisabler(false, false, false, false, false);
        }

        //method's
        public void MenuDisabler(bool novo, bool editar, bool salvar, bool cancelar, bool excluir)
        {
            this.novoButton.Enabled = novo;
            this.editarButton.Enabled = editar;
            this.salvarButton.Enabled = salvar;
            this.cancelarButton.Enabled = cancelar;
            this.excluirButton.Enabled = excluir;
        }

        
    }
}
