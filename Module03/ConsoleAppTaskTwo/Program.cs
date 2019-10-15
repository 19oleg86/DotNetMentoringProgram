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
                        Console.WriteLine($"Your number is: {intMaker.CovertToInt(baseString)}");
                    }
                    catch (EmptyStringExc ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (IncorrectFormatExc ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (TypeOverFlowExc ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"Error: Extremely large number, enter a lower number (between -2 147 483 648 and  2 147 483 647)");
                    }
            } while (1 == 1);
        }
    }
}
