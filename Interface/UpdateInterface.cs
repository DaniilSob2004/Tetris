using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tetris
{
    // интерфейс для обновления интерфейса
    public interface IUpdatableInterface
    {
        public void Update(Game game);
    }

    // реализация интерфейса
    public class UpdatePoints : IUpdatableInterface
    {
        public void Update(Game game)
        {
            // удаляем элемент, обновляем и выводим
            game.UserInterface["Очки"].Hide();
            game.UserInterface["Очки"].SetValue($"Очки:  {game.Points}");
            game.UserInterface["Очки"].Show();
        } 
    }

    public class UpdateRecordPoints : IUpdatableInterface
    {
        public void Update(Game game)
        {
            // удаляем элемент, обновляем и выводим
            game.UserInterface["Рекорд"].Hide();
            game.UserInterface["Рекорд"].SetValue($"Рекорд:  {game.RecordPoints}");
            game.UserInterface["Рекорд"].Show();
        }
    }

    public class UpdateTime : IUpdatableInterface
    {
        public void Update(Game game)
        {
            // добавляем ноль если число меньше 10 (например 8, будет 08)
            string minutes = (game.TimeOnly.Minute < 10) ? "0" + game.TimeOnly.Minute.ToString() : game.TimeOnly.Minute.ToString();
            string seconds = (game.TimeOnly.Second < 10) ? "0" + game.TimeOnly.Second.ToString() : game.TimeOnly.Second.ToString();

            // удаляем элемент, обновляем и выводим
            game.UserInterface.GetElementByValue("Время").Hide();
            game.UserInterface["Время"].SetValue($"Время:  {minutes}:{seconds}");
            game.UserInterface["Время"].Show();
        }
    }

    public class UpdateFigure : IUpdatableInterface
    {
        public void Update(Game game)
        {
            // создаём копию фигуры с другими координатами (которые для интерфейса)
            BaseObjFigure copyFigure = new ObjFigure(game.NextFigure.GetFigure().GetTypeFigure(), new Coord((Console.BufferWidth / 2) + 16, (Console.BufferHeight / 7) + 7));

            // удаляем элемент, обновляем и выводим
            game.UserInterface["Figure"].Hide();
            game.UserInterface["Figure"].SetValue(copyFigure);
            game.UserInterface["Figure"].Show();
        }
    }
}
