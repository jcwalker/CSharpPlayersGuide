using System;
using System.Linq;

// Password must be at least 6-13 letters long
// Passwords must contain 1 upper and 1 lower
// Passwords must NOT contiain a T or &

while (true)
{
    Console.Write("Enter password: ");
    var passwordInput = Console.ReadLine();

    if (PasswordValidator.ValidatePassword(passwordInput))
    {
        Console.WriteLine("The password meets all requirements");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("The password does NOT meets the requirements");
        Console.WriteLine();
    }
}

public class PasswordValidator
{
    private static bool AssertLength(string password)
    {
        if (password.Length >=6 && password.Length <= 13)
        {
            return true;
        }

        return false;
    }

    private static bool AssertUpper(string password)
    {
        foreach (char letter in password.ToCharArray())
        {
            if (char.IsUpper(letter))
            {
                return true;
            }
        }

        return false;
    }

    private static bool AssertLower(string password)
    {
        foreach (char letter in password.ToCharArray())
        {
            if (char.IsLower(letter))
            {
                return true;
            }
        }

        return false;
    }

    private static bool AssertIngelmarsLaw(string password)
    {
        if (password.ToCharArray().Contains('T') || password.ToCharArray().Contains('&'))
        {
            return false;
        }

        return true;
    }

    public static bool ValidatePassword(string password)
    {
        bool lengthResult    = AssertLength(password);
        bool upperResult     = AssertUpper(password);
        bool lowerResult     = AssertLower(password);
        bool IngelmarsResult = AssertIngelmarsLaw(password);

        if (lengthResult && upperResult && lowerResult && IngelmarsResult)
        {
            return true;
        }

        return false;
    }
}
