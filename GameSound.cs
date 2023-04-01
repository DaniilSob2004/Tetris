using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace Tetris
{
    public class GameSound
    {
        public const string DIR = "Sound";
        private static SoundPlayer sound = new SoundPlayer();

        private static void PlaySound(string path)
        {
            if (path == null) throw new Exception("Reference string must be not null!");

            sound.SoundLocation = path;
            sound.Play();
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
