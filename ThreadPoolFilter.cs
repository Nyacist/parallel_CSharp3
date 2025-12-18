using System;
using System.Collections.Generic;
using System.Threading;

namespace lab3
{
    public class ThreadPoolFilter
    {
        public static void ThreadPoolFilterMoreThenFiveProcess()
        {
            int[] numbers = { 1, 8, 3, 10, 5, 6, 2, 9, 7, 4 };
            List<int> filteredNumbers = new List<int>();
            object lockObj = new object();
            CountdownEvent countdown = new CountdownEvent(2);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                for (int i = 0; i < numbers.Length / 2; i++)
                {
                    if (numbers[i] > 5)
                    {
                        lock (lockObj)
                            filteredNumbers.Add(numbers[i]);
                    }
                }
                countdown.Signal();
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}");
                for (int i = numbers.Length / 2; i < numbers.Length; i++)
                {
                    if (numbers[i] > 5)
                    {
                        lock (lockObj)
                            filteredNumbers.Add(numbers[i]);
                    }
                }
                countdown.Signal();
            });

            countdown.Wait();

            Console.WriteLine("Отфильтрованные числа (>5):");
            Console.WriteLine(string.Join(", ", filteredNumbers));
        }
    }
}
