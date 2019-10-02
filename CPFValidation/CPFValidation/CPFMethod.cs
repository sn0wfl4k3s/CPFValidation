using System;
using System.Text;

namespace CPFValidation
{
    public class CPFMethods
    {
        private static string CalculingDigit(string cpf_reverse)
        {
            int v1 = 0, v2 = 0, n = 0;

            char[] c = cpf_reverse.ToCharArray();

            for (int i = 0; i < cpf_reverse.Length; ++i)
            {
                n = int.Parse(c[i].ToString());

                v1 += n * (9 - (i % 10));

                v2 += n * (9 - ((i + 1) % 10));
            }

            v1 = (v1 % 11) % 10;

            v2 = v2 + v1 * 9;

            v2 = (v2 % 11) % 10;

            return v1.ToString() + v2.ToString();
        }

        public static bool IsValid(string cpf)
        {
            bool isNumeric = long.TryParse(cpf, out long number);

            if (cpf.Length == 11 && isNumeric)
            {
                if (cpf == "00000000000" ||
                    cpf == "11111111111" ||
                    cpf == "22222222222" ||
                    cpf == "33333333333" ||
                    cpf == "44444444444" ||
                    cpf == "55555555555" ||
                    cpf == "66666666666" ||
                    cpf == "77777777777" ||
                    cpf == "88888888888" ||
                    cpf == "99999999999")
                {
                    return false;
                }

                string original_digit = cpf.Substring(9);

                char[] CpfChar = cpf.ToCharArray();

                Array.Reverse(CpfChar);

                string cpf_reverse = new string(CpfChar);

                cpf_reverse = cpf_reverse.Substring(2);

                string calculated_digit = CalculingDigit(cpf_reverse);

                return original_digit.Equals(calculated_digit);
            }

            return false;
        }

        public static string GenerateCPF()
        {
            var cpf8_invertido = new StringBuilder();

            int num;

            var random = new Random();

            for (int i = 0; i < 9; ++i)
            {
                num = random.Next(0, 9);

                cpf8_invertido.Append(num.ToString());
            }
            string dig = CalculingDigit(cpf8_invertido.ToString());

            char[] c = cpf8_invertido.ToString().ToCharArray();

            Array.Reverse(c);

            string cpf = new string(c);

            cpf = cpf + dig;

            return PrintCPF(cpf);
        }
        public static string PrintCPF(string cpf)
        {
            return cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) +
                "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9, 2);
        }
    }
}
