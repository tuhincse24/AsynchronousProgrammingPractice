using System;
using System.Threading;

namespace AsynchronousProgrammingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int counter = 1; counter < 9; counter++)
            {
                if (counter % 3 == 0)
                {
                    WriteFactorial(counter);
                }
                else
                {
                    Console.WriteLine(counter);
                }
            }
            Console.ReadLine();
        }
        private static void WriteFactorial(int no)
        {
            int result = FindFactorialWithSimulatedDelay(no);
            Console.WriteLine($"Factorial of {no} is {result}");
        }
        private static int FindFactorialWithSimulatedDelay(int no)
        {
            int result = 1;
            for (int i = 1; i <= no; i++)
            {
                Thread.Sleep(500);
                result = result * i;
            }
            return result;
        }
    }
}
