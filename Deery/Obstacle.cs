using System;
using System.Collections.Generic;
using System.Text;

namespace Deery
{
    public class Obstacle
    {
        public int Cur = 0;
        private int height = 4;
        private string[] zero;
        private string[] one;

        public Obstacle()
        {
            zero = new string[height];
            one = new string[height];
            for(int i = 0; i < height; ++i)
            {
                zero[i] = "▒";
                one[i] = "▒▒";
            }
        }

        public void Print(int kind)
        {
            int i = 0;
            foreach (var item in kind == 0 ? zero : one)
            {
                Console.SetCursorPosition(119 - Cur, 19 + i);
                Console.WriteLine(item + ((Cur != 0) ? new string(' ', Cur):""));
                ++i;
            }
            if(Cur < 119)
            ++Cur;
            else
            {
                Cur = 0;
            }
        }
    }
}
