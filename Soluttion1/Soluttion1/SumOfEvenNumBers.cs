using System;

public class EvenNumberSumCalculator
{
    /// <summary>
    /// Calculates the sum of even numbers up to N using mathematical formula.
    /// </summary>
    /// <param name="input">Input string representing N.</param>
    /// <returns>Sum of even numbers or error message.</returns>
    public static string CalculateSumOfEvenNumbers(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "Error: Input is null or empty.";
        }

        if (!long.TryParse(input, out long n) || n < 0)
        {
            return "Error: Input must be a non-negative integer.";
        }

        if (n == 0)
        {
            return "0";
        }

        if (n > long.MaxValue / 2)
        {
            return "Error: Input is too large, may cause overflow.";
        }

        long k = n / 2;

        long sum = k * (k + 1);

        if (sum < 0)
        {
            return "Error: Result overflow.";
        }

        return sum.ToString();
    }

    /// <summary>
    /// Main method for testing the calculation.
    /// </summary>
    //public static void Main()
    //{
    //    // Test cases
    //    string[] testInputs = { "10", "0", "-5", "", "9223372036854775807", "1000000", "11" };

    //    foreach (var input in testInputs)
    //    {
    //        Console.WriteLine($"Input: {input}, Result: {CalculateSumOfEvenNumbers(input)}");
    //    }
    //}
}