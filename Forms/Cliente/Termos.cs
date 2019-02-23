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
    public partial class Termos : Form
    {
        public Library.Cliente Cliente { get; set; }

        public Termos()
        {
            InitializeComponent();
        }

        private void Termos_Load(object sender, EventArgs e)
        {
            foreach(Library.TermoCompromisso tc in Library.TermoCompromissoBD.FindAdvanced(new QItem("c.id",Cliente.Id)))
            {
                dataGridView1.Rows.Add(tc.Empresa.Nome);
            }
        }
    }
}
