using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soluttion1
{
    using System;

    public class GcdLcmCalculator
    {
       
        private static long Gcd(long a, long b)
        {

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0 && b == 0)
            {
                return 0; 
            }

            if (a == 0)
            {
                return b;
            }
            if (b == 0)
            {
                return a;
            }

            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        private static long Lcm(long a, long b)
        {
            if (a == 0 || b == 0)
            {
                return 0; 
            }

            try
            {
                checked
                {
                    long gcd = Gcd(a, b);
                    return Math.Abs(a / gcd * b); 
                }
            }
            catch (OverflowException)
            {
                return -1; 
            }
        }

     
        public static string CalculateGcdAndLcm(string inputA, string inputB)
        {
            if (string.IsNullOrWhiteSpace(inputA) || string.IsNullOrWhiteSpace(inputB))
            {
                return "Error: One or both inputs are null or empty.";
            }

            if (!long.TryParse(inputA, out long a) || !long.TryParse(inputB, out long b))
            {
                return "Error: Inputs must be valid integers.";
            }

            long gcd = Gcd(a, b);

            long lcm = Lcm(a, b);


            if (lcm == -1)
            {
                return $"GCD({a}, {b}) = {gcd}, LCM: Error due to overflow.";
            }

            return $"GCD({a}, {b}) = {gcd}, LCM({a}, {b}) = {lcm}";
        }

        public static void Main()
        {
            (string, string)[] testInputs =
            {
            ("12", "18"),
            ("0", "5"),
            ("0", "0"),
            ("-12", "18"),
            ("9223372036854775807", "2"),
            ("", "10"),
            ("abc", "10"),
            ("1000000", "2000000")
        };

            foreach (var (inputA, inputB) in testInputs)
            {
                Console.WriteLine($"Input: ({inputA}, {inputB}), Result: {CalculateGcdAndLcm(inputA, inputB)}");
            }
        }
    }
}
