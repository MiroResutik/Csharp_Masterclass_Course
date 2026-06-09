namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Basic Thread
            /*
            var taskCompletionSource = new TaskCompletionSource<bool>();

            

            var thread = new Thread(() =>
            {
                Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} starded!!!");
                Thread.Sleep(4000);
                taskCompletionSource.TrySetResult(true);
                Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} ended!!!");

            });

            
            thread.Start();

            var test = taskCompletionSource.Task.Result;
            Console.WriteLine($"\nTask was done: {test}");
            */


            // Thread Pools
            /*
            new Thread(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Thread 4");

                })
            { IsBackground = true }.Start();

            // 
            Enumerable.Range(0, 100).ToList().ForEach(f =>
            {
            ThreadPool.QueueUserWorkItem ((o) =>
            {
                Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} starded!!!");
                Thread.Sleep(4000);
                Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} ended!!!");

            });
                //new Thread(() =>
                //{
                //    Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} starded!!!");
                //    Thread.Sleep(4000);
                //    Console.WriteLine($"\nThread number: {Thread.CurrentThread.ManagedThreadId} ended!!!");

                //}).Start();

            });
      */

            // Thread Joining

            Console.WriteLine("\nMain Thread strated!!!");
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);
            thread1.Start();
            thread2.Start();

            
            thread1.Join();
            Console.WriteLine("\nThread1Function done!!!");
            thread2.Join();
            Console.WriteLine("\nThread2Function done!!!");

            Console.WriteLine("\nMain Thread ended!!!");

            if (thread1.Join(1000))
            {
                Console.WriteLine("\nThread1Function done.");
            }
            else
            {
                Console.WriteLine("Thred1Function was not done within 1 second!!!!");

            }


            for (int i = 0; i < 10; i++)
            {
                if (thread1.IsAlive)
                {
                    Console.WriteLine("\nThread 1 is still executing!!!");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("\nThread 1 completed!!!");

                }
            }

            Console.ReadKey();
        }
        
        public static void Thread1Function()
        {
            Console.WriteLine("\nThread1Function started!!!");
            Thread.Sleep(3000);
            Console.WriteLine("\nThread1Function coming back to caller!!!");
        }
        public static void Thread2Function()
        {
            Console.WriteLine("\nThread2Function started!!!");
        }
    }
}
