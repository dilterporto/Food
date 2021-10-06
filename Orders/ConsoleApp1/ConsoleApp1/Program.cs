using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        /*
         *  Write a short program that prints each number from 1 to 100 on a new line. 
            For each multiple of 3, print "Fizz" instead of the number. 
            For each multiple of 5, print "Buzz" instead of the number. 
            For numbers which are multiples of both 3 and 5, print "FizzBuzz" instead of the number.
         * 
         */
        
        static void Main(string[] args)
        {
            var numbers = Enumerable
                .Range(1, 100);

            foreach (var number in numbers)
            {
                var isMultipleOf3 = number % 3 == 0;
                var isMultipleOf5 = number % 5 == 0;
                if (isMultipleOf3 && isMultipleOf5)
                {
                    Console.WriteLine("FizzBuzz");
                    continue;
                }
                if (isMultipleOf3)
                    Console.WriteLine($"Fizz");
                else if(isMultipleOf5)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine($"{number}");
            }
        }
    }
}
