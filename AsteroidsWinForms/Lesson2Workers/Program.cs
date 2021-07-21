using System;

namespace Lesson2Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowCase();
        }

        static public void ShowCase()
        {
            var workers = new BaseWorker[]
            {
                new Worker("Eddie", 190),
                new Worker("Adam", 175),
                new Worker("John", 230),
                new Worker("Anna", 205),
                new OutsourceWorker("Mike", 40000)
            };

            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Name}'s salary per month = {worker.GetSalaryPerMonth()}");
            }

            Console.WriteLine();

            Array.Sort(workers);

            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Name}'s salary per month = {worker.GetSalaryPerMonth()}");
            }
        }
    }
}
