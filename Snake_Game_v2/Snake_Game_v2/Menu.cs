using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game_v2
{
    class Menu
    {
       
        static void Main(string[] args)
        {
            int Opt = 0;
            string[] ConsoleOptions = new string[] { "Play Game", "Settings", "Exit Game" };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < ConsoleOptions.Length; i++)
                {
                    if (Opt == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine("{0}.{1}", i, ConsoleOptions[i]);
                    if (Opt == i)
                    {
                        Console.ResetColor();
                    }
                }
                var KeyPressed = Console.ReadKey();
                if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (Opt != ConsoleOptions.Length - 1)
                    {
                        Opt++;
                    }
                }
                else if (KeyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (Opt != 0)
                    {
                        Opt--;
                    }
                }
                if (KeyPressed.Key == ConsoleKey.Enter)
                {

                }

                switch (Opt)
                {
                    case 0:
                        Console.Clear();
                        Game game = new Game();
                        game.Play();
                        Thread.Sleep(120);
                        break;
                    case 1:
                        

                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        break;

                }
            }
        }
    }
}


