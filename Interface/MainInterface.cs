using static Tetris.EnumColl;


namespace Tetris
{
    // класс, для интерфейса основного меню программы
    public class MainInterface : BaseInterface
    {
        private void ShowLogo()
        {
            string[] logo = @"
███████████████████████████████████
█─▄─▄─█▄─▄▄─█─▄─▄─█▄─▄▄▀█▄─▄█─▄▄▄▄█
███─████─▄█▀███─████─▄─▄██─██▄▄▄▄─█
▀▀▄▄▄▀▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▄▄▀".Split('\n');

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < logo.Length; i++)
            {
                Console.SetCursorPosition((Console.BufferWidth / 7) + 1, i);
                Console.WriteLine(logo[i]);
            }
        }

        public override void InitialInterface()
        {
            // создаём основной интерфейс программы

            ShowLogo();  // вывод лого ТЕТРИС

            string[] arrTitles = new string[] { "МЕНЮ", " Начать игру", " Выйти из игры", " Об авторе" };
            ConsoleColor[] arrColors = new ConsoleColor[] { ConsoleColor.Cyan, colorSelect, ConsoleColor.White, ConsoleColor.White };

            for (int i = 0; i < arrTitles.Length; i++)
            {
                elements.Add(new TextLabel(arrTitles[i], arrColors[i], new Coord((Console.BufferWidth / 2) - (arrTitles[i].Length / 2),
                                                                                 (Console.BufferHeight / 3) + i * 3)));
            }
        }
    }
}
