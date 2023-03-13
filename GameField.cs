using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class GameField
{
    public const int WIDTH_F = 24;
    public const int HEIGHT_F = 20;
    private int[,] field = new int[HEIGHT_F, WIDTH_F];

    public GameField()
    {
        BeginSetting();
    }

    private void BeginSetting()
    {
        // устанавливаем начальные значения игрового поля (стены и пустоту)
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (i == 0 || j == 0 || i == field.GetLength(0) - 1 || j == field.GetLength(1) - 1)
                {
                    field[i, j] = (int)Field.WALL;
                }
                else
                {
                    field[i, j] = (int)Field.EMPTY;
                }
            }
        }
    }

    public void Show()
    {
        // отображаем игровое поле
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == (int)Field.WALL)
                {
                    SetForegroundColor(Color.DARK_GREEN);
                    Console.Write(Convert.ToChar(0x2593));
                    SetForegroundColor(Color.WHITE);
                }
                else if (field[i, j] == (int)Field.ELEMENT)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    public void Clear()
    {
        // очищаем игровое поле от элементов(фигур)
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == (int)Field.ELEMENT)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
        }
    }

    public void AddFigure(IObjFigure figure) {}
}
