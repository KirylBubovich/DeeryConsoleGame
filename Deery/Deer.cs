﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Deery
{
    public class Deer
    {
        public StringBuilder[] Lines { get; set; }
        public int Flag { get; set; }
        public bool IsJumping { get; set; }
        public bool IsUp { get; set; }
        public int jumpingCounter = 0;
        private int count = 8;
        private const char c = '█', c1 = '■';
        private readonly string empty = new String(' ', 26);
        private readonly string bigEmpty = new string(' ', 110);
        private readonly string ground = new string('▒', 120);
        private const int skip = 12  ;
        #region
        [DllImport("msvcrt")]
        static extern int _getch();
        #endregion
        public Deer()
        {
            Flag = 0;
            Lines = new StringBuilder[count];
            for (int i = 0; i < count; ++i)
            {
                Lines[i] = new StringBuilder(empty);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < count; ++i)
            {
                Lines[i].Replace(c, ' ');
                Lines[i].Replace(c1, ' ');
            }
        }

        public void Print(bool isStart, decimal points)
        {
            Console.WriteLine(bigEmpty + (isStart ? "" : $"\n {bigEmpty}"));
            Console.WriteLine(bigEmpty + points);
            int _ = skip - jumpingCounter;
            for (int i = 0; i < _; ++i)
            {
                Console.WriteLine(bigEmpty);
            }
            foreach (var item in Lines)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < jumpingCounter; ++i)
            {
                Console.WriteLine(bigEmpty);
            }
            Console.WriteLine(ground);
        }
        public void Running()
        {
            PaintHead();
            for (int i = 5; i < 15; i++)
            {
                Lines[5][i] = c;
            }
            for (int i = 5; i < 14; i++)
            {
                Lines[6][i] = c;
            }
            PaintLegsWhenRunning();
        }

        public void Jumping()
        {
            IsUp &= jumpingCounter < 10;
            jumpingCounter += IsUp ? 1 : -1;
            if (jumpingCounter == 0)
            {
                IsJumping = false;
                Clear();
                while (Console.KeyAvailable)
                {
                    _getch();
                }
            }
            PaintHead();
            for (int i = 2; i < 5; i++)
            {
                Lines[5][i] = c1;
                Lines[6][i] = c1;
            }
            for (int i = 5; i < 15; i++)
            {
                Lines[5][i] = c;
                Lines[6][i] = c;
            }
            for (int i = 15; i < 18; i++)
            {
                Lines[5][i] = c1;
                Lines[6][i] = c1;
            }
        }
        private void PaintHead()
        {
            Lines[0][9] = c;
            Lines[0][15] = c;
            Lines[1][9] = c;
            Lines[1][10] = c;
            Lines[1][11] = c;
            Lines[1][13] = c;
            Lines[1][14] = c;
            Lines[1][15] = c;
            Lines[2][11] = c;
            Lines[2][13] = c;
            Lines[3][11] = c;
            Lines[3][12] = c;
            Lines[3][13] = c;
            Lines[3][14] = c;
            Lines[3][15] = c;
            Lines[4][5] = c;
            Lines[4][12] = c;
        }

        private void PaintLegsWhenRunning()
        {
            if (Flag == 0)
            {
                Lines[7][5] = c;
                Lines[7][7] = c;
                Lines[7][10] = c;
                Lines[7][12] = c;
            }
            else
            {
                Lines[7][6] = c;
                Lines[7][8] = c;
                Lines[7][11] = c;
                Lines[7][13] = c;
            }
        }
    }
}
