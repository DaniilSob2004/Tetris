using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public abstract class BaseObjFigure
    {
        protected BaseFigure figure;
        protected Coord coord;

        public BaseObjFigure(TypeFigure type, Coord coord)
        {
            figure = PrototypeFigure.GetByType(type);
            this.coord = coord;
        }

        public BaseFigure GetFigure()
        {
            return figure;
        }

        public Coord GetCoord()
        {
            return coord;
        }

        public abstract void Move(Direction direction, GameField gameField);
        public abstract void Show();
        public abstract void Hide();
        public abstract void Turn();
        public abstract void FastDown(GameField gameField);
    }
}
