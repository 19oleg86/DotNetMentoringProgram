using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString = null;
            do
            {
                try
                {
                    Console.Write("Please enter a string of text: ");
                    baseString = Console.ReadLine();
                    CheckString cs = new CheckString();
                    cs.CheckUserString(baseString);
                    Console.WriteLine(baseString[0]);
                }
                catch (CheckStringException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (baseString == string.Empty);
        }
    }

    public class CheckString
    {
        public void CheckUserString(string checkThis)
        {
            if (checkThis.Length == 0)
            {
                throw new CheckStringException("The string shouldn't be empty");
            }
        }
    }

    public class CheckStringException : Exception
    {
        public CheckStringException(string message) : base(message)
        { }
    }

}
