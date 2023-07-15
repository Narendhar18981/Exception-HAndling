using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            Thread thread = new Thread(DoWork);
            thread.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main Thread: " + i);
                Thread.Sleep(500);
            }

            thread.Join();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred: " + ex.Message);
        }
    }

    public static void DoWork()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Worker Thread: " + i);
                Thread.Sleep(500);

                if (i == 7)
                {
                    throw new Exception("Exception in worker thread");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred in the worker thread: " + ex.Message);
        }
    }
}
