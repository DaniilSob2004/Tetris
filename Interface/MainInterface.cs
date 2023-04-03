using static Tetris.EnumColl;


namespace Tetris
{
    // класс, для интерфейса основного меню программы
    public class MainInterface : BaseInterface
    {
        public override void InitialInterface()
        {
            // создаём основной интерфейс программы

            string[] arrTitles = new string[] { "МЕНЮ", " Начать игру", " Выйти из игры", " Об авторе" };
            Color[] arrColors = new Color[] { Color.CYAN, colorSelect, Color.WHITE, Color.WHITE };

            for (int i = 0; i < arrTitles.Length; i++)
            {
                elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) - (arrTitles[i].Length / 2),
                                                                                 (Console.BufferHeight / 3 - 2) + i * 3)));
            }
        }
    }
}
