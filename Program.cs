using System;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===== 1. Thread: Умножение массива =====");
            ThreadArrayMultiply.ThreadMultiArrProcess();

            Console.WriteLine("\n===== 2. ThreadPool: Суммирование =====");
            ThreadPoolArraySum.ThreadPoolSumProcess();

            Console.WriteLine("\n===== 3. Thread: Поиск максимума =====");
            ThreadArrayMax.ThreadMaxArrProcess();

            Console.WriteLine("\n===== 4. ThreadPool: Фильтрация (>5) =====");
            ThreadPoolFilter.ThreadPoolFilterMoreThenFiveProcess();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
