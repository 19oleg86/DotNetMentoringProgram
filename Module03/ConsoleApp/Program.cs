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
                    StringChecker cs = new StringChecker();
                    Console.WriteLine(cs.CheckUserString(baseString));
                }
                catch (StringCheckerException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            } while (baseString == string.Empty);
        }
    }

    public class StringChecker
    {
        public char CheckUserString(string checkThis)
        {
            if (checkThis.Length == 0)
            {
                throw new StringCheckerException("The string shouldn't be empty");
            }
            return checkThis[0];
        }
    }
    public class StringCheckerException : Exception
    {
        public StringCheckerException(string message) : base(message)
        { }
    }

}
