using System.Media;


namespace Tetris
{
    public static class GameSound
    {
        public const string DIR = "Sound";  // название папки 
        private static SoundPlayer sound = new SoundPlayer();

        private static bool IsValidFile(string path)
        {
            return File.Exists($"{path}");
        }

        private static void PlaySound(string path)
        {
            if (path == null) throw new Exception("Reference string must be not null!");

            // проверка существует ли файл
            if (!IsValidFile(path)) throw new Exception("No such that file!");

            using (sound)
            {
                // указываем путь к файлу и воспроизводим
                sound.SoundLocation = path;
                sound.Play();
            }
        }

        public static void ChoiceMenu()
        {
            PlaySound(@$"{DIR}\choice.wav");
        }

        public static void ClickBtn()
        {
            PlaySound(@$"{DIR}\click.wav");
        }

        public static void DownFigure()
        {
            PlaySound(@$"{DIR}\down_figure.wav");
        }

        public static void ChangeFigure()
        {
            PlaySound(@$"{DIR}\change_figure.wav");
        }

        public static void DelLine()
        {
            PlaySound(@$"{DIR}\del_line.wav");
        }

        public static void BrokeRecord()
        {
            PlaySound(@$"{DIR}\broke_record.wav");
        }

        public static void Died()
        {
            PlaySound(@$"{DIR}\died.wav");
        }
    }
}
