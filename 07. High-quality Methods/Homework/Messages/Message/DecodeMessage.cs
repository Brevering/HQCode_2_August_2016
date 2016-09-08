namespace Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;

    internal class DecodeMessage
    {
        private const int TresNumFourDigitsCount = 10;

        private static readonly string[] TresNumFourDigits = new string[TresNumFourDigitsCount]
        {
            "cad",
            "xoz",
            "nop",
            "cyk",
            "min",
            "mar",
            "kon",
            "iva",
            "ogi",
            "yan"
        };

        public static string[] SplitInput(string input)
        {
            var builder = new StringBuilder();
            var count = 0;

            do
            {
                for (var i = 0; i < 3; i++)
                {
                    builder.Append(input[count + i]);
                }

                builder.Append(" ");
                count += 3;
            }        
            while (count < input.Length);

            var resultstr = builder.ToString(0, builder.Length - 1);
            var result = resultstr.Split(' ').ToArray();
            return result;
        }

        public static string StringToDec(string[] input, string[] key)
        {
            var result = string.Empty;
            foreach (var hex in input)
            {
                result += Array.IndexOf(key, hex);
            }

            return result;
        }

        private static string ConvertToTresNumFourNumber(BigInteger decimalNumber)
        {
            var tresNumFourNumber = new List<string>();
            do
            {
                tresNumFourNumber.Add(TresNumFourDigits[(int)(decimalNumber % 10)]);

                decimalNumber /= 10;
            }
            while (decimalNumber != 0);

            tresNumFourNumber.Reverse(); // Reversing the number to get the real value
            return string.Join(string.Empty, tresNumFourNumber);
        }

        private static void Main()
        {
            var array1 = SplitInput(Console.ReadLine());
            var operation = Console.ReadLine();
            var array2 = SplitInput(Console.ReadLine());

            var num1 = BigInteger.Parse(StringToDec(array1, TresNumFourDigits));
            var num2 = BigInteger.Parse(StringToDec(array2, TresNumFourDigits));

            BigInteger result = 0;

            if (operation == "+")
            {
                result = num1 + num2;
            }
            else
            {
                result = num1 - num2;
            }

            Console.WriteLine(ConvertToTresNumFourNumber(result));
        }
    }
}
