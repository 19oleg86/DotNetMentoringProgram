using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;

namespace Task1FibonacciCache
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fibonacci row - 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
            // Trying to get 3 then 8 and then 5 from Fibonacci row

            List<int> tryToFind = new List<int>() { 3, 8, 5 };
            List<int> finalList = new List<int>();

            foreach (int digit in tryToFind)
            {
                finalList = Fibonacci.GetCachedFibonacci(digit);
                foreach (var item in finalList)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }

    public class Fibonacci
    {
        public static int first = 1;
        public static int second = 1;
        public static int next;
        public static List<int> listOfNumbers = new List<int>();
        public static List<int> cachedListOfNumbers = new List<int>();
        public static Cache cache = new Cache();
        public static Dictionary<int, int> dict = new Dictionary<int, int>();
        static Fibonacci()
        {
            cache.Insert("CN", dict);
        }
        public static List<int> GetCachedFibonacci(int searchNumber)
        {
            foreach (var digit in dict.Values)
            {
                if (digit == searchNumber)
                {
                    cachedListOfNumbers.Add(dict[searchNumber]);
                    return cachedListOfNumbers;     
                }
            }

            if (first == second)
            {
                listOfNumbers.Add(first);
                listOfNumbers.Add(second);
                dict.Add(first, first);
                if(!dict.Keys.Contains(second))
                dict.Add(second, second);
            }
            while (!listOfNumbers.Contains(searchNumber))
            {
                next = first + second;
                listOfNumbers.Add(next);
                dict.Add(next, next);
                first = second;
                second = next;
            }
            return listOfNumbers;
        }
    }
}
