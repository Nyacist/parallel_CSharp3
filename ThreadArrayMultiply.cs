using System;
using System.Threading;

namespace lab3
{
    public class ThreadArrayMultiply
    {
        public static void ThreadMultiArrProcess()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Thread t1 = new Thread(() =>
                ProcessArrayMulti(numbers, 0, numbers.Length / 2));

            Thread t2 = new Thread(() =>
                ProcessArrayMulti(numbers, numbers.Length / 2, numbers.Length));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Результат умножения массива:");
            Console.WriteLine(string.Join(", ", numbers));
        }

        static void ProcessArrayMulti(int[] array, int startIndex, int endIndex)
        {
            Console.WriteLine(
                $"Поток {Thread.CurrentThread.ManagedThreadId} обрабатывает элементы [{startIndex}; {endIndex})"
            );

            for (int i = startIndex; i < endIndex; i++)
            {
                array[i] *= 2;
            }
        }
    }
}
