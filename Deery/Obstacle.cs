using System;

namespace Deery
{
    public class Obstacle
    {
        public double Cur { get; set; }
        public double Speed { get; set; }
        private readonly int height = 4;
        private readonly string[] obstacle;
        private Random rand = new Random();

        public Obstacle()
        {
            Cur = -100;
            Speed = 1.6;
            obstacle = new string[height];
            for (int i = 0; i < height; ++i)
            {
                obstacle[i] = "▒";
            }
        }

        public void Print()
        {
            int i = 0;
            if (Cur >= 0)
            {
                foreach (var item in obstacle)
                {
                    Console.SetCursorPosition(119 - (int)Cur, 19 + i);
                    Console.WriteLine(item + ((Cur > 0) ? new string(' ', (int)Cur) : ""));
                    ++i;
                }
            }
            if (Cur < 118 - Speed)
                Cur += Speed;
            else
            {
                Cur = -rand.Next(0, 100) * rand.NextDouble();
                Speed += 0.1;
            }
        }
    }
}
