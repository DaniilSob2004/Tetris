using static Tetris.EnumColl;


namespace Tetris
{
    // класс, который создаёт фигуру
    public class Figure : BaseFigure
    {
        public Figure(int[,] obj, TypeFigure type, Color color) :
            base(obj, type, color) { }

        public override object Clone()
        {
            // создаётся клон объекта

            int[,] copyObj = new int[SIZE, SIZE];

            // глубокое копирование массива:
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    copyObj[i, j] = obj[i, j];
                }
            }

            return new Figure(copyObj, type, color);
        }
    }
}
