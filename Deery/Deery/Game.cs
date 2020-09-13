using System;
using System.Text;
using System.Threading;

namespace Deery
{
    class Game
    {
        static void Main(string[] args)
        {
            Deer deery = new Deer();
            decimal points = 0M;
            StartGame(ref deery);
            while (true)
            {
                deery.Running();
                Console.SetCursorPosition(0, 0);
                deery.Print(false, points);
                deery.flag ^= 1;
                deery.Clear();
                ++points;
                Thread.Sleep(50);
            }
            Console.ReadKey();
        }

        public static void StartGame(ref Deer deery)
        {
            Console.WriteLine("Greetings my friend, press any key to start the game");
            deery.Running();
            deery.Print(true, 0M);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
