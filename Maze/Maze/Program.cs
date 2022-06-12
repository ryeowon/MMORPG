using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize(25);

            Console.CursorVisible = false;

            int lastTick = 0;

            while (true)
            {
                #region 프레임 관리
                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lastTick;

                if (elapsedTick < 1000 / 30) // ms
                    continue;
                lastTick = currentTick;
                #endregion

                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}