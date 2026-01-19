using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter first word: ");
        string firstWord = Console.ReadLine();
        Console.Write("Enter second word: ");
        string secondWord = Console.ReadLine();
        if (string.IsNullOrEmpty(firstWord) || string.IsNullOrEmpty(secondWord))
        {
            Console.WriteLine("Input cannot be empty.");
            return;
        }

        if (firstWord.Length > 50 || secondWord.Length > 50)
        {
            Console.WriteLine("Words should not be more than 50 characters.");
            return;
        }

        foreach (char c in firstWord)
        {
            if (!char.IsLetter(c))
            {
                Console.WriteLine("First word should contain only letters.");
                return;
            }
        }

        foreach (char c in secondWord)
        {
            if (!char.IsLetter(c))
            {
                Console.WriteLine("Second word should contain only letters.");
                return;
            }
        }
        HashSet<char> secondWordSet = new HashSet<char>();
        foreach (char c in secondWord)
        {
            char ch = char.ToLower(c);
            if (ch != 'a' && ch != 'e' && ch != 'i' && ch != 'o' && ch != 'u')
            {
                secondWordSet.Add(ch);
            }
        }
        List<char> firstWordResult = new List<char>();
        foreach (char c in firstWord)
        {
            char ch = char.ToLower(c);
            if (!secondWordSet.Contains(ch) && !firstWordResult.Contains(ch))
            {
                firstWordResult.Add(ch);
            }
        }

        Console.WriteLine("Alphabets in first word that are not in second word and are not vowels:");
        foreach (char c in firstWordResult)
        {
            Console.Write(c + " ");
        }
    }
}
