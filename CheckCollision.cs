using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class CheckCollision
    {
        public static bool CheckFinalPoint(BaseObjFigure figure, GameField gameField)
        {
            int[,] field = gameField.GetField();  // массив игрового поля
            int[,] obj = figure.GetFigure().GetObj();  // массив нашей фигуры
            Coord coord = figure.GetCoord();  // координаты фигуры
            Coord[] arrCoords = new Coord[Figure.SIZE];  // массив координат точек нашей фигуры

            // если фигура не полностью появилась на поле
            if (coord.y <= 2)
            {
                return false;
            }

            // заполняем по умолчанию список координат
            for (int i = 0; i < Figure.SIZE; i++)
            {
                arrCoords[i] = new Coord(-1, -1);
            }

            // находим 3 самые низкие точки у фигуры
            for (int i = 0; i < Figure.SIZE; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (obj[j, i] == (int)Field.ELEMENT)
                    {
                        arrCoords[i].x = coord.x + (i - 1);
                        arrCoords[i].y = coord.y + (j - 2);
                        break;
                    }
                }
            }

            // проверка каждой нижней точки на соприкосновение с элементом или с полом
            for (int i = 0; i < arrCoords.Length; i++)
            {
                if (arrCoords[i].x != -1 && arrCoords[i].y != -1)
                {
                    // если следующая координата по y указывает на элемент или пол, то столкновение
                    if (field[arrCoords[i].y + 1, arrCoords[i].x] == (int)Field.ELEMENT || field[arrCoords[i].y + 1, arrCoords[i].x] == (int)Field.WALL)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckGameOver(BaseObjFigure figure, GameField gameField)
        {
            int[,] field = gameField.GetField();  // массив игрового поля
            int[,] obj = figure.GetFigure().GetObj();  // массив нашей фигуры
            Coord coord = figure.GetCoord();  // координаты фигуры

            // если координата y > 3, значит точно не проиграли
            if (coord.y > Figure.SIZE)
            {
                return false;
            }

            // проходимся по нижней части фигуры (все три координаты по x)
            for (int x = coord.x - 1; x <= coord.x + 1; x++)
            {
                // если хотя бы одна из нижних частей фигуры коснётся элемента, то проигрыш
                if (obj[Figure.SIZE - 1, x - (coord.x - 1)] == (int)Field.ELEMENT && field[coord.y + 1, x] == (int)Field.ELEMENT)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckLeftCollision(BaseObjFigure figure, GameField gameField)
        {
            int[,] field = gameField.GetField();  // массив игрового поля
            int[,] obj = figure.GetFigure().GetObj();  // массив нашей фигуры
            Coord coord = figure.GetCoord();  // координаты фигуры
            Coord[] arrCoords = new Coord[Figure.SIZE];  // массив координат точек нашей фигуры

            // если фигура не полностью появилась на поле
            if (coord.y <= 2)
            {
                return false;
            }

            // заполняем по умолчанию список координат
            for (int i = 0; i < Figure.SIZE; i++)
            {
                arrCoords[i] = new Coord(-1, -1);
            }

            // находим 3 самые левые точки у фигуры
            for (int i = 0; i < Figure.SIZE; i++)
            {
                for (int j = 0; j < Figure.SIZE; j++)
                {
                    if (obj[i, j] == (int)Field.ELEMENT)
                    {
                        arrCoords[i].x = coord.x + (j - 1);
                        arrCoords[i].y = coord.y + (i - 2);
                        break;
                    }
                }
            }

            // проверка каждой левой точки на соприкосновение с элементом или со стеной
            for (int i = 0; i < arrCoords.Length; i++)
            {
                if (arrCoords[i].x != -1 && arrCoords[i].y != -1)
                {
                    // если следующая координата по x влево указывает на элемент или пол, то столкновение
                    if (field[arrCoords[i].y, arrCoords[i].x - 1] == (int)Field.ELEMENT || field[arrCoords[i].y, arrCoords[i].x - 1] == (int)Field.WALL)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool CheckRightCollision(BaseObjFigure figure, GameField gameField)
        {
            int[,] field = gameField.GetField();  // массив игрового поля
            int[,] obj = figure.GetFigure().GetObj();  // массив нашей фигуры
            Coord coord = figure.GetCoord();  // координаты фигуры
            Coord[] arrCoords = new Coord[Figure.SIZE];  // массив координат точек нашей фигуры

            // если фигура не полностью появилась на поле
            if (coord.y <= 2)
            {
                return false;
            }

            // заполняем по умолчанию список координат
            for (int i = 0; i < Figure.SIZE; i++)
            {
                arrCoords[i] = new Coord(-1, -1);
            }

            // находим 3 самые правые точки у фигуры
            for (int i = 0; i < Figure.SIZE; i++)
            {
                for (int j = Figure.SIZE - 1; j >= 0; j--)
                {
                    if (obj[i, j] == (int)Field.ELEMENT)
                    {
                        arrCoords[i].x = coord.x + (j - 1);
                        arrCoords[i].y = coord.y + (i - 2);
                        break;
                    }
                }
            }

            // проверка каждой правой точки на соприкосновение с элементом или со стеной
            for (int i = 0; i < arrCoords.Length; i++)
            {
                if (arrCoords[i].x != -1 && arrCoords[i].y != -1)
                {
                    // если следующая координата по x вправо указывает на элемент или пол, то столкновение
                    if (field[arrCoords[i].y, arrCoords[i].x + 1] == (int)Field.ELEMENT || field[arrCoords[i].y, arrCoords[i].x + 1] == (int)Field.WALL)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
