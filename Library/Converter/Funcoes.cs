using System;
using System.Windows.Forms;

namespace Library.Converter
{
    static public class Funcoes
    {
        static private string StringRemoveChar(string value)
        {
            string str = "";
            int nvirgulas = 0;

            foreach (char s in value)
            {
                if (Char.IsDigit(s))
                    str += s;
                else if (Char.Parse(",") == s & nvirgulas == 0)
                {
                    str += s;
                    nvirgulas++;
                }
            }

            return str;
        }


        public static string ConvertToMoneyString(this decimal value)
        {
            return string.Format("{0:C2}", value);
        }

        public static string ConvertToMoneyString(this string value)
        {
            string str = StringRemoveChar(value);

            if (str != "")
            {
                decimal retorno = decimal.Parse(str);
                return string.Format("{0:C2}", retorno);
            }

            return "";
        }

        public static string ConvertToPercentString(this decimal value)
        {
            return string.Format("{0:P0}", value / 100);
        }

        public static string ConvertToPercentString(this int value)
        {
            return string.Format("{0:P0}", value / 100);
        }

        public static string ConvertToPercentString(this string value)
        {
            string str = StringRemoveChar(value);

            if (str != "")
            {
                decimal retorno = decimal.Parse(str) / 100;
                return string.Format("{0:P0}", retorno);
            }

            return "";
        }


        public static decimal ConvertToDecimal(this string value)
        {
            string str = StringRemoveChar(value);

            if (str != "")
                return decimal.Parse(str);

            return 0;
        }

        public static int ConvertToInt(this string value)
        {
            string str = StringRemoveChar(value);

            if (str != "")
                return int.Parse(str);

            return 0;
        }

        public static double ConvertToDouble(this string value)
        {
            string str = StringRemoveChar(value);

            if (str != "")
                return double.Parse(str);

            return 0;
        }
    }
}
