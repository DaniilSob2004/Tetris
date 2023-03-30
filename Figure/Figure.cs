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
            base(obj, type, color)
        { }

        // конструктор с параметром этого же объекта
        public Figure(BaseFigure figure) :
            this(figure.GetObj(), figure.GetTypeFigure(), figure.GetColor())
        { }

        public override BaseFigure Clone()
        {
            // возвращается клон этого же объекта
            return new Figure(this);
        }
    }
}
