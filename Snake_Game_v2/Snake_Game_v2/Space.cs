using System;

namespace Snake_Game_v2
{
    class Space
    {
        static public void Write(int Width, int Height)
        {
            for (int i = 1; i <= Width; i++)
            {
                CharWrite(i, 0, '─');
                CharWrite(i, (Height + 1), '─');
            }
            for (int i = 1; i <= Height; i++)
            {
                CharWrite(0, i, '│');
                CharWrite((Width + 1), i, '│');
            }

            CharWrite(0, 0, '┌');
            CharWrite((Width + 1), 0, '┐');
            CharWrite(0, (Height + 1), '└');
            CharWrite((Width + 1), (Height + 1), '┘');
        }

        static void CharWrite(int x, int y, char trace ) 
        {
            Console.SetCursorPosition(x, y);
            Console.Write(trace);
        }
    
    }
}
