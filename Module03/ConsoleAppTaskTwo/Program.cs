using System;
using StringTransformer;

namespace ConsoleAppTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString;
            IntMaker intMaker = new IntMaker();
            do
            {
                Console.Write("Enter a number (or enter \"exit\" to finish the program): ");
                baseString = Console.ReadLine();
                if (baseString == "exit")
                    break;
                    try
                    {
                        Console.WriteLine($"Your number is: {intMaker.ConvertToInt(baseString)}");
                    }
                    catch (EmptyStringException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (IncorrectFormatException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"Error: Your number is too big, it must be between -2 147 483 648 and  2 147 483 647");
                    }
            } while (true);
        }
    }
}
