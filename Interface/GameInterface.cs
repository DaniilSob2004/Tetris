using static Tetris.EnumColl;


namespace Tetris
{
    public class GameInterface : BaseInterface
    {
        // создаём интерфейс для игры
        public override void InitialInterface()
        {
            // характеристики
            string[] arrTitles = new string[] { "Время:  00:00", "Рекорд:  0", "Очки:  0", "Фигура:  " };
            ConsoleColor[] arrColors = new ConsoleColor[] { ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Blue };

            for (int i = 0; i < arrTitles.Length; i++)
            {
                elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) + 7,
                                                                                 (Console.BufferHeight / 7) + (i * 2))));
            }

            // фигура
            BaseObjFigure objFigure = new ObjFigure(TypeFigure.Square, new Coord((Console.BufferWidth / 2) + 16, (Console.BufferHeight / 7) + 7));
            elements.Add(new FigureElement(objFigure));

            // меню
            arrTitles = new string[] { " Пауза", " Заново", " Назад" };
            arrColors = new ConsoleColor[] { colorSelect, ConsoleColor.White, ConsoleColor.White };

            for (int i = 0; i < arrTitles.Length; i++)
            {
                elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) + 9,
                                                                                 (Console.BufferHeight / 7) + 10 + (i * 2))));
            }
        }
    }
}
