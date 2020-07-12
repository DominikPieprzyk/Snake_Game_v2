using System;
using System.Threading;

namespace Snake_Game_v2
{
    class Game
    {
        public static int Width { get; } = 26;
        public static int Height { get; } = 26;

        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;

        Snake snake;
        Food   food;

        public int Score { set; get; }
        bool IsLost;
        bool IsWin;

        public Game() 
        {
            Console.CursorVisible = false;
            Console.Title = "D.Pieprzyk Console App";
            snake = new Snake();
            food = new Food();
        }

        void Restart() 
        {
            Space.Write(Width, Height);
            Console.Clear();

            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();

            IsLost = false;
            IsWin = false;

            snake.Restart();
            food.Restart();
            Space.Write(Width, Height);
        }

        void Control() 
        {
            if (Console.KeyAvailable) 
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            switch (consoleKey) 
            {
                case ConsoleKey.UpArrow:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.DownArrow;
                    else snake.Shift(Snake.Direction.Top);
                    break;
                case ConsoleKey.DownArrow:
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.UpArrow;
                    else snake.Shift(Snake.Direction.Bottom);
                    break;
                case ConsoleKey.LeftArrow:
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.RightArrow;
                    else snake.Shift(Snake.Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.LeftArrow;
                    else snake.Shift(Snake.Direction.Right);
                    break;
                default:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.DownArrow;
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.UpArrow;
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.RightArrow;
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.LeftArrow;
                    break;


            }
        }
        void Logic()
        {
            Control();
            food.Logic(ref snake);
            snake.Logic(ref IsLost, ref IsWin);
        }
        public void Play() 
        {
            while (true) 
            {
                Restart();
                while (IsLost == false && IsWin == false) 
                {
                    Logic();
                    Thread.Sleep(100);
                }
                if (IsWin == true)
                {
                    Console.SetCursorPosition(Height / 2 - 4, Width / 2);
                    Console.Write("You win!!! :D");
                }
                else if (IsLost == true) 
                {
                    Console.SetCursorPosition(Height / 2 -4, Width /2);
                    Console.Write("Game Over!");
                }
            }
            
        }
    }
}
