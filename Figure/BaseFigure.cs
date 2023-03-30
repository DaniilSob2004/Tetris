using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


// ПАТТЕРН PROTOTYPE
// Прототипы объектов IFigure будут хранится в хранилище PrototypeFigure
namespace Tetris
{
    public abstract class BaseFigure
    {
        public const int SIZE = 3;
        private int[,] obj = new int[SIZE, SIZE];  // массив 3x3 для фигуры
        private TypeFigure type;
        private Color color;

        public BaseFigure(int[,] obj, TypeFigure type, Color color)
        {
            this.obj = obj;
            this.type = type;
            this.color = color;
        }

        public int[,] GetObj()
        {
            return obj;
        }

        public TypeFigure GetTypeFigure()
        {
            return type;
        }

        public Color GetColor()
        {
            return color;
        }

        public abstract BaseFigure Clone();
    }
}
