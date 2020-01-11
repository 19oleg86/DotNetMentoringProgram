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
            Dictionary<int, int> finalList;

            Fibonacci fibonacci = new Fibonacci();

            foreach (int digit in tryToFind)
            {
                finalList = fibonacci.GetCachedFibonacci(digit);
                foreach (var item in finalList)
                {
                    Console.Write(item.Value + ", ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    public class Fibonacci
    {
        public int first = 1;
        public int second = 1;
        public int next;
        public Cache cache = new Cache();

        public Fibonacci()
        {
            cache.Insert("CN", new Dictionary<int, int>());
        }
        public Dictionary<int, int> GetCachedFibonacci(int searchNumber)
        {
            var cachedDict = (Dictionary<int, int>)cache["CN"];
            if (cachedDict.ContainsKey(searchNumber))
            {
                return cachedDict;
            }

            if (first == second)
            {
                cachedDict.Add(first, first);
                if (!cachedDict.Keys.Contains(second))
                    cachedDict.Add(second, second);
            }
            while (!cachedDict.Keys.Contains(searchNumber))
            {
                next = first + second;
                cachedDict.Add(next, next);
                first = second;
                second = next;
            }
            return cachedDict;
        }
    }
}
