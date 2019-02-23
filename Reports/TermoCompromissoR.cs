using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using Library.Converter;

namespace Reports
{
    public partial class TermoCompromissoR : Form
    {
        public Library.Cliente cliente { get; set; }
        public decimal valor { get; set; }

        public TermoCompromissoR()
        {
            InitializeComponent();
        }

        private void Standard_Load(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Now;
            CultureInfo culture = new CultureInfo("pt-BR");


            string nome = cliente.Nome;
            if (nome == "")
                nome = "............................................................................................";
            string endereco = cliente.Endereco;
            if (endereco == "")
                endereco = ".................................................";
            string enderecoNumero = cliente.EnderecoNumero.ToString();
            if (enderecoNumero == "")
                enderecoNumero = "...........";
            string bairro = cliente.Bairro;
            if (bairro == "")
                bairro = ".......................";
            string cidade = cliente.Cidade;
            if (cidade == "")
                cidade = "...........................................";
            string estado = cliente.Estado;
            if (estado == "")
                estado = "........";
            string cpf = cliente.Cpf;
            if (cpf == "")
                cpf = "....................................";
            string rg = cliente.Rg;
            if (rg == "")
                rg = ".......................................";
            string telefone = cliente.Telefone;
            if (telefone == "")
                telefone = "..........................................";

            ReportParameter[] parameters = new ReportParameter[14];
            parameters[0] = new ReportParameter("clienteNome", nome);
            parameters[1] = new ReportParameter("clienteEndereco", endereco);
            parameters[2] = new ReportParameter("clienteNumero", enderecoNumero);
            parameters[3] = new ReportParameter("clienteBairro", bairro);
            parameters[4] = new ReportParameter("clienteCidade", cidade);
            parameters[5] = new ReportParameter("clienteEstado", estado);

            parameters[6] = new ReportParameter("dia", hoje.Day.ToString());
            parameters[7] = new ReportParameter("mes", hoje.ToString("MMMM", culture));
            parameters[8] = new ReportParameter("ano", hoje.Year.ToString());
            parameters[9] = new ReportParameter("diaSemana", hoje.ToString("dddd", culture));

            parameters[10] = new ReportParameter("clienteCpf", cpf);
            parameters[11] = new ReportParameter("clienteRg", rg);
            parameters[12] = new ReportParameter("clienteTelefone", telefone);

            parameters[13] = new ReportParameter("valor", valor.ConvertToMoneyString());

            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }


    }
}
