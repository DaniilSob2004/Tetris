using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


// ПАТТЕРН PROTOTYPE
// Хранилище прототипов объектов IFigure
namespace Tetris
{
    public class PrototypeFigure
    {
        public const int N_TYPE_FIGURES = 7;
        public const int N_ALL_PROTOTYPES = 19;
        private static BaseFigure[] items = new BaseFigure[N_ALL_PROTOTYPES];

        public static void InitPrototype()
        {
            // все возможные прототипы

            items[0] = new Figure(new int[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }, TypeFigure.LINE1, Color.CYAN);
            items[1] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }, TypeFigure.LINE2, Color.CYAN);

            items[2] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 1 }, { 0, 1, 1 } }, TypeFigure.SQUARE, Color.YELLOW);

            items[3] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 1, 0 } }, TypeFigure.L1, Color.WHITE);
            items[4] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 1, 0, 0 } }, TypeFigure.L2, Color.WHITE);
            items[5] = new Figure(new int[,] { { 0, 1, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }, TypeFigure.L3, Color.WHITE);
            items[6] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 0, 1 }, { 1, 1, 1 } }, TypeFigure.L4, Color.WHITE);

            items[7] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 1, 1 } }, TypeFigure.INVERTED_L1, Color.DARK_GREEN);
            items[8] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 0, 0 }, { 1, 1, 1 } }, TypeFigure.INVERTED_L2, Color.DARK_GREEN);
            items[9] = new Figure(new int[,] { { 1, 1, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }, TypeFigure.INVERTED_L3, Color.DARK_GREEN);
            items[10] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 1 } }, TypeFigure.INVERTED_L4, Color.DARK_GREEN);

            items[11] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 0 }, { 0, 1, 1 } }, TypeFigure.Z1, Color.GREEN);
            items[12] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 1, 0 } }, TypeFigure.Z2, Color.GREEN);

            items[13] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 1 }, { 1, 1, 0 } }, TypeFigure.INVERTED_Z1, Color.RED);
            items[14] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 0, 1, 0 } }, TypeFigure.INVERTED_Z2, Color.RED);

            items[15] = new Figure(new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } }, TypeFigure.T1, Color.BLUE);
            items[16] = new Figure(new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 0, 0, 1 } }, TypeFigure.T2, Color.BLUE);
            items[17] = new Figure(new int[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 1, 1, 1 } }, TypeFigure.T3, Color.BLUE);
            items[18] = new Figure(new int[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 0, 0 } }, TypeFigure.T4, Color.BLUE);
        }

        public static BaseFigure GetByType(TypeFigure type)
        {
            // найти прототип IFigure по типу и вернуть клон
            foreach (BaseFigure figure in items)
            {
                if (figure.GetTypeFigure() == type)
                {
                    return figure.Clone();
                }
            }
            throw new Exception("There is no figure for this type!");
        }
    }
}
