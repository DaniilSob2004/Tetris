using static Tetris.EnumColl;


// ПАТТЕРН PROTOTYPE
// Прототипы объектов BaseFigure будут хранится в хранилище PrototypeFigure
namespace Tetris
{
    // абстрактный класс, для фигур
    // реализуем интерфейс ICloneable
    public abstract class BaseFigure : ICloneable
    {
        public const int SIZE = 3;
        protected int[,] obj = new int[SIZE, SIZE];  // массив 3x3 для фигуры
        protected TypeFigure type;
        protected Color color;

        public BaseFigure(int[,] obj, TypeFigure type, Color color)
        {
            this.obj = obj;
            this.type = type;
            this.color = color;
        }

        public int[,] Obj
        {
            get { return obj; }
        }

        public TypeFigure Type
        {
            get { return type; }
        }

        public Color Color
        {
            get { return color; }
        }

        public abstract object Clone();
    }
}
