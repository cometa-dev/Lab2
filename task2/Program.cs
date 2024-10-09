using System;
using System.Linq;
using NUnit;
public static class StringExtensions
{
    public static string Reverse(this string str)
    {
        return new string(str.ToCharArray().Reverse().ToArray());
    }

    public static int CountOccurrences(this string str, char character)
    {
        return str.Count(c => c == character);
    }
}

public static class ArrayExtensions
{
    public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
    {
        return array.Count(item => item.Equals(value));
    }

    public static T[] Unique<T>(this T[] array)
    {
        return array.Distinct().ToArray();
    }
}

public class ExtensionMethodsTests
{
    public static void RunTests()
    {
        // Тести для методів розширення String
        string testString = "Hello, World!";
        Console.WriteLine($"Original string: {testString}");
        Console.WriteLine($"Reversed string: {testString.Reverse()}");
        Console.WriteLine($"Occurrences of 'l': {testString.CountOccurrences('l')}");

        // Тести для методів розширення одновимірних масивів
        int[] intArray = { 1, 2, 3, 4, 2, 3, 1, 5 };
        Console.WriteLine($"\nOriginal int array: {string.Join(", ", intArray)}");
        Console.WriteLine($"Occurrences of 2: {intArray.CountOccurrences(2)}");
        Console.WriteLine($"Unique elements: {string.Join(", ", intArray.Unique())}");

        string[] stringArray = { "apple", "banana", "apple", "cherry", "date", "banana" };
        Console.WriteLine($"\nOriginal string array: {string.Join(", ", stringArray)}");
        Console.WriteLine($"Occurrences of 'apple': {stringArray.CountOccurrences("apple")}");
        Console.WriteLine($"Unique elements: {string.Join(", ", stringArray.Unique())}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExtensionMethodsTests.RunTests();
    }
}