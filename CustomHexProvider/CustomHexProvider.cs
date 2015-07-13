using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomHexProvider
{
    public class CustomHexProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Check whether this is an appropriate callback              
            if (!this.Equals(formatProvider))
                return null;

            // Set default format specifier              
            if (string.IsNullOrEmpty(format))
                format = "CH";
            
            String returnString = null;
            int numeric;
            if (!Int32.TryParse(arg.ToString(), out numeric))
                throw new InvalidCastException("Неверный формат аргумента");
            
            if (format == "CH")
            {               
                if (numeric == 0)
                    return "0";
                bool negative = IsNegative(ref numeric);
                returnString=TransferInHex(numeric);
                char[] tempArrayForReverse = returnString.ToCharArray();
                if (negative)
                {
                   returnString = BildForNegativ(returnString);
                   tempArrayForReverse = DoPositive(returnString);
                }                
                Array.Reverse(tempArrayForReverse);
                return new String(tempArrayForReverse);                              
            }            
            else
            {
                throw new FormatException(string.Format("The {0} format specifier is invalid.", format));
            }           
        }

        private static bool IsNegative(ref int numeric)
        {
            if (numeric < 0)
            {
                numeric *= -1;
                numeric--;
                return true;
            }
            return false;
        }

        private static string TransferInHex(int numeric)
        {
            StringBuilder returnString = new StringBuilder();
            while (numeric > 0)
            {
                switch (numeric % 16)
                {
                    case 15: returnString.Append("F"); break;
                    case 14: returnString.Append("E"); break;
                    case 13: returnString.Append("D"); break;
                    case 12: returnString.Append("C"); break;
                    case 11: returnString.Append("B"); break;
                    case 10: returnString.Append("A"); break;
                    default: returnString.Append((numeric % 16).ToString()); break;
                }
                numeric /= 16;
            }
            return returnString.ToString();
        }

        private static string BildForNegativ(string srartString)
        {
            StringBuilder returnString = new StringBuilder(srartString);
            int length = srartString.Length;
            for (int i = 0; i < 8 - length; i++)
                returnString.Append("0");
            return  returnString.ToString();
        }

        private static char[] DoPositive(string srartString)
        {
            char[] tempArrayForReverse = srartString.ToCharArray();
            for (int i = 0; i < 8; i++)
                switch (tempArrayForReverse[i])
                {
                    case '0': tempArrayForReverse[i] = 'F'; break;
                    case '1': tempArrayForReverse[i] = 'E'; break;
                    case '2': tempArrayForReverse[i] = 'D'; break;
                    case '3': tempArrayForReverse[i] = 'C'; break;
                    case '4': tempArrayForReverse[i] = 'B'; break;
                    case '5': tempArrayForReverse[i] = 'A'; break;
                    case '6': tempArrayForReverse[i] = '9'; break;
                    case '7': tempArrayForReverse[i] = '8'; break;
                    case '8': tempArrayForReverse[i] = '7'; break;
                    case '9': tempArrayForReverse[i] = '6'; break;
                    case 'A': tempArrayForReverse[i] = '5'; break;
                    case 'B': tempArrayForReverse[i] = '4'; break;
                    case 'C': tempArrayForReverse[i] = '3'; break;
                    case 'D': tempArrayForReverse[i] = '2'; break;
                    case 'E': tempArrayForReverse[i] = '1'; break;
                    case 'F': tempArrayForReverse[i] = '0'; break;
                }
            return tempArrayForReverse;
        }


    }
}
