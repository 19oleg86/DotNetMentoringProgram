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
            List<int> finalList;
            finalList = Fibonacci.GetCachedFibonacci(10);
            int result;
            foreach (var item in finalList)
            {
                result = (int)Fibonacci.cache.Get(item.ToString());
                if (result != 0)
                {
                    Console.WriteLine(result + " - from cache");
                }
                else
                {
                    result = 0;
                }
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
            while (listOfNumbers.Count < n)
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
