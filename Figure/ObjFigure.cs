using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class ObjFigure : IObjFigure
{
    private IFigure figure;
    private Coord coord;

    public ObjFigure(TypeFigure type)
    {
        figure = PrototypeFigure.GetByType(type);
        coord = new Coord((GameField.WIDTH_F / 2) - 1, 0);
    }

    public IFigure GetFigure()
    {
        return figure;
    }

    public Coord GetCoord()
    {
        return coord;
    }

    public void Move(Direction direction, GameField gameField) 
    {
        Hide();  // удаляем фигуру

        switch (direction)
        {
            case Direction.DOWN:
                coord.y += 1;
                break;

            case Direction.LEFT:
                // если столкновения с левой стеной нет, то двигаем
                if (!CheckLeftCollisionWall(gameField))
                {
                    coord.x -= 1;
                }
                break;

            case Direction.RIGHT:
                // если столкновения с правой стеной нет, то двигаем
                if (!CheckRightCollisionWall(gameField))
                {
                    coord.x += 1;
                }
                break;
        }
    }

    public void Show()
    {
        int[,] f = figure.GetObj();
        int y = 0;

        // насколько будет отображаться фигура, т.к она появляется сверху
        if (coord.y <= 2) y = coord.y;
        else y = 3;

        SetForegroundColor(figure.GetColor());
        for (int i = 0; i < y; i++)
        {
            for (int x = coord.x - 1; x <= coord.x + 1; x++)
            {
                if (f[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.ELEMENT)
                {
                    Console.SetCursorPosition(x, coord.y - i);
                    Console.Write("*");
                }
            }
        }
        SetForegroundColor(Color.WHITE);
    }

    public void Hide() 
    {
        int[,] f = figure.GetObj();
        int y = 0;

        // насколько фигура была уже отображена, т.к она появляется сверху
        if (coord.y <= 3) y = coord.y;
        else y = 3;

        for (int i = 0; i < y; i++)
        {
            for (int x = coord.x - 1; x <= coord.x + 1; x++)
            {
                if (f[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.ELEMENT)
                {
                    Console.SetCursorPosition(x, coord.y - i);
                    Console.Write(" ");
                }
            }
        }
    }

    public void Turn()
    {
        // если фигура находится возле стены, то не двигаем(нет места)
        if (coord.x <= 1 || coord.x >= GameField.WIDTH_F - 2)
        {
            return;
        }

        Hide();  // удаляем фигуру

        // в зависимости от типа фигуры который был, получаем новый тип
        switch (figure.GetTypeFigure())
        {
            case TypeFigure.LINE1:
                figure = PrototypeFigure.GetByType(TypeFigure.LINE2);
                break;

            case TypeFigure.LINE2:
                figure = PrototypeFigure.GetByType(TypeFigure.LINE1);
                break;

            case TypeFigure.L1:
                figure = PrototypeFigure.GetByType(TypeFigure.L2);
                break;

            case TypeFigure.L2:
                figure = PrototypeFigure.GetByType(TypeFigure.L3);
                break;

            case TypeFigure.L3:
                figure = PrototypeFigure.GetByType(TypeFigure.L4);
                break;

            case TypeFigure.L4:
                figure = PrototypeFigure.GetByType(TypeFigure.L1);
                break;

            case TypeFigure.INVERTED_L1:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_L2);
                break;

            case TypeFigure.INVERTED_L2:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_L3);
                break;

            case TypeFigure.INVERTED_L3:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_L4);
                break;

            case TypeFigure.INVERTED_L4:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_L1);
                break;

            case TypeFigure.Z1:
                figure = PrototypeFigure.GetByType(TypeFigure.Z2);
                break;

            case TypeFigure.Z2:
                figure = PrototypeFigure.GetByType(TypeFigure.Z1);
                break;

            case TypeFigure.INVERTED_Z1:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_Z2);
                break;

            case TypeFigure.INVERTED_Z2:
                figure = PrototypeFigure.GetByType(TypeFigure.INVERTED_Z1);
                break;

            case TypeFigure.T1:
                figure = PrototypeFigure.GetByType(TypeFigure.T2);
                break;

            case TypeFigure.T2:
                figure = PrototypeFigure.GetByType(TypeFigure.T3);
                break;

            case TypeFigure.T3:
                figure = PrototypeFigure.GetByType(TypeFigure.T4);
                break;

            case TypeFigure.T4:
                figure = PrototypeFigure.GetByType(TypeFigure.T1);
                break;
        }
    }

    private bool CheckRightCollisionWall(GameField gameField)
    {
        int[,] obj = figure.GetObj();  // массив частей нашей фигуры
        int[,] field = gameField.GetField();  // массив игрового поля
        Coord[] arrCoords = new Coord[Figure.SIZE];  // массив координат

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

    private bool CheckLeftCollisionWall(GameField gameField)
    {
        int[,] obj = figure.GetObj();  // массив частей нашей фигуры
        int[,] field = gameField.GetField();  // массив игрового поля
        Coord[] arrCoords = new Coord[Figure.SIZE];  // массив координат

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
}
