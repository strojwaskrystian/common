using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.common.Tools
{
    public static class Validators
    {
        public static bool IsValidIdentityCardNumber(string input)
        {
            try
            {
                input = input.ToUpper();
                input = input.Replace(" ", "");
                char[] cnr = input.ToCharArray();
                if (cnr.Length != 9)
                    return false;

                char[] letterValues =
                     {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                'U', 'V', 'W', 'X', 'Y', 'Z'};
                int[] waga = { 7, 3, 1, 0, 7, 3, 1, 7, 3 };

                int suma = 0;
                for (int i = 0; i < cnr.Length; i++)
                {
                    suma += Array.FindIndex<char>(letterValues, p => p == cnr[i]) * waga[i];
                }

                int a;
                if (int.TryParse(cnr[3].ToString(), out a))
                {
                    int reszta = suma % 10;
                    return int.Parse(cnr[3].ToString()) == reszta;
                }
                else
                    return false;
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool IsValidNIP(string input)
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            bool result = false;
            if (input.Length == 10)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 11;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }

        public static bool IsValidREGON(string input)
        {
            int controlSum;
            if (input.Length == 7 || input.Length == 9)
            {
                int[] weights = { 8, 9, 2, 3, 4, 5, 6, 7 };
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, weights, offset);
            }
            else if (input.Length == 14)
            {
                int[] weights = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                controlSum = CalculateControlSum(input, weights);
            }
            else
            {
                return false;
            }

            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            return controlNum == lastDigit;
        }

        public static bool IsValidPESEL(string input)
        {
            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            if (input.Length != 11) return false;

            int controlSum = CalculateControlSum(input, weights);
            int controlNum = controlSum % 10;
            controlNum = 10 - controlNum;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());
            return controlNum == lastDigit;
        }

        private static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}
