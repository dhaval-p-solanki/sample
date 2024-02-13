﻿namespace StringCalculator;

public static class Program
{
    // See https://aka.ms/new-console-template for more information
    //Console.WriteLine("Hello, World!");

    public static void Main(string[] arg)
    {
        Console.WriteLine("Total Number is :");
        //Console.Write(Add("\n1,2;3;4,5"));
        Console.Write(Add("1,2;3,//,4,5\n6"));
    }

    public static int Add(string input)
    {
        var delimiters = new List<string> { ",", "\n", "//", ";" };
        if(input.CheckInputValueEmpty()) 
        {
            return 0;
        }
        else if (input.CheckInputValueNegative(delimiters))
        {
            return 0;
        } 
        else
        {
            int[] numbers = ReturnOnlyNumberValues(input, delimiters);
            return numbers.Where(n => n <= 1000).Sum();
        }
    }

    /// <summary>
    /// check for input is not null/empty/whitespace
    /// </summary>
    /// <param name="input">string</param>
    /// <returns>true or false</returns>
    private static bool CheckInputValueEmpty(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return true;
        }
        else
            return false;
    }

    /// <summary>
    /// check for input is not Negative
    /// </summary>
    /// <param name="input">string</param>
    /// <param name="delimiters">List<string></param>
    /// <returns>true or false</returns>
    private static bool CheckInputValueNegative(this string input, List<string> delimiters)
    {
        int[] numbers = ReturnOnlyNumberValues(input, delimiters);

        if (numbers.Any(n => n < 0))
            return true;
        else
            return false;
    }

    /// <summary>
    /// check for input Return Only Number Values
    /// </summary>
    /// <param name="input">string</param>
    /// <param name="delimiters">List<string></param>
    /// <returns>true or false</returns>
    private static int[] ReturnOnlyNumberValues(string input, List<string> delimiters)
    {
        return input
            .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}