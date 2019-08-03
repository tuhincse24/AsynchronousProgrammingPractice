using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousProgrammingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int counter = 1; counter < 10; counter++)
            {
                if (counter % 3 == 0)
                {
                    //WriteFactorial(counter);
                    WriteFactorialAsyncUsingTask(counter);
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
        private static void WriteFactorialAsyncUsingTask(int no)
        {
            Task<int> task = Task.Run<int>(() =>
            {
                int result = FindFactorialWithSimulatedDelay(no);
                return result;
            });
            task.ContinueWith(new Action<Task<int>>((input) =>
            {
                if (no == 6)
                {
                    Console.WriteLine("Sleeping for 10000 ms");
                    Thread.Sleep(10000);
                }
                Console.WriteLine("Factorial of {0} is {1}", no, input.Result);
            }));
        }
    }
}
