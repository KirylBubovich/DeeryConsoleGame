using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Deery
{
    class Game
    {
        #region
        [DllImport("msvcrt")]
        static extern int _getch();
        #endregion
        static void Main(string[] args)
        {
            Deer deery = new Deer();
            Obstacle obstacle = new Obstacle();
            Random rand = new Random();
            decimal points = 0M;
            bool game = true;
            StartGame(ref deery);
            while (game)
            {
                
                CatchKey(ref deery);
                if (deery.IsJumping)
                {
                    deery.Jumping();
                }
                else
                {
                    deery.Running();
                }
                Console.SetCursorPosition(0, 0);
                deery.Print(false, points);
                deery.flag ^= 1;
                deery.Clear();
                ++points;
                obstacle.Print(rand.Next(0, 1));
                if(obstacle.Cur > 103 && obstacle.Cur <= 118 && deery.jumpingCounter < 4)
                {
                    game = false;
                }
                Thread.Sleep(50);
            }
            GameOver(ref deery, points);
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

        public static void GameOver(ref Deer deery, decimal points)
        {
            Console.WriteLine($"Game over :(\t\t\t\tYour points, sir: {points-1}\t\t\t\t\t\tThanks for game!");
        }

        public static void CatchKey(ref Deer deery)
        {
            if (Console.KeyAvailable && !  deery.IsJumping)
            {
                if (Convert.ToChar(_getch()) == ' ')
                {
                    deery.IsJumping = true;
                    deery.IsUp = true;
                }
            }
        }
    }
}
