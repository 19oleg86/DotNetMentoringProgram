using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1FibonacciCache
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        
        
    }

    class Fibonacci
    {
        public List<int> listOfNumbers = new List<int>();

        public int GetCachedFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return GetCachedFibonacci(n - 1) + GetCachedFibonacci(n - 2);
            }
            
            //.Add(firstNumber);


        }
    }
}
