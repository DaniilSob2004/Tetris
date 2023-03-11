using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


//namespace Tetris.Interface
//{
public class MainInterface : BaseInterface
{
    public override void InitialInterface()
    {
        elements.Add(new TextLabel("ГЛАВНОЕ МЕНЮ", Color.WHITE, new Coord((Console.BufferWidth / 2) - ("ГЛАВНОЕ МЕНЮ".Length / 2), Console.BufferHeight / 3)));
        elements.Add(new TextLabel("1. Начать игру", Color.GREEN, new Coord((Console.BufferWidth / 2) - ("1. Начать игру".Length / 2), (Console.BufferHeight / 3) + 3)));
        elements.Add(new TextLabel("2. Выйти из игры", Color.WHITE, new Coord((Console.BufferWidth / 2) - ("2. Выйти из игры".Length / 2), (Console.BufferHeight / 3) + 6)));
    }
}
//}
