using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter your username (3-10 characters):");
        string userInput = Console.ReadLine();

        try
        {
            ValidateUsername(userInput);
            Console.WriteLine("Valid username: " + userInput);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid input. Username cannot be empty.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid input. Username must be 3-10 characters long.");
        }
    }

    static void ValidateUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException();
        }

        if (username.Length < 3 || username.Length > 10)
        {
            throw new ArgumentException();
        }
    }
}

