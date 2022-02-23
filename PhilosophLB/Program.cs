using System;
using System.Threading;

namespace PhilosophLB
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart TS = new ThreadStart(Game);

            Thread T = new Thread(TS);
            T.Start();
            Console.ReadLine();
        }

        public static void Game()
        {
            Philosoph[] p = new Philosoph[5];



            object[] fork = new object[5];
            for (int i = 0; i < 5; i++)
            {
                fork[i] = new object();
            }
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                    p[i] = new Philosoph() { leftFork = fork[i], RightFork = fork[0] };
                else
                    p[i] = new Philosoph() { leftFork = fork[i], RightFork = fork[i + 1] };
            }




            for (int i = 0; i < 5; i++)
            {
                while (p[i].isHungry == true)
                {
                    if (Monitor.TryEnter(p[i].leftFork))
                    {
                        if (Monitor.TryEnter(p[i].RightFork))
                        {
                            try
                            {
                                p[i].Eat();
                            }
                            finally
                            {
                                if (Monitor.IsEntered(p[i].RightFork))
                                {
                                    Monitor.Exit(p[i].RightFork);
                                    Console.WriteLine("Философ положил правую вилку");
                                }
                            }
                        }
                        try
                        {
                            p[i].Full();
                        }
                        finally
                        {
                            if (Monitor.IsEntered(p[i].leftFork))
                            {
                                Monitor.Exit(p[i].leftFork);
                                Console.WriteLine("Философ положил левую вилку");



                            }
                        }



                    }
                }
                if (p[i].isHungry == false)
                {
                    p[i].Doom();
                }
            }
        }
    }
}
