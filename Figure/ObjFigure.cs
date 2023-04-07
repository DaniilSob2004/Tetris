using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    // класс, который создаёт объект фигуры
    public class ObjFigure : BaseObjFigure
    {
        private static void TurnFigure(ref BaseFigure figure)
        {
            // в зависимости от типа фигуры который был, получаем новый тип фигуры
            switch (figure.Type)
            {
                case TypeFigure.Line1:
                    figure = PrototypeFigure.GetByType(TypeFigure.Line2);
                    break;

                case TypeFigure.Line2:
                    figure = PrototypeFigure.GetByType(TypeFigure.Line1);
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

                case TypeFigure.InvertedL1:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedL2);
                    break;

                case TypeFigure.InvertedL2:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedL3);
                    break;

                case TypeFigure.InvertedL3:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedL4);
                    break;

                case TypeFigure.InvertedL4:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedL1);
                    break;

                case TypeFigure.Z1:
                    figure = PrototypeFigure.GetByType(TypeFigure.Z2);
                    break;

                case TypeFigure.Z2:
                    figure = PrototypeFigure.GetByType(TypeFigure.Z1);
                    break;

                case TypeFigure.InvertedZ1:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedZ2);
                    break;

                case TypeFigure.InvertedZ2:
                    figure = PrototypeFigure.GetByType(TypeFigure.InvertedZ1);
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

        public ObjFigure(TypeFigure type, Coord coord) : 
            base(type, coord) { }

        public override void Move(Direction direction, GameField gameField)
        {
            if (gameField == null) throw new Exception("Reference GameField must be not null!");

            Hide();  // удаляем фигуру

            switch (direction)
            {
                case Direction.Down:
                    coord.y += 1;
                    break;

                case Direction.Left:
                    try
                    {
                        // если столкновения с левой стеной нет, то двигаем
                        if (!CheckCollision.CheckLeftCollision(this, gameField))
                        {
                            coord.x -= 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case Direction.Right:
                    try
                    {
                        // если столкновения с правой стеной нет, то двигаем
                        if (!CheckCollision.CheckRightCollision(this, gameField))
                        {
                            coord.x += 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }
        }

        public override void Show()
        {
            int[,] f = figure.Obj;  // массив нашей фигуры
            int y;

            // насколько фигура была уже отображена, т.к она появляется сверху
            if (coord.y <= 2) y = coord.y;
            else y = 3;

            Console.ForegroundColor = figure.Color;

            // отображаем фигуру
            for (int i = 0; i < y; i++)
            {
                for (int x = coord.x - 1; x <= coord.x + 1; x++)
                {
                    // если элемент в массиве равен Field.Element, то это элемент нашей фигуры и значит выводим
                    if (f[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.Element)
                    {
                        Console.SetCursorPosition(x, coord.y - i);
                        Console.WriteLine(Convert.ToChar(0x25A0));
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Hide()
        {
            int[,] f = figure.Obj;  // массив нашей фигуры
            int y;

            // насколько фигура была уже отображена, т.к она появляется сверху
            if (coord.y <= 2) y = coord.y;
            else y = 3;

            for (int i = 0; i < y; i++)
            {
                for (int x = coord.x - 1; x <= coord.x + 1; x++)
                {
                    // если элемент в массиве равен Field.ELEMENT, то это элемент нашей фигуры и значит выводим
                    if (f[Figure.SIZE - i - 1, x - (coord.x - 1)] == (int)Field.Element)
                    {
                        Console.SetCursorPosition(x, coord.y - i);
                        Console.Write(" ");
                    }
                }
            }
        }

        public override void Turn()
        {
            // если фигура находится возле стены, то не двигаем(нет места)
            if (coord.x <= 1 || coord.x >= GameField.WIDTH_F - 2) return;

            Hide();  // удаляем фигуру

            try
            {
                // вызов статического метода, который переворачивает фигуру
                TurnFigure(ref figure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void FastDown(GameField gameField)
        {
            if (gameField == null) throw new Exception("Reference GameField must be not null!");

            try
            {
                // пока фигура не коснулась пола или другой фигуры
                while (!CheckCollision.CheckFinalPoint(this, gameField))
                {
                    // двигаем и отображаем
                    Move(Direction.Down, gameField);
                    Show();
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}