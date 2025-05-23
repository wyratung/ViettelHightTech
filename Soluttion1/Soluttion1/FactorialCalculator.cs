using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Soluttion1
{
    public class FactorialCalculator
    {
       
        private static BigInteger FactorialIterative(int n)
        {
            if (n == 0 || n == 1)
            {
                return BigInteger.One;
            }

            BigInteger result = BigInteger.One;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private static BigInteger FactorialRecursive(int n)
        {
            if (n == 0 || n == 1)
            {
                return BigInteger.One;
            }
            return n * FactorialRecursive(n - 1);
        }

        public static string CalculateFactorial(string input, bool useRecursive = false)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Error: Input is null or empty.";
            }

            if (!int.TryParse(input, out int n) || n < 0)
            {
                return "Error: Input must be a non-negative integer.";
            }

            if (n > 10000)
            {
                return "Error: Input is too large for practical computation.";
            }

            try
            {
                BigInteger result = useRecursive ? FactorialRecursive(n) : FactorialIterative(n);
                return result.ToString();
            }
            catch (StackOverflowException)
            {
                return "Error: Stack overflow in recursive calculation.";
            }
            catch (Exception)
            {
                return "Error: An unexpected error occurred.";
            }
        }

        public static void Main()
        {
            string[] testInputs = { "5", "0", "-1", "", "100", "abc", "1000" };

            Console.WriteLine("Testing iterative factorial:");
            foreach (var input in testInputs)
            {
                Console.WriteLine($"Input: {input}, Result: {CalculateFactorial(input, false)}");
            }

            Console.WriteLine("\nTesting recursive factorial:");
            foreach (var input in testInputs)
            {
                Console.WriteLine($"Input: {input}, Result: {CalculateFactorial(input, true)}");
            }
        }
    }
}
