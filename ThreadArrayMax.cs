using System;
using System.Threading;

namespace lab3
{
    public class ThreadArrayMax
    {
        public static void ThreadMaxArrProcess()
        {
            int[] numbers = { 3, 17, 5, 22, 9, 11, 8, 30, 15 };

            int max1 = int.MinValue;
            int max2 = int.MinValue;

            Thread t1 = new Thread(() =>
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

                for (int i = 0; i < numbers.Length / 2; i++)
                    if (numbers[i] > max1)
                        max1 = numbers[i];

                Console.WriteLine(
                    $"Поток {Thread.CurrentThread.ManagedThreadId} нашёл максимум первой части = {max1}"
                );
            });

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

                for (int i = numbers.Length / 2; i < numbers.Length; i++)
                    if (numbers[i] > max2)
                        max2 = numbers[i];

                Console.WriteLine(
                    $"Поток {Thread.CurrentThread.ManagedThreadId} нашёл максимум второй части = {max2}"
                );
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            int max = Math.Max(max1, max2);
            Console.WriteLine($"Общий максимальный элемент массива = {max}");
        }
    }
}
