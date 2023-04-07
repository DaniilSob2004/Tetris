using static Tetris.EnumColl;


// ПАТТЕРН PROTOTYPE
// Хранилище прототипов объектов IFigure
namespace Tetris
{
    public static class PrototypeFigure
    {
        public const int N_TYPE_FIGURES = 7;
        public const int N_ALL_PROTOTYPES = 19;
        private static BaseFigure[] items = new BaseFigure[N_ALL_PROTOTYPES];

        public static void InitPrototype()
        {
            // все возможные прототипы

            items[0] = new Figure(new int[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }, TypeFigure.Line1, ConsoleColor.Cyan);
            items[1] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }, TypeFigure.Line2, ConsoleColor.Cyan);

            items[2] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 1 }, { 0, 1, 1 } }, TypeFigure.Square, ConsoleColor.Yellow);

            items[3] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 0 } }, TypeFigure.L1, ConsoleColor.White);
            items[4] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 1, 0, 0 } }, TypeFigure.L2, ConsoleColor.White);
            items[5] = new Figure(new int[,] { { 0, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }, TypeFigure.L3, ConsoleColor.White);
            items[6] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 0, 1 }, { 1, 1, 1 } }, TypeFigure.L4, ConsoleColor.White);

            items[7] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 1, 1 } }, TypeFigure.InvertedL1, ConsoleColor.Magenta);
            items[8] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } }, TypeFigure.InvertedL2, ConsoleColor.Magenta);
            items[9] = new Figure(new int[,] { { 1, 1, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }, TypeFigure.InvertedL3, ConsoleColor.Magenta);
            items[10] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 1 } }, TypeFigure.InvertedL4, ConsoleColor.Magenta);

            items[11] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } }, TypeFigure.Z1, ConsoleColor.Green);
            items[12] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } }, TypeFigure.Z2, ConsoleColor.Green);

            items[13] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 1 }, { 1, 1, 0 } }, TypeFigure.InvertedZ1, ConsoleColor.Red);
            items[14] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 0 } }, TypeFigure.InvertedZ2, ConsoleColor.Red);

            items[15] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }, TypeFigure.T1, ConsoleColor.Blue);
            items[16] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 0, 1 } }, TypeFigure.T2, ConsoleColor.Blue);
            items[17] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 1, 1, 1 } }, TypeFigure.T3, ConsoleColor.Blue);
            items[18] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 0, 0 } }, TypeFigure.T4, ConsoleColor.Blue);
        }

        public static BaseFigure GetByType(TypeFigure type)
        {
            // находим прототип IFigure по типу и возвращаем его клон
            foreach (BaseFigure figure in items)
            {
                if (figure.Type == type)
                {
                    return (BaseFigure)figure.Clone();
                }
            }
            throw new Exception("There is no figure for this type!");
        }
    }
}
