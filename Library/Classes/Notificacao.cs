using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Drawing;

namespace Library.Classes
{
    static public class Notificacao
    {

        static public string GerarNotificacao(Library.Cliente cliente)
        {
            DateTime hoje = DateTime.Now;
            CultureInfo culture = new CultureInfo("pt-BR");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("NOTIFICAÇÃO EXTRAJUDICIAL");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine(cliente.Nome + ", localizado na " + cliente.Endereco + ", Bairro " + cliente.Bairro + ",  na cidade de " + cliente.Cidade + " - " + cliente.Estado + ", vem por meio desta, solicitar o comparecimento de Vossa Senhoria, com intuito de obter uma solução amigável para o problema");
            sb.AppendLine("");
            sb.AppendLine("Certos de que seremos prontamente atendidos, desde já agradecemos");
            sb.AppendLine("");
            sb.AppendLine("Sem mais para o momento,");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Miracema, " + hoje.Day + ", de " + hoje.ToString("MMMM", culture) + " de " + hoje.Year + " - " + hoje.ToString("dddd",culture));
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("OBS: Favor entrar em contato, sob pena da adoção das medidas judiciais cabíveis.");
            sb.AppendLine("");
            sb.AppendLine("");
            
            return sb.ToString();
        }


    }
}
