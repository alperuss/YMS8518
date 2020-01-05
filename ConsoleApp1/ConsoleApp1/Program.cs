using System;
using System.Threading;

namespace ConsoleApp1
{
    public class Threading
    {
        public bool CancelThreads = false;
        public int Thread2turn=1;
        public bool Thread1Running = false;
        public bool Thread2Running = false;

        public  void Thread1()
        {
            Thread1Running = true;
            int i = 1;
            while (true)
            {
                if (CancelThreads)
                {
                    Thread1Running = false;
                    break;
                }
                Console.WriteLine(i + " Thread 1: " + DateTime.Now.Ticks);
                Console.WriteLine(Thread2turn + " Thread 2: " + DateTime.Now.Ticks);
                Thread.Sleep(1000);
                i++;
            }
        }
        public  void Thread2(object id)
        {
            Thread2Running = true;
            Thread2turn = 1;
            
            while (true)
            {
                if (CancelThreads)
                {
                    Thread2Running = false;
                    break;
                }
                
                Thread.Sleep((int)id);
                Thread2turn++;
            }
        }
    }
    class Program
    {
        public static bool CancelThread2 = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Threading threading = new Threading();
            new Thread(threading.Thread1).Start();
            new Thread(threading.Thread2).Start(1000);

            Console.WriteLine("MAIN THREAD BEKLIYOR: ENTER'A BASARAK DİĞER BLOĞA GEÇİNİZ");
            Console.ReadLine();
            Console.WriteLine("DİĞER BLOK");
            threading.CancelThreads = true;

            while (true)
            {
                if (!threading.Thread1Running && !threading.Thread2Running)
                {
                    threading.CancelThreads = false;
                    break;
                }
            }
            
            new Thread(threading.Thread1).Start();
            new Thread(threading.Thread2).Start(300);
            Console.ReadLine();

        }
        
    }
}
