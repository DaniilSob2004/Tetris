using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class Figure : IFigure
    {
        public const int SIZE = 3;  // размер массива(кол-во элементов по оси x и y)
        private int[,] obj = new int[SIZE, SIZE];  // массив 3x3 для фигуры
        private TypeFigure type;
        private Color color;

        // конструктор с параметром этого же объекта
        public Figure(IFigure figure) :
            this(figure.GetObj(), figure.GetTypeFigure(), figure.GetColor())
        { }

        public Figure(int[,] obj, TypeFigure type, Color color)
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

        public IFigure Clone()
        {
            // возвращается клон этого же объекта
            return new Figure(this);
        }
    }
}
