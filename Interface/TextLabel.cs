using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class TextLabel : Element
    {
        public TextLabel(string title, Color color, Coord coord) :
            base(title, color, coord) { }

        public override void SetValue(object value)
        {
            string obj = value as string;
            if (obj == null) throw new Exception("Reference object must be string!");

            this.value = obj;
        }

        public override void Show()
        {
            // устанавливаем курсор, меняем цвет и отображаем метку
            Console.SetCursorPosition(coord.x, coord.y);
            SetForegroundColor(Color);
            Console.WriteLine(value);
            SetForegroundColor(Color.WHITE);
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
