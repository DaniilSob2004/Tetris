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
    public interface IFigure
    {
        public int[,] GetObj();
        public TypeFigure GetTypeFigure();
        public Color GetColor();
        public IFigure Clone();
    }
}
