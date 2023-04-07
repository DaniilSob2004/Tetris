using static Tetris.EnumColl;


namespace Tetris
{
    // класс для создания текстовой метки
    public class TextLabel : Element
    {
        public TextLabel(string title, ConsoleColor color, Coord coord) :
            base(title, color, coord) { }

        public override void SetValue(object value)
        {
            // проверяем тип ссылки переданной в параметре
            string? obj = value as string;
            if (obj == null) throw new Exception("Reference object must be string!");

            this.value = obj;
        }

        public override void Show()
        {
            // устанавливаем курсор, меняем цвет и отображаем метку
            Console.SetCursorPosition(coord.x, coord.y);
            Console.ForegroundColor = Color;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Hide()
        {
            // удаляем текстовую метку
            for (int i = 0; i < value.Length; i++)
            {
                Console.SetCursorPosition(coord.x + i, coord.y);
                Console.WriteLine(" ");
            }
        }
    }
}
