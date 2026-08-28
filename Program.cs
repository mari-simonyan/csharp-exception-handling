using System;

public class InvalidEmailException : Exception
{
    public InvalidEmailException(string message) : base(message)
    {
    }
}

public class MyResource : IDisposable
{
    public void Use()
    {
        Console.WriteLine("Using resource...");
    }

    public void Dispose()
    {
        Console.WriteLine("Resource closed.");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Console.Write("Enter email: ");
            string? email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidEmailException(
                    "Email cannot be empty."
                );
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                throw new InvalidEmailException(
                    "Invalid email format."
                );
            }

            Console.WriteLine($"Valid email: {email}");
        }
        catch (InvalidEmailException ex)
        {
            Console.WriteLine($"Validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Validation process completed.");
        }

        Console.WriteLine();

        using (MyResource resource = new MyResource())
        {
            resource.Use();
        }
    }
}
