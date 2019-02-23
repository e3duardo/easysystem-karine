using System;

namespace Library.Classes
{
    public class StringFunctions
    {
        public StringFunctions()
        {
        }
        
        
        
        /// <summary>
        /// CortarString
        /// </summary>
        public string CS(string text, int length)
        {
            return CortarString(text, length);
        }
        
        /// <summary>
        /// MesclarString
        /// </summary>
        public string MS(string text, int length, string alinhamento = "meio", char spacer = ' ', bool lockPar = false)
        {
            return MesclarString(text, length, alinhamento, spacer, lockPar);
        }
        
        /// <summary>
        /// CortarStringPreenchendo
        /// </summary>
        public string CSP(string text, int length, char alinhamento = 'e')
        {
            return CortarStringPreenchendo(text, length, alinhamento);
        }

        static public string CortarString(string text, int length)
        {
            // Valida caracteres
            if (text.Length < length || length == 0)
                return text;

            // Verifica espaços
            String trimmed = text.Substring(0, length);

            Int32 i = trimmed.LastIndexOf(' ');

            if (i != -1)
                trimmed = trimmed.Substring(0, i);

            // Retorna texto
            return trimmed;
        }

        static public string MesclarString(string text, int length, string alinhamento = "meio", char spacer = ' ', bool lockPar = false)
        {
            // Valida caracteres
            if (text.Length < length || length == 0)
                text = CortarString(text, length);

            int qtMeio = (length - text.Length) / 2;
            int qtLado = length - text.Length;

            string str = "";
            if (alinhamento == "meio" | alinhamento == "m")
            {
                if (lockPar)
                {
                    int length1 = length;

                    if (length % 2 != 0)
                        length1 = length + 1;

                    qtMeio = (length1 - text.Length) / 2;

                    if (qtMeio % 2 != 0)
                    {
                        str = "";
                        str += text;
                        for (int i = 0; i < qtMeio; i++)
                        {
                            str += spacer;
                        }
                        return CortarString(str, length1);
                    }
                }
                str = "";
                for (int i = 0; i < qtMeio; i++)
                {
                    str += spacer;
                }
                str += text;

                for (int i = 0; i < qtMeio; i++)
                {
                    str += spacer;
                }
                return CortarString(str, length);
            }
            if (alinhamento == "direita" | alinhamento == "d")
            {
                str = "";
                for (int i = 0; i < qtLado; i++)
                {
                    str += spacer;
                }
                str += text;
                return CortarString(str, length);
            }
            if (alinhamento == "esquerda" | alinhamento == "e")
            {
                str = "";
                str += text;
                for (int i = 0; i < qtLado; i++)
                {
                    str += spacer;
                }
                return CortarString(str, length);
            }


            // Retorna texto
            return text;
        }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <param name="alinhamento">d ou e</param>
        /// <returns></returns>
        static public string CortarStringPreenchendo(string text, int length, char alinhamento = 'e')
        {
            string str = CortarString(text, length);
            if (alinhamento == 'e')
            {
                return string.Format("{0," + -length + "}", text);
            }
            else
            {
                return string.Format("{0," + length + "}", text);
            }
        }

        /*static public string ColunsString(int lengthTotal, char spacer = ' ', params Library.Classes.Item[] args)
        {
            //definindo variavel para contar quantas palavras existem
            int countArgs = args.Length;
            //definindo variavel para contar tamanho total dessas palavras
            int countLengthTotal = 0;
            for (int i = 0; i < countArgs; i++)
            {
                countLengthTotal += args[i].Value;
            }
            //verificando se tamanho total das palavras juntas é maior que o tamanho resultante da frase
            if (countLengthTotal > lengthTotal)
            {
                //diminuir o valor de cada palavra
            }
            //10 + 9 + 5 = 24
            //50 - 24 = 26
            //26 / 3 = 8,666666...



            string srt = "";
            if (countArgs == 3)
            {
                Console.WriteLine("tem 3 args");
                if ((args[0].Alinhamento == "e" | args[0].Alinhamento == "esquerda") && (args[1].Alinhamento == "m" | args[1].Alinhamento == "meio") && (args[2].Alinhamento == "d" | args[2].Alinhamento == "direita"))
                {
                    Console.WriteLine("tem 3 args alinhado esquerda meio direita");
                    int metade = lengthTotal / 2;
                    int metadeSemMeio = (lengthTotal - args[1].Value) / 2;

                    int metade1 = metadeSemMeio - args[0].Value;
                    int metade2 = metadeSemMeio - args[2].Value;

                    int spacomenor = lengthTotal - countLengthTotal;
                    int spaco = (spacomenor / countArgs) + 1;


                    srt += MesclarString(args[0].Text, args[0].Value, args[0].Alinhamento, args[0].Spacer, true);

                    srt += MesclarString("", metade2, args[0].Alinhamento, args[0].Spacer);

                    srt += MesclarString(args[1].Text, args[1].Value, args[1].Alinhamento, args[1].Spacer, true);

                    srt += MesclarString("", metade1, args[2].Alinhamento, args[2].Spacer);

                    srt += MesclarString(args[2].Text, args[2].Value, args[2].Alinhamento, args[2].Spacer, true);

                }
            }

            return MesclarString(srt, lengthTotal, "e", spacer);
        }*/
    }
}
