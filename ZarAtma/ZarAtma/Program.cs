using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ZarAtma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            new Thread(Referee).Start();
            new Thread(Roll).Start(1);
            new Thread(Roll).Start(2);
            new Thread(Roll).Start(3);
        }

        public class RollStat
        {
            public int Id { get; set; }
            public int Count { get; set; }
            public int Value { get; set; }

        }
        private static bool CancelThreads = false;
        private static Random _random = new Random();
        private static List<RollStat> rollStats = new List<RollStat>()
        {
            new RollStat()
            {
                Id=1,
                Value=0,
                Count=0
            },
            new RollStat()
            {
                Id=2,
                Value=0,
                Count=0
            },
            new RollStat()
            {
                Id=3,
                Value=0,
                Count=0
            }
        };
        

        private static void Roll(object id)
        {
            while (true)
            {
                if (CancelThreads)
                {
                    break;
                }
                var selfStat = rollStats.Single(a => a.Id == (int)id);

                if (selfStat.Count < rollStats.OrderByDescending(a=>a.Count).First().Count 
                    || rollStats.Count(a=>a.Count == selfStat.Count)==3 )
                {
                       int result = _random.Next(1,10);
                    selfStat.Count++;
                    selfStat.Value =selfStat.Value + result;
                }

                
                Thread.Sleep(1000);
            }
        }
        private static void Referee()
        {
            int turn = 0;
            while (true)
            {
                if (rollStats.Count(a=>a.Count ==turn)==3)
                {
                    string stats = string.Empty;

                    foreach (RollStat rollStat in rollStats)
                {
                    stats += rollStat.Id + " : " + rollStat.Value + " |";
                }
                    Console.WriteLine(stats);

                    if (rollStats.Any(a=>a.Value>=100))
                    {
                        CancelThreads = true;
                        Console.WriteLine("Kazanan belli oldu!");
                    }

                    turn++;
                }
               
               
                
            }
        }
    }
}
