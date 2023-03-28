using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Tetris
{
    public class MyConsole
    {
        public static ConsoleColor GetColor(short x, short y)
        {
            var colors = new ushort[1];
            uint numberOfCharactersRead;

            if (ReadConsoleOutputAttribute(GetStdHandle(-11), colors, 1, new Coord(x, y), out numberOfCharactersRead))
            {
                return (ConsoleColor)(colors[0] % 16);
            }
            return ConsoleColor.White;
        }

        // извлекает дескриптор для стандартного ввода данных, стандартного вывода или стандартной ошибки устройства
        // классы-дескрипторы — управляемые классы, имеющие указатель на родной класс в качестве члена
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadConsoleOutputAttribute(IntPtr hConsoleOutput, [Out] ushort[] lpAttribute, uint length, Coord bufferCoord, out uint lpNumberOfCharactersRead);

        public struct Coord
        {
            public short X;
            public short Y;

            public Coord(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
