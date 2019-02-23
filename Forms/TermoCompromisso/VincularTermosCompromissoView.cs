using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Classes;
using Library;

namespace Forms.TermoCompromisso
{
    public partial class VincularTermosCompromissoView : Form
    {
        public VincularTermosCompromissoView()
        {
            InitializeComponent();
        }

        private void VincularTermosCompromissoView_Load(object sender, EventArgs e)
        {
            FillEmpresa();
            FillCliente();
            comboBoxEmpresa.SelectedIndex = -1;
            comboBoxCliente.SelectedIndex = -1;
        }

        private void comboBoxEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTermosCompromissos();
        }

        private void buttonVincular_Click(object sender, EventArgs e)
        {
            Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;
            Library.Empresa empresa = (Library.Empresa)comboBoxEmpresa.SelectedItem;

            List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced(new QItem("c.id", cliente.Id), new QItem("e.id", empresa.Id));

            if (termos.Count >= 1)
            {
                string msg = string.Format("Já existe um vinculo entre o cliente \"{0}\" com a empresa \"{1}\"", cliente.Nome, empresa.Nome);
                MessageBox.Show(msg, "Vincular Cliente/Empresa");
            }
            else
            {
                string msg = string.Format("Deseja mesmo vincular o cliente \"{0}\" com a empresa \"{1}\"?", cliente.Nome, empresa.Nome);

                if (MessageBox.Show(msg, "Vincular Cliente/Empresa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (cliente != null && empresa != null)
                    {
                        Library.TermoCompromisso tc = new Library.TermoCompromisso();
                        tc.Cliente = cliente;
                        tc.Empresa = empresa;
                        tc.Data = DateTime.Now;
                        tc.Status = (int)Library.TCStatus.aberto;

                        Library.TermoCompromissoBD.Save(tc);
                    }
                }
            }

            LoadTermosCompromissos();
        }

        private void VincularTermosCompromissoView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.OpenForm.OpenStepByStep();
        }

        public void FillEmpresa()
        {
            comboBoxEmpresa.DisplayMember = "nome";
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DataSource = Library.EmpresaBD.FindAdvanced(new QItem("ORDER BY", "e.nome"));
        }

        public void FillCliente()
        {
            comboBoxCliente.DisplayMember = "nome";
            comboBoxCliente.ValueMember = "id";
            comboBoxCliente.DataSource = Library.ClienteBD.FindAdvanced(new QItem("ORDER BY", "c.nome"));
        }

        private void LoadTermosCompromissos()
        {
            try
            {
                Library.Cliente cliente = (Library.Cliente)comboBoxCliente.SelectedItem;

                if (cliente != null)
                {
                    List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced(new QItem("c.id", cliente.Id));

                    dataGridView1.Rows.Clear();
                    foreach (Library.TermoCompromisso tc in termos)
                    {
                        if (tc.Status == (int)TCStatus.aberto || tc.Status == (int)TCStatus.notificando)
                        {
                            string stat = "";
                            if (tc.Status == (int)TCStatus.aberto)
                                stat = "Vinculado";
                            else if (tc.Status == (int)TCStatus.notificando)
                            {
                                stat = string.Format("Nodificado ({0})", Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", tc.Id)).Count);
                            }

                            dataGridView1.Rows.Add(tc.Empresa.Nome, tc.Data, stat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}
