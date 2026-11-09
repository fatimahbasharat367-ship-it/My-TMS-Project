using System;

namespace TourismManagementSystem;
public static class ConsoleHelper
{
   
    public static string ReadText()
    {
        string input = Console.ReadLine();
        if (input == null)
        {
            return "";
        }
        return input.Trim();
    }

    public static int ReadNumber(string question)
    {
        while (true)
        {
            Console.Write(question);
            string text = ReadText();

            bool onlyDigits = text.Length >= 1 && text.Length <= 9;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] < '0' || text[i] > '9')
                {
                    onlyDigits = false;
                }
            }

            if (onlyDigits)
            {
                return int.Parse(text);
            }
            Console.WriteLine("Please enter a whole number.");
        }
    }
    public static void WaitForKey()
    {
        Console.Write("Press any key...");
        Console.ReadKey(true);
    }
}

