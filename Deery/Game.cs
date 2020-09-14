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
        static readonly ConsoleColor[] colors = new ConsoleColor[]{ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.Cyan,
        ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.Magenta};
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
                deery.Flag ^= 1;
                deery.Clear();
                ++points;
                obstacle.Print();
                IsGameOver(ref obstacle, ref deery, ref game);
                Thread.Sleep(50);
                ChangeColor(points, ref rand);
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

        public static void IsGameOver(ref Obstacle obstacle, ref Deer deery, ref bool game)
        {
            if (obstacle.Cur > 105 && obstacle.Cur <= 118
                    &&
                    (deery.jumpingCounter < 3 || (deery.jumpingCounter == 3 && !deery.IsUp)))
            {
                game = false;
            }
        }
        public static void GameOver(ref Deer deery, decimal points)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Game over :(\t\t\t\t\tYour points, sir: {points-1}\t\t\t\t\tThanks for game!");
        }

        public static void CatchKey(ref Deer deery)
        {
            if (Console.KeyAvailable && !deery.IsJumping)
            {
                if (Convert.ToChar(_getch()) == ' ')
                {
                    deery.IsJumping = true;
                    deery.IsUp = true;
                }
            }
        }

        public static void ChangeColor(decimal points, ref Random rand)
        {
            if (points % 200 == 0)
            {
                do
                {
                    Console.ForegroundColor = (ConsoleColor)colors.GetValue(rand.Next(colors.Length));
                }
                while (Console.ForegroundColor == ConsoleColor.Black);
            }
        }
    }
}
