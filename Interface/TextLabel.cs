using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


//namespace Tetris.Interface
//{
public class TextLabel : Element
{
    public TextLabel(string title, Color color, Coord coord) :
        base(title, color, coord) { }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public override void Show()
    {
        Console.SetCursorPosition(coord.x, coord.y);
        switch (color)
        {
            case Color.WHITE:
                Console.ForegroundColor = ConsoleColor.White;
                break;

            case Color.GREEN:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
        }
        Console.WriteLine(title);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public override void Hide()
    {
        for (int i = 0; i < title.Length; i++)
        {
            Console.SetCursorPosition(coord.x + i, coord.y);
            Console.WriteLine(" ");
        }
    }
}
//}
