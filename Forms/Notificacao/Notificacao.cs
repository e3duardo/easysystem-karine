using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Library.Classes;
using Library.Configuration;

namespace Forms.Notificacao
{
    public partial class Notificacao : Form
    {
        public Notificacao()
        {
            InitializeComponent();
        }

        private void NotificacaoView_Load(object sender, EventArgs e)
        {
            DSettings set = new DSettings();
            DAppSettings.Load(set);


            List<Library.TermoCompromisso> termos = Library.TermoCompromissoBD.FindAdvanced();


            foreach (Library.TermoCompromisso termo in termos)
            {
                List<Library.Notificacao> notificacoes = Library.NotificacaoBD.FindAdvanced(new QItem("tc.id", termo.Id), new QItem("tc.status", (int)Library.TCStatus.notificando));

                if (notificacoes != null)
                {
                    switch (notificacoes.Count)
                    {
                        case 0:
                            break;
                        case 1:

                            DateTime data11 = DateTime.Parse(notificacoes[0].Data.AddDays(set.textBoxNotificacao1).ToShortDateString());

                            if (data11 <= DateTime.Today)
                                this.dataGridView1.Rows.Add(termo.Cliente.Nome, termo.Empresa.Nome, notificacoes[0].Data);

                            break;
                        case 2:

                            DateTime data22 = DateTime.Parse(notificacoes[1].Data.AddDays(set.textBoxNotificacao2).ToShortDateString());

                            if (data22 <= DateTime.Today)
                                this.dataGridView1.Rows.Add(termo.Cliente.Nome, termo.Empresa.Nome, notificacoes[0].Data, notificacoes[1].Data);

                            break;
                        case 3:

                            DateTime data33 = DateTime.Parse(notificacoes[2].Data.AddDays(set.textBoxNotificacao2).ToShortDateString());

                            if (data33 <= DateTime.Today)
                                this.dataGridView1.Rows.Add(termo.Cliente.Nome, termo.Empresa.Nome, notificacoes[0].Data, notificacoes[1].Data, notificacoes[2].Data);

                            break;
                    }
                }
            }



            //this.dataGridView1.DataSource = Library.TermoCompromissoBD.FindAdvanced();
        }
    }
}
