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

    public void AddFigure(IObjFigure figure)
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

    public bool CheckFinalPoint(IObjFigure figure)
    {
        int[,] obj = figure.GetFigure().GetObj();  // массив частей нашей фигуры
        Coord coord = figure.GetCoord();  // координаты фигуры
        List<int[]> arrCoords = new List<int[]>();  // список координат

        // если фигура не полностью появилась на поле
        if (coord.y <= 2)
        {
            return false;
        }

        // заполняем по умолчанию список координат
        for (int i = 0; i < Figure.SIZE; i++)
        {
            arrCoords.Add(new int[2] { -1, -1 });
        }

        // находим 3 самые низкие точки у фигуры
        for (int i = 0; i < Figure.SIZE; i++)
        {
            for (int j = 2; j >= 0; j--)
            {
                if (obj[j, i] == (int)Field.ELEMENT)
                {
                    arrCoords[i][0] = coord.x + (i - 1);
                    arrCoords[i][1] = coord.y + (j - 2);
                    break;
                }
            }
        }

        // сортировка от самой нижней точки до верхней точки по оси y
        SortCoordsArr(arrCoords);

        // проверка каждой нижней точки на соприкосновение с элементом или с полом
        for (int i = 0; i < arrCoords.Count; i++)
            {
                if (arrCoords[i][0] != -1 && arrCoords[i][1] != -1)
                {
                    // если следующая координата по y указывает на элемент или пол, то столкновение
                    if (field[arrCoords[i][1] + 1, arrCoords[i][0]] == (int)Field.ELEMENT || field[arrCoords[i][1] + 1, arrCoords[i][0]] == (int)Field.WALL)
                    {
                        return true;
                    }
                }
            }

        return false;
    }

    private void SortCoordsArr(List<int[]> arrCoords)
    {
        int[] temp;
        for (int i = 1; i < arrCoords.Count; i++)
        {
            for (int j = 0; j < arrCoords.Count - i; j++)
            {
                if (arrCoords[j][1] < arrCoords[j + 1][1])
                {
                    temp = arrCoords[j];
                    arrCoords[j] = arrCoords[j + 1];
                    arrCoords[j + 1] = temp;
                }
            }
        }
    }
}
