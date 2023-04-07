using static Tetris.EnumColl;


namespace Tetris
{
    // интерфейс для элементов интерфейса программы
    public interface IElement
    {
        public ConsoleColor Color { get; set; }
        public string GetValue();
        public void SetValue(object value);
        public void Show();
        public void Hide();
    }
}
