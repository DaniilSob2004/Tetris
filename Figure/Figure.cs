using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class Figure : BaseFigure
    {
        public Figure(int[,] obj, TypeFigure type, Color color) :
            base(obj, type, color) { }

        public override object Clone()
        {
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
