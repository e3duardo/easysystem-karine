using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Globalization;

namespace Reports
{
    public partial class NotificacaoR : Form
    {
        public Library.Cliente cliente { get; set; }
        public string Texto { get; set; }


        public NotificacaoR()
        {  
            InitializeComponent();
        }

        private void Standard_Load(object sender, EventArgs e)
        {
            try
            {
                if (cliente != null)
                {
                    DateTime hoje = DateTime.Now;
                    CultureInfo culture = new CultureInfo("pt-BR");


                    ReportParameter[] parameters = new ReportParameter[6];
                    parameters[0] = new ReportParameter("clienteNome", cliente.Nome);
                    parameters[1] = new ReportParameter("dia", hoje.Day.ToString());
                    parameters[2] = new ReportParameter("mes", hoje.ToString("MMMM", culture));
                    parameters[3] = new ReportParameter("ano", hoje.Year.ToString());
                    parameters[4] = new ReportParameter("diaSemana", hoje.ToString("dddd", culture));
                    parameters[5] = new ReportParameter("corpoTexto", this.Texto);

                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Notificacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = MessageBox.Show("Deseja salvar esta notificação", "Notificação", MessageBoxButtons.YesNo);
        }


    }
}
