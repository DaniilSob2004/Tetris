using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class GameField
    {
        public const int WIDTH_F = 24;
        public const int HEIGHT_F = 20;
        private int[,] field = new int[HEIGHT_F, WIDTH_F];

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

        private int GetNumCleanLine()
        {
            bool flag;

            for (int i = 0; i < HEIGHT_F; i++)
            {
                flag = true;
                for (int j = 1; j < WIDTH_F - 1; j++)
                {
                    if (field[i, j] != (int)Field.ELEMENT)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return i;
                }
            }

            return -1;
        }

        public GameField()
        {
            BeginSetting();
        }

        public int[,] GetField()
        {
            return field;
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

        public void AddFigure(BaseObjFigure figure)
        {
            int[,] obj = figure.GetFigure().GetObj();  // массив частей нашей фигуры
            Coord coord = figure.GetCoord();  // координаты фигуры

            // переносим части фигуры на игровое поле
            for (int i = 0; i < Figure.SIZE; i++)
            {
                for (int x = coord.x - 1; x <= coord.x + 1; x++)
                {
                    if (obj[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.ELEMENT)
                    {
                        field[coord.y - i, x] = (int)Field.ELEMENT;
                    }
                }
            }
        }

        public void CleanLine(ref int nLine)
        {
            int y = 0;
            Random r = new Random();

            while (y != -1)
            {
                y = GetNumCleanLine();  // получаем координату y в которой заполнена линия
                if (y != -1)
                {
                    // воспроизводим звук
                    GameSound.DelLine();

                    // удаление заполненой линии
                    for (int j = 1; j < WIDTH_F - 1; j++)
                    {
                        if (field[y, j] == (int)Field.ELEMENT)
                        {
                            field[y, j] = (int)Field.EMPTY;

                            Console.SetCursorPosition(j, y);
                            Console.Write(" ");
                            Thread.Sleep(20);
                        }
                    }

                    // все верхние элементы фигур на поле опускаются на 1 координату по у вниз
                    for (int i = y - 1; i > 0; i--)
                    {
                        for (int j = 1; j < WIDTH_F - 1; j++)
                        {
                            if (field[i, j] == (int)Field.ELEMENT)
                            {
                                // запоминаем цвет элемента который был на прошлой позиции
                                ConsoleColor color = MyConsole.GetColor((short)j, (short)i);

                                // стираем элемент который был на прошлой позиции
                                Console.SetCursorPosition(j, i);
                                Console.Write(" ");
                                field[i, j] = (int)Field.EMPTY;

                                // отображаем элемент в новой позиции
                                Console.SetCursorPosition(j, i + 1);
                                Console.ForegroundColor = color;
                                Console.WriteLine(Convert.ToChar(0x25A0));
                                field[i + 1, j] = (int)Field.ELEMENT;
                            }
                        }
                    }

                    // кол-во линий
                    nLine++;
                }
            }
        }
    }
}
