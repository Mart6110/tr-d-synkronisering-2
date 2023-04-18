using System;
using System.Threading;

namespace tråd_synkronisering_2
{
    class Program
    {
        static object _lock = new object();
        static int _number = 60;
        static int _count;

        public static void Star()
        {
            string stars = "*";

            while(_count != 60)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < _number; i++)
                    {
                        Console.Write(stars);
                    }

                    Console.Write(_number);
                    Console.WriteLine();
                    _number += 60;
                    _count++;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        public static void Hash()
        {
            string hashtag = "#";

            while(_count != 60)
            {
                Monitor.Enter(_lock);
                try
                {
                    for (int i = 0; i < _number; i++)
                    {
                        Console.Write(hashtag);
                    }

                    Console.Write(_number);
                    Console.WriteLine();
                    _number += 60;
                    _count++;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                finally
                {
                    Monitor.Exit(_lock);
                }
            }
        }

        static void Main(string[] args)
        {
            Thread star = new Thread(Star);
            Thread hash = new Thread(Hash);

            star.Start();
            hash.Start();

            star.Join();
            hash.Join();
        }
    }
}
