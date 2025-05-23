using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Soluttion1
{
    public class BigNumberCalculator
    {
        /// <summary>
        /// Performs the specified arithmetic operation on two big numbers.
        /// </summary>
        /// <param name="inputA">First number as string.</param>
        /// <param name="inputB">Second number as string.</param>
        /// <param name="operation">Operation: +, -, *, /</param>
        /// <returns>Result of the operation or error message.</returns>
        public static string Calculate(string inputA, string inputB, string operation)
        {

            if (string.IsNullOrWhiteSpace(inputA) || string.IsNullOrWhiteSpace(inputB))
            {
                return "Error: One or both inputs are null or empty.";
            }

            if (!BigInteger.TryParse(inputA, out BigInteger a) || !BigInteger.TryParse(inputB, out BigInteger b))
            {
                return "Error: Inputs must be valid integers.";
            }

            if (string.IsNullOrWhiteSpace(operation) || operation.Length != 1)
            {
                return "Error: Invalid operation. Use +, -, *, or /.";
            }

            try
            {
                switch (operation)
                {
                    case "+":
                        return (a + b).ToString();
                    case "-":
                        return (a - b).ToString();
                    case "*":
                        return (a * b).ToString();
                    case "/":
                        if (b == BigInteger.Zero)
                        {
                            return "Error: Division by zero.";
                        }
                        return (a / b).ToString();
                    default:
                        return "Error: Invalid operation. Use +, -, *, or /.";
                }
            }
            catch (Exception ex)
            {
                return $"Error: An unexpected error occurred - {ex.Message}";
            }
        }

        public static void Test()
        {
           
            (string inputA, string inputB, string operation)[] testCases =
            {
            ("12345678901234567890", "98765432109876543210", "+"),
            ("12345678901234567890", "98765432109876543210", "-"),
            ("123456789", "987654321", "*"),
            ("12345678901234567890", "12345", "/"),
            ("0", "5", "+"),
            ("-123", "456", "-"),
            ("1000000000000000000000000000000", "2000000000000000000000000000000", "*"),
            ("123456789", "0", "/"),
            ("", "10", "+"),
            ("abc", "10", "+"),
            ("12345678901234567890", "98765432109876543210", "%")
        };

            foreach (var (inputA, inputB, operation) in testCases)
            {
                Console.WriteLine($"Input: {inputA} {operation} {inputB}, Result: {Calculate(inputA, inputB, operation)}");
            }
        }
    }
}
