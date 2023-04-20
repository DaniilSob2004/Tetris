namespace Tetris
{
    // Класс движок, для вызова события при нажатии клавиши
    public class GameEngine
    {
        public delegate void DelKeyPressed(ConsoleKeyInfo keyInfo);
        public event DelKeyPressed KeyPressed;

        // добавляем обработчик к событию
        public GameEngine(DelKeyPressed delKeyPressed) => KeyPressed += delKeyPressed;

        public void Start()
        {
            while (true)
            {
                // если былы нажата клавиша и какой то обработчик есть
                if (Console.KeyAvailable && KeyPressed != null)
                {
                    ConsoleKeyInfo k = Console.ReadKey(true);
                    KeyPressed(k);
                }
                Thread.Sleep(10);
            }
        }
    }
}
