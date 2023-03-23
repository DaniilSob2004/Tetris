using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class GameInterface : BaseInterface
{
    // создаём интерфейс для игры
    public override void InitialInterface()
    {
        // характеристики
        string[] arrTitles = new string[] { "Время:  0", "Рекорд:  100", "Очки:  0", "Фигура:  " };
        Color[] arrColors = new Color[] { Color.CYAN, Color.YELLOW, Color.RED, Color.BLUE };

        for (int i = 0; i < arrTitles.Length; i++)
        {
            elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) + 7,
                                                                             (Console.BufferHeight / 7) + (i * 2))));
        }

        // фигура
        IObjFigure objFigure = new ObjFigure(TypeFigure.SQUARE, new Coord((Console.BufferWidth / 2) + 16, (Console.BufferHeight / 7) + 7));
        elements.Add(new FigureElement(objFigure));

        // меню
        arrTitles = new string[] { " Пауза", " Заново", " Назад" };
        arrColors = new Color[] { colorSelect, Color.WHITE, Color.WHITE };

        for (int i = 0; i < arrTitles.Length; i++)
        {
            elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) + 9,
                                                                             (Console.BufferHeight / 7) + 10 + (i * 2))));
        }
    }
}
