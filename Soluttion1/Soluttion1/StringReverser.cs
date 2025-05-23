using System;
using System.Linq;

public class StringReverser
{
    
    public static string ReverseString(string input)
    {
        if (input == null)
        {
            return "Error: Input is null.";
        }

        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        return new string(input.Reverse().ToArray());
    }

    public static string ReverseStringTwoPointer(string input)
    {
        
        if (input == null)
        {
            return "Error: Input is null.";
        }

        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        char[] charArray = input.ToCharArray();
        int left = 0;
        int right = charArray.Length - 1;


        while (left < right)
        {
            char temp = charArray[left];
            charArray[left] = charArray[right];
            charArray[right] = temp;
            left++;
            right--;
        }

        return new string(charArray);
    }
    public static void Main()
    {

        string[] testInputs =
        {
            "Hello, World!",
            "",
            null,
            "!@#$%^&*()",
            "Xin chào 😊",
            "a"
        };

        Console.WriteLine("Testing LINQ-based string reversal:");
        foreach (var input in testInputs)
        {
            Console.WriteLine($"Input: {(input == null ? "null" : $"\"{input}\"")}, Result: {ReverseString(input)}");
        }

        Console.WriteLine("\nTesting Two-Pointer string reversal:");
        foreach (var input in testInputs)
        {
            Console.WriteLine($"Input: {(input == null ? "null" : $"\"{input}\"")}, Result: {ReverseStringTwoPointer(input)}");
        }
    }
}