using System;
using System.Threading;

namespace lab3
{
    public class ThreadPoolArraySum
    {
        public static void ThreadPoolSumProcess()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 0;
            object lockObj = new object();
            CountdownEvent countdown = new CountdownEvent(2);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                int localSum = 0;
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

                for (int i = 0; i < numbers.Length / 2; i++)
                    localSum += numbers[i];

                Console.WriteLine(
                    $"Поток {Thread.CurrentThread.ManagedThreadId} нашёл сумму первой части = {localSum}"
                );

                lock (lockObj)
                    sum += localSum;

                countdown.Signal();
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                int localSum = 0;
                Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} начал работу");

                for (int i = numbers.Length / 2; i < numbers.Length; i++)
                    localSum += numbers[i];

                Console.WriteLine(
                    $"Поток {Thread.CurrentThread.ManagedThreadId} нашёл сумму второй части = {localSum}"
                );

                lock (lockObj)
                    sum += localSum;

                countdown.Signal();
            });

            countdown.Wait();
            Console.WriteLine($"Итоговая сумма массива = {sum}");
        }
    }
}
