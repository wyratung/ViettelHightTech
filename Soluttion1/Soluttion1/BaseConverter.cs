using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Soluttion1
{
    public class BaseConverter
    {
        private static readonly char[] HexDigits = "0123456789ABCDEF".ToCharArray();

        /// <summary>
        /// Converts a decimal number to the specified base (2, 8, or 16).
        /// </summary>
        /// <param name="input">Decimal number as string.</param>
        /// <param name="targetBase">Target base (2, 8, or 16).</param>
        /// <returns>Converted number or error message.</returns>
        public static string FromDecimal(string input, int targetBase)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Error: Input is null or empty.";
            }

            if (!long.TryParse(input, out long number) || number < 0)
            {
                return "Error: Input must be a non-negative integer.";
            }

            if (targetBase != 2 && targetBase != 8 && targetBase != 16)
            {
                return "Error: Target base must be 2, 8, or 16.";
            }

            if (number == 0)
            {
                return "0";
            }

            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                int remainder = (int)(number % targetBase);
                result.Insert(0, HexDigits[remainder]);
                number /= targetBase;
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts a number from the specified base (2, 8, or 16) to decimal.
        /// </summary>
        /// <param name="input">Number in source base as string.</param>
        /// <param name="sourceBase">Source base (2, 8, or 16).</param>
        /// <returns>Decimal number or error message.</returns>
        public static string ToDecimal(string input, int sourceBase)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Error: Input is null or empty.";
            }

            if (sourceBase != 2 && sourceBase != 8 && sourceBase != 16)
            {
                return "Error: Source base must be 2, 8, or 16.";
            }


            string pattern = sourceBase switch
            {
                2 => @"^[01]+$",
                8 => @"^[0-7]+$",
                16 => @"^[0-9A-Fa-f]+$",
                _ => throw new InvalidOperationException()
            };

            if (!Regex.IsMatch(input, pattern))
            {
                return $"Error: Invalid characters for base {sourceBase}.";
            }

            try
            {
                long result = 0;
                input = input.ToUpper(); 
                for (int i = 0; i < input.Length; i++)
                {
                    char digit = input[i];
                    int value = digit >= '0' && digit <= '9' ? digit - '0' : digit - 'A' + 10;
                    checked
                    {
                        result = result * sourceBase + value;
                    }
                }
                return result.ToString();
            }
            catch (OverflowException)
            {
                return "Error: Result overflow.";
            }
        }


        public static void Main()
        {

            (string input, int targetBase)[] fromDecimalTests =
            {
            ("123", 2),
            ("123", 8),
            ("123", 16),
            ("0", 2),
            ("", 2),
            ("-5", 2),
            ("9223372036854775807", 16),
            ("abc", 2)
        };


            (string input, int sourceBase)[] toDecimalTests =
            {
            ("1111011", 2),
            ("173", 8),
            ("7B", 16),
            ("0", 2),
            ("", 2),
            ("1G", 16),
            ("111111111111111111111111111111111111111111111111111111111111111", 2)
        };

            Console.WriteLine("Testing conversion from decimal:");
            foreach (var (input, targetBase) in fromDecimalTests)
            {
                Console.WriteLine($"Input: {input}, Base: {targetBase}, Result: {FromDecimal(input, targetBase)}");
            }

            Console.WriteLine("\nTesting conversion to decimal:");
            foreach (var (input, sourceBase) in toDecimalTests)
            {
                Console.WriteLine($"Input: {input}, Base: {sourceBase}, Result: {ToDecimal(input, sourceBase)}");
            }
        }
    }
}
