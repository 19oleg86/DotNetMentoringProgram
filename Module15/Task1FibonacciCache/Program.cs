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
            // Trying to get 3 then 8 and then 5 from Fibonacci row

            List<int> tryToFind = new List<int>() { 3, 8, 5 };
            Fibonacci.GetCachedFibonacci(tryToFind);

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
        public static Dictionary<int, int> dict = new Dictionary<int, int>();
        public static void GetCachedFibonacci(List<int> searchNumbers)
        {
            cache.Insert("CN", dict);
            foreach (var item in searchNumbers)
            {
                if (first == second)
                {
                    listOfNumbers.Add(first);
                    listOfNumbers.Add(second);
                    dict.Add(first, first);
                    if (!dict.Keys.Contains(second))
                    dict.Add(second, second);
                }
                while (!listOfNumbers.Contains(item))
                {
                    next = first + second;
                    listOfNumbers.Add(next);
                    dict.Add(next, next);
                    first = second;
                    second = next;
                }

                foreach (var digit in dict.Values)
                {
                    if (digit == item)
                    {
                        var innerDict = (Dictionary<int, int>)cache.Get("CN");
                        int result;
                        innerDict.TryGetValue(item, out result);
                        //Console.WriteLine( result + " - from cache");
                        break;
                    }
                }

                foreach (var number in listOfNumbers)
                {
                    //if (dict.Keys.Contains(number.ToString()))
                    //    continue;
                    //dict.Add(number.ToString(), number);
                    Console.WriteLine(number + " - not from cache");
                }
                Console.WriteLine();
            }
        }
    }
}
