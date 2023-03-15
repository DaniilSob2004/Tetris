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
        Clear();

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

    public void AddFigure(IObjFigure figure)
    {
        // получаем массив нашего объекта
        int[,] obj = figure.GetFigure().GetObj();
        Coord coord = figure.GetCoord();

        for (int i = 0; i < Figure.SIZE; i++)
        {
            for (int x = coord.x - 1; x <= coord.x + 1; x++)
            {
                if (obj[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.ELEMENT)
                {
                    try
                    {
                        field[coord.y - i, x] = (int)Field.ELEMENT;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("AddFigure()");
                    }
                }
            }
        }
    }

    public bool CheckFinalPoint(IObjFigure figure)
    {
        int[,] obj = figure.GetFigure().GetObj();
        Coord coord = figure.GetCoord();

        List<int[]> arrCoords = new List<int[]>();
        for (int i = 0; i < 3; i++)
        {
            arrCoords.Add(new int[2] { -1, -1 });
        }


        if (coord.y > 2)
        {
            #region проверка для пола
            /*if (field[coord.y + 1, coord.x - 1] == (int)Field.WALL &&
                field[coord.y + 1, coord.x] == (int)Field.WALL &&
                field[coord.y + 1, coord.x + 1] == (int)Field.WALL)
            {
                return true;
            }
            else
            {*/
            #endregion

            // находим 3 самые низкие точки у фигуры
            for (int i = 2; i >= 0; i--)
                {
                    if (obj[i, 0] == 1)
                    {
                        arrCoords[0][0] = coord.x - 1;
                        if (i == 2) arrCoords[0][1] = coord.y;
                        else if (i == 1) arrCoords[0][1] = coord.y - 1;
                        else if (i == 0) arrCoords[0][1] = coord.y - 2;
                        break;
                    }
                }
            for (int i = 2; i >= 0; i--)
                {
                    if (obj[i, 1] == 1)
                    {
                        arrCoords[1][0] = coord.x;
                        if (i == 2) arrCoords[1][1] = coord.y;
                        else if (i == 1) arrCoords[1][1] = coord.y - 1;
                        else if (i == 0) arrCoords[1][1] = coord.y - 2;
                        break;
                    }
                }
            for (int i = 2; i >= 0; i--)
                {
                    if (obj[i, 2] == 1)
                    {
                        arrCoords[2][0] = coord.x + 1;
                        if (i == 2) arrCoords[2][1] = coord.y;
                        else if (i == 1) arrCoords[2][1] = coord.y - 1;
                        else if (i == 0) arrCoords[2][1] = coord.y - 2;
                        break;
                    }
                }

            // сортировка от самой нижней точки
            SortCoordsArr(arrCoords);

            // проверка каждого нижней точки на соприкосновение
            for (int i = 0; i < arrCoords.Count; i++)
            {
                if (arrCoords[i][0] != -1 && arrCoords[i][1] != -1)
                {
                    if (field[arrCoords[i][1] + 1, arrCoords[i][0]] == (int)Field.ELEMENT || field[arrCoords[i][1] + 1, arrCoords[i][0]] == (int)Field.WALL)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else
        {
            return false;
        }
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
