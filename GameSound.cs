using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


public class GameSound
{
    private static SoundPlayer sound = new SoundPlayer();

    public static void ChoiceMenu()
    {
        sound.SoundLocation = @"Sound\choice.wav";
        sound.Play();
    }

    public static void ClickBtn()
    {
        sound.SoundLocation = @"Sound\click.wav";
        sound.Play();
    }

    public static void DownFigure()
    {
        sound.SoundLocation = @"Sound\down_figure.wav";
        sound.Play();
    }

    public static void DelLine()
    {
        sound.SoundLocation = @"Sound\del_line.wav";
        sound.Play();
    }

    public static void BrokeRecord()
    {
        sound.SoundLocation = @"Sound\broke_record.wav";
        sound.Play();
    }

    public static void Died()
    {
        sound.SoundLocation = @"Sound\died.wav";
        sound.Play();
    }
}
