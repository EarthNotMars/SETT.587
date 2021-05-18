using System;
using System.Collections.Generic;
using System.Linq;


namespace Hw_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i =-2; i<8; i++)
            {
                numbers.Add(i);
            }
            // Output elements which value < 0
            Console.WriteLine("Negative elements in array: ");
            var lessZero = from k in numbers
                           where k < 0
                           select k;
            foreach (int k in lessZero)
            {
                Console.WriteLine(k);
            }
            // Output only positive numbers 
            Console.WriteLine("Positive elements in array: ");
            var aboveZero = from k in numbers
                           where k >= 0
                           select k;
            foreach (int k in aboveZero)
            {
                Console.WriteLine(k);
            }
            // Get smallest and largest elements from array 
            int max = numbers.Max();
            int min = numbers.Min();
            int sumA = numbers.Sum();
            int minValIndex = numbers.IndexOf(min);
            int maxValIndex = numbers.IndexOf(max);
            Console.WriteLine($"Smalles value from array is: {min} with index {minValIndex}, largest: {max} with index {maxValIndex}, sum of all elements: {sumA} ");
            // Output first smaller element than Average
            double Average = numbers.Average();
            var AboveAverage = numbers.LastOrDefault(n => n < Average);
            int AboveAvIndex = numbers.IndexOf(AboveAverage);
            Console.WriteLine($"Average value is: {Average}");
            Console.WriteLine($"The largest value from array that smaller than Average is: {AboveAverage} with index: {AboveAvIndex} ");
            // Sort the array using OrderBy
            Console.WriteLine("Sort number in descending way:");
            var orderedNumbers = from i in numbers
                                 orderby i descending
                                 select i;
            foreach (int i in orderedNumbers)
                Console.WriteLine(i);
        }
    }
}
