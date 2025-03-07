using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch(); //c언어 함수 가져옴


        public static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }



        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            GameManager gm = new GameManager();
            gm.Initialize();

            int Curr = Environment.TickCount;

            while(true)
            {
                if(Curr+50 <Environment.TickCount)
                {
                    Curr = Environment.TickCount;

                    gm.Progress();
                    gm.Render();
                }
            }
        }
    }
}
