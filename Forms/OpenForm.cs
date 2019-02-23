using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public class OpenForm
    {
        static public void RemoveForm(Form form)
        {

        }
        static public void RefreshNotificacoes()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Start)
                {
                    Forms.Start st = (Forms.Start)a;
                    st.LoadNotificacaoStatus();
                    break;
                }
            }
        }

        static public void RefreshParcelas()
        {
            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Start)
                {
                    Forms.Start st = (Forms.Start)a;
                    st.LoadParcelasAtrasadas();
                    break;
                }
            }
        }

        static public void OpenEmpresa()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Empresa.Empresa)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Empresa.Empresa childFormEmpresa = new Forms.Empresa.Empresa();
                childFormEmpresa.Show();
                childFormEmpresa.Disposed += delegate { childFormEmpresa.Dispose(); };
            }
        }
        static public void OpenClienteFisica()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.ClienteFisica)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Cliente.ClienteFisica childFormClienteFisica = new Forms.Cliente.ClienteFisica();
                childFormClienteFisica.Show();
                childFormClienteFisica.Disposed += delegate { childFormClienteFisica.Dispose(); };
            }

        }
        static public void OpenClienteJuridica()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.ClienteJuridica)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Cliente.ClienteJuridica childFormClienteJuridica = new Forms.Cliente.ClienteJuridica();
                childFormClienteJuridica.Show();
                childFormClienteJuridica.Disposed += delegate { childFormClienteJuridica.Dispose(); };
            }

        }
        static public void OpenFuncionario()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Funcionario.Funcionario)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Funcionario.Funcionario childFormFuncionario = new Forms.Funcionario.Funcionario();
                childFormFuncionario.Show();
                childFormFuncionario.Disposed += delegate { childFormFuncionario.Dispose(); };
            }

        }
        static public void OpenMudarSenha()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Funcionario.MudarSenha)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Funcionario.MudarSenha childFormMudarSenha = new Forms.Funcionario.MudarSenha();
                childFormMudarSenha.Show();
                childFormMudarSenha.Disposed += delegate { childFormMudarSenha.Dispose(); };
            }
        }
        static public void OpenClientes()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.Cliente.Clientes)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.Cliente.Clientes childCliente = new Forms.Cliente.Clientes();
                childCliente.Show();
                childCliente.Disposed += delegate { childCliente.Dispose(); };
            }
        }
        static public void OpenTermoCompromissoParcelaQuitar()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromissoParcela.Quitar)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromissoParcela.Quitar childParcela = new Forms.TermoCompromissoParcela.Quitar();
                childParcela.Show();
                childParcela.Disposed += delegate { childParcela.Dispose(); };
            }
        }
        static public void OpenTermoCompromissoParcelaAtrasadas()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromissoParcela.Atrasadas)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromissoParcela.Atrasadas childParcelaAtrasadas = new Forms.TermoCompromissoParcela.Atrasadas();
                childParcelaAtrasadas.Show();
                childParcelaAtrasadas.Disposed += delegate { childParcelaAtrasadas.Dispose(); };
            }
        }
        static public void OpenStepByStep()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromisso.stepbystep)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromisso.stepbystep childStepStep = new Forms.TermoCompromisso.stepbystep();
                childStepStep.Show();
                childStepStep.Disposed += delegate { childStepStep.Dispose(); };
            }
        }
        static public void OpenVincularTermosCompromissoView()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromisso.VincularTermosCompromissoView)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromisso.VincularTermosCompromissoView childStepStep = new Forms.TermoCompromisso.VincularTermosCompromissoView();
                childStepStep.Show();
                childStepStep.Disposed += delegate { childStepStep.Dispose(); };
            }
        }
        static public void OpenNotificacaoView()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromisso.NotificacaoView)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromisso.NotificacaoView childStepStep = new Forms.TermoCompromisso.NotificacaoView();
                childStepStep.Show();
                childStepStep.Disposed += delegate { childStepStep.Dispose(); };
            }
        }
        static public void OpenTermoCompromissoView()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromisso.TermoCompromissoView)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromisso.TermoCompromissoView childStepStep = new Forms.TermoCompromisso.TermoCompromissoView();
                childStepStep.Show();
                childStepStep.Disposed += delegate { childStepStep.Dispose(); };
            }
        }
        static public void OpenJudicialView()
        {
            bool verifica = false;

            foreach (Form a in System.Windows.Forms.Application.OpenForms)
            {
                if (a is Forms.TermoCompromisso.JudicialView)
                {
                    a.BringToFront();
                    verifica = true;
                    break;
                }
            }

            if (!verifica)
            {
                Forms.TermoCompromisso.JudicialView childStepStep = new Forms.TermoCompromisso.JudicialView();
                childStepStep.Show();
                childStepStep.Disposed += delegate { childStepStep.Dispose(); };
            }
        }
    }
}
