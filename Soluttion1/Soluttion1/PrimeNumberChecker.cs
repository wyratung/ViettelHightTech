using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soluttion1
{
    public class PrimeNumberChecker
    {
        /// <summary>
        /// Checks if a single number is prime.
        /// </summary>
        /// <param name="input">Input string representing the number.</param>
        /// <returns>Result indicating if the number is prime or an error message.</returns>
        public static string IsPrime(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Error: Input is null or empty.";
            }

            if (!long.TryParse(input, out long n))
            {
                return "Error: Input must be a valid integer.";
            }

            if (n <= 1)
            {
                return $"{n} is not a prime number.";
            }
            if (n == 2)
            {
                return "2 is a prime number.";
            }
            if (n % 2 == 0)
            {
                return $"{n} is not a prime number.";
            }

            for (long i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                {
                    return $"{n} is not a prime number.";
                }
            }

            return $"{n} is a prime number.";
        }

        /// <summary>
        /// Finds all prime numbers up to N using Sieve of Eratosthenes.
        /// </summary>
        /// <param name="input">Input string representing the upper limit N.</param>
        /// <returns>List of prime numbers or an error message.</returns>
        public static string FindPrimesUpToN(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Error: Input is null or empty.";
            }

            if (!long.TryParse(input, out long n) || n < 0)
            {
                return "Error: Input must be a non-negative integer.";
            }

            if (n < 2)
            {
                return "No prime numbers found.";
            }

            if (n > int.MaxValue)
            {
                return "Error: Input is too large for array allocation.";
            }

            bool[] isPrimeArray = new bool[n + 1];
            for (long i = 0; i <= n; i++)
            {
                isPrimeArray[i] = true;
            }
            isPrimeArray[0] = isPrimeArray[1] = false;

            for (long i = 2; i * i <= n; i++)
            {
                if (isPrimeArray[i])
                {
                    for (long j = i * i; j <= n; j += i)
                    {
                        isPrimeArray[j] = false;
                    }
                }
            }


            List<long> primes = new List<long>();
            for (long i = 2; i <= n; i++)
            {
                if (isPrimeArray[i])
                {
                    primes.Add(i);
                }
            }

            return $"Prime numbers up to {n}: {string.Join(", ", primes)}";
        }


        public static void Main()
        {
            // Test cases for single number primality check
            string[] testInputs = { "17", "0", "1", "-5", "", "1000000", "9223372036854775807" };

            Console.WriteLine("Testing single number primality check:");
            foreach (var input in testInputs)
            {
                Console.WriteLine($"Input: {input}, Result: {IsPrime(input)}");
            }

            // Test cases for Sieve of Eratosthenes
            string[] sieveInputs = { "100" };

            Console.WriteLine("\nTesting Sieve of Eratosthenes:");
            foreach (var input in sieveInputs)
            {
                Console.WriteLine($"Input: {input}, Result: {FindPrimesUpToN(input)}");
            }
        }
    }
}
