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
    public partial class REmpresaReceber : Form
    {
        public REmpresaReceber()
        {
            InitializeComponent();
        }

        private void Standard3_Load(object sender, EventArgs e)
        {
            this.EmpresaValoresReceberTableAdapter.Fill(this.dataSet1.EmpresaValoresReceber);

            this.reportViewer1.RefreshReport();

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
