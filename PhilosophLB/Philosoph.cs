using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosophLB
{
    class Philosoph
    {
        public object leftFork { get; set; }
        public object RightFork { get; set; }
        public bool isHungry { get; set; } = true;
        public void Eat()
        {
            Console.WriteLine("Философ ест");

        }
        public void Full()
        {
            Console.WriteLine("Философ наелся ");
            isHungry = false;
        }
        public void Doom()
        {
            Console.WriteLine("Философ думает");
        }
    }
}
