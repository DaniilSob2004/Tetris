using static Tetris.EnumColl;


namespace Tetris
{
    // абстрактный класс, для объекта фигур
    public abstract class BaseObjFigure
    {
        protected BaseFigure figure;
        protected Coord coord;

        public BaseObjFigure(TypeFigure type, Coord coord)
        {
            figure = PrototypeFigure.GetByType(type);
            this.coord = coord;
        }

        public BaseFigure ObjFigure
        {
            get { return figure; }
        }

        public Coord Coord
        {
            get { return coord; }
        }

        public abstract void Move(Direction direction, GameField gameField);
        public abstract void Show();
        public abstract void Hide();
        public abstract void Turn();
        public abstract void FastDown(GameField gameField);
    }
}
