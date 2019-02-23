using System.Collections.Generic;
using System.Text;

namespace Library.Classes
{
    public class Print
    {
        private Print()
        {
        }


        #region Definição de notas

        static public string GeneratorStringCaixa()
        {
            return GeneratorHead();
        }

        #endregion


        #region Definições compartilhadas
        static public string GeneratorHead()
        {
            Library.Classes.StringFunctions sf = new Library.Classes.StringFunctions();

            StringBuilder sb = new StringBuilder();

            sb.Append("               CENTERCAR                \n");
            sb.Append("      ----------------------------      \n");
            sb.Append("          AV NILO PEÇANHA, XXX          \n");
            sb.Append("            (22) 3852-XXXX              \n");
            //sb.Append("----------------------------------------\n");

            return sb.ToString();
        }
        
        static public string GeneratorRodape(Library.Cliente cliente)
        {
            Library.Classes.StringFunctions sf = new Library.Classes.StringFunctions();

            StringBuilder sb = new StringBuilder();

            sb.Append("\n");
            sb.Append("\n");
            sb.Append(sf.MS("", 50, "direita", '-') + "\n");
            sb.Append(sf.MS(cliente.Nome, 50, "m", ' ') + "\n");

            return sb.ToString();
        }

        /*parcelas
        public string GerarImpressao()
        {
            string retorno = "";

            for (int i = 0; i < this.parcelasDGV.RowCount; i++)
            {
                decimal vl = (decimal)this.parcelasDGV["valor", i].Value;
                int pg = (int)this.parcelasDGV["pago", i].Value;
                string dt = (string)this.parcelasDGV["data", i].Value;

                int vllen = vl.ToString().Length;

                retorno += (string.Format("PARCELA {0}{1," + (42 - ((i + 1).ToString().Length)) + ":C}\n", i + 1, vl));

                retorno += (string.Format("Data: {0,44}\n", dt));
            }

            //retorno += ("PARCELA 001                                  50,00\n");
            //retorno += ("Data da venda: 22/05/2010               Refer.0001\n");

            return retorno;
        }*/
        #endregion
    }
}
