namespace Tetris
{
    // интерфейс для обновления интерфейса
    public interface IUpdatableInterface
    {
        public void Update(Game game);
    }

    // реализации интерфейса
    public class UpdatePoints : IUpdatableInterface
    {
        // обновление очков
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            try
            {
                // удаляем элемент, обновляем и выводим
                game.UserInterface["Очки"].Hide();
                game.UserInterface["Очки"].SetValue($"Очки:  {game.Points}");
                game.UserInterface["Очки"].Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }

    public class UpdateRecordPoints : IUpdatableInterface
    {
        // обновление рекорда очков
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            try
            {
                // удаляем элемент, обновляем и выводим
                game.UserInterface["Рекорд"].Hide();
                game.UserInterface["Рекорд"].SetValue($"Рекорд:  {game.RecordPoints}");
                game.UserInterface["Рекорд"].Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class UpdateTime : IUpdatableInterface
    {
        // обновление времени
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            // добавляем ноль если число меньше 10 (например 8, будет 08)
            string minutes = (game.TimeOnly.Minute < 10) ? "0" + game.TimeOnly.Minute.ToString() : game.TimeOnly.Minute.ToString();
            string seconds = (game.TimeOnly.Second < 10) ? "0" + game.TimeOnly.Second.ToString() : game.TimeOnly.Second.ToString();

            try
            {
                // удаляем элемент, обновляем и выводим
                game.UserInterface.GetElementByValue("Время").Hide();
                game.UserInterface["Время"].SetValue($"Время:  {minutes}:{seconds}");
                game.UserInterface["Время"].Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class UpdateFigure : IUpdatableInterface
    {
        // обновление фигуры
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            if (game.NextFigure != null)
            {
                // создаём копию фигуры с другими координатами (которые для интерфейса)
                BaseObjFigure copyFigure = new ObjFigure(game.NextFigure.ObjFigure.Type, new Coord((Console.BufferWidth / 2) + 16, (Console.BufferHeight / 7) + 7));

                try
                {
                    // удаляем элемент, обновляем и выводим
                    game.UserInterface["Figure"].Hide();
                    game.UserInterface["Figure"].SetValue(copyFigure);
                    game.UserInterface["Figure"].Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

    public class Pause : IUpdatableInterface
    {
        // обновление при паузе игры
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            try
            {
                // меняем текст
                game.UserInterface["Пауза"].Hide();
                game.UserInterface["Пауза"].SetValue(" Продолжить");
                game.UserInterface["Продолжить"].Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Continue : IUpdatableInterface
    {
        // обновление при продолжении игры
        public void Update(Game game)
        {
            if (game == null) throw new Exception("Reference Game must be not null!");

            try
            {
                // меняем текст
                game.UserInterface["Продолжить"].Hide();
                game.UserInterface["Продолжить"].SetValue(" Пауза");
                game.UserInterface["Пауза"].Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
