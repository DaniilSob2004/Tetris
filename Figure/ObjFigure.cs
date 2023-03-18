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
                if (!gameField.CheckLeftCollision(this))
                {
                    coord.x -= 1;
                }
                break;

            case Direction.RIGHT:
                // если столкновения с правой стеной нет, то двигаем
                if (!gameField.CheckRightCollision(this))
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
        int y;

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

    public void FastDown(GameField gameField)
    {
        // пока фигура не коснулась пола или другой фигуры
        while (!gameField.CheckFinalPoint(this))
        {
            // двигаем и отображаем
            Move(Direction.DOWN, gameField);
            Show();
            Thread.Sleep(10);
        }
    }
}
