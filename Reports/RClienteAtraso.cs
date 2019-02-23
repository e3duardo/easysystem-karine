using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports
{
    public partial class RClienteAtraso : Form
    {
        public RClienteAtraso()
        {
            InitializeComponent();
        }

        private void Standard2_Load(object sender, EventArgs e)
        {
            try
            {
                this.clienteComParcelasAtrasadasTableAdapter.Fill(this.dataSet1.ClienteComParcelasAtrasadas);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void checkBoxInicio_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInicio.Enabled = checkBoxInicio.Checked;
            textBoxInicio.Text = "";
        }

        private void checkBoxTermino_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTermino.Enabled = checkBoxTermino.Checked;
            textBoxTermino.Text = "";
        }
    }
}
