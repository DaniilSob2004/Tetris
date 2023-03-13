using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public struct EnumColl
{
    public enum Direction
    {
        DOWN,
        LEFT,
        RIGHT
    }

    public enum Field
    {
        EMPTY,
        ELEMENT,
        WALL
    }

    public enum TypeFigure
    {
        LINE1,
        LINE2,
        SQUARE,
        L1,
        L2,
        L3,
        L4,
        INVERTED_L1,
        INVERTED_L2,
        INVERTED_L3,
        INVERTED_L4,
        Z1,
        Z2,
        INVERTED_Z1,
        INVERTED_Z2,
        T1,
        T2,
        T3,
        T4
    }

    public enum Color
    {
        WHITE,
        DARK_GREEN,
        RED,
        GREEN,
        BLUE,
        YELLOW,
        CYAN,
        MAGENTA
    }

    public static void SetForegroundColor(Color color)
    {
        switch (color)
        {
            case Color.DARK_GREEN:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;

            case Color.RED:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case Color.GREEN:
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case Color.BLUE:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;

            case Color.YELLOW:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

            case Color.CYAN:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;

            case Color.MAGENTA:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }
}
