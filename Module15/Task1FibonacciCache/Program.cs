using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Task1FibonacciCache
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fibonacci row - 1, 1, 2, 3, 5, 8, 13, 21, 34, 55
            List<int> finalList;
            List<int> tryToFind = new List<int>() { 3, 8, 5 };
            Dictionary<string, int> dict = new Dictionary<string, int>();
           
            // Trying to get 3 then 8 and then 5 from Fibonacci row
            foreach (var item in tryToFind)
            {
                foreach (var digit in Fibonacci.cache)
                {

                    if (dict.ContainsValue(item))
                    {
                        Console.WriteLine((int)Fibonacci.cache.Get(item.ToString()) + " - from cache");
                        break;
                    }
                }
                finalList = Fibonacci.GetCachedFibonacci(item);
                foreach (var number in finalList)
                {
                    if (dict.Keys.Contains(number.ToString()))
                        continue;
                    dict.Add(number.ToString(), number);
                    Console.WriteLine(number + " - not from cache");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    class Fibonacci
    {
        public static int first = 1;
        public static int second = 1;
        public static int next;
        public static List<int> listOfNumbers = new List<int>();
        public static Cache cache = new Cache();
        public static List<int> GetCachedFibonacci(int n)
        {
            if (first == second)
            {
                listOfNumbers.Add(first);
                listOfNumbers.Add(second);
                cache.Insert(first.ToString(), first);
                cache.Insert(second.ToString(), second);
            }
            while (!listOfNumbers.Contains(n))
            {
                next = first + second;
                listOfNumbers.Add(next);
                cache.Insert(next.ToString(), next);
                first = second;
                second = next;
            }

            return listOfNumbers;
        }
    }
}
