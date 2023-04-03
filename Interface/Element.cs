using static Tetris.EnumColl;


namespace Tetris
{
    // абстрактный класс, для объекта элемента интерфейса программы
    public abstract class Element : IElement
    {
        protected string value;
        protected Coord coord;

        public Element(string value, Color color, Coord coord)
        {
            SetValue(value);
            Color = color;
            this.coord = coord;
        }

        public Color Color { get; set; }

        public string GetValue()
        {
            return value;
        }

        public abstract void SetValue(object value);
        public abstract void Show();
        public abstract void Hide();
    }
}
