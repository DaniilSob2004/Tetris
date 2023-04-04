﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class Game
    {
        public const int WIDTH = 48;
        public const int HEIGHT = 21;
        public const int POINTS_LINE = 10;
        public const int POINTS = 5;
        public const int MIN_SPEED = 300;
        public const int MAX_SPEED = 100;
        public const int SPEED_STEP = 50;
        public const string fileNameRecord = "record.txt";

        private readonly int RECORD_POINTS;

        private BaseInterface userInterface;
        private BaseObjFigure? figure;
        private BaseObjFigure? nextFigure;
        private GameField? gameField;
        private FileTxt fileRecord;

        private bool isPlay;
        private bool brokeRecord;
        private int recordPoints;
        private int points;
        private int sleep;
        private int speed;
        private int nLine;
        private TimeOnly timeOnly;
        private ConsoleKeyInfo k;


        public Game()
        {
            try
            {
                // создаём объект для работы с файлом, сохраняем значение из файла в константу readonly,
                // и присваиваем это значение переменной для рекорда очков
                fileRecord = new FileTxt(fileNameRecord);
                RECORD_POINTS = int.Parse(fileRecord.ReadFile());
                recordPoints = RECORD_POINTS;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // инициализируем прототипы фигур
            PrototypeFigure.InitPrototype();

            SetConsole();
            StartSettings();
        }


        public BaseInterface UserInterface { get { return userInterface; } }
        public BaseObjFigure? NextFigure { get { return nextFigure; } }
        public TimeOnly TimeOnly { get { return timeOnly; } }
        public int Points { get { return points; } }
        public int RecordPoints { get { return recordPoints; } }
        public int POINTS_RECORD { get { return RECORD_POINTS; } }


        public void StartGame()
        {
            while (true)
            {
                sleep = 0;

                if (Console.KeyAvailable == true)
                    {
                        k = Console.ReadKey(true);
                        Handler();
                    }
                else
                {
                    if (isPlay && figure != null && gameField != null)
                    {
                        try
                        {
                            figure.Move(Direction.DOWN, gameField);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        sleep = speed;
                    }
                }

                if (isPlay && figure != null && gameField != null && nextFigure != null)
                {
                    figure.Show();

                    Thread.Sleep(sleep);

                    try
                    {
                        if (CheckCollision.CheckFinalPoint(figure, gameField))
                            {
                                GameSound.DownFigure();

                                gameField.AddFigure(figure);
                                figure = nextFigure;
                                GenFigure();
                                UpdateInterface(new UpdateFigure());

                                points += POINTS;
                                UpdateInterface(new UpdatePoints());
                                CheckRecordPoints();

                                gameField.CleanLine(ref nLine);
                                if (nLine != 0)
                                {
                                    points += nLine * POINTS_LINE;
                                    UpdateInterface(new UpdatePoints());
                                    CheckRecordPoints();

                                    nLine = 0;
                                    speed -= SPEED_STEP;
                                }
                            }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    timeOnly = timeOnly.Add(TimeSpan.FromSeconds((float)sleep / 1000));

                    try
                    {
                        UpdateInterface(new UpdateTime());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        if (CheckCollision.CheckGameOver(figure, gameField))
                        {
                            GameOver();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void GameOver()
        {
            isPlay = false;
            Thread.Sleep(1500);
            Console.Clear();

            string lostMess = "ВЫ ПРОИГРАЛИ!";

            // звук смерти
            GameSound.Died();

            // анимация проигрыша
            for (int i = 0; i < 3; i++)
            {
                // выводим
                Console.SetCursorPosition(Console.BufferWidth / 2 - (lostMess.Length / 2), Console.WindowHeight / 2);
                SetForegroundColor(Color.RED);
                Console.WriteLine("ВЫ ПРОИГРАЛИ!");
                SetForegroundColor(Color.WHITE);
                Thread.Sleep(270);

                // стираем
                for (int j = 0; j < lostMess.Length; j++)
                {
                    Console.SetCursorPosition((Console.BufferWidth / 2 - (lostMess.Length / 2)) + j, Console.WindowHeight / 2);
                    Console.WriteLine(" ");
                    Thread.Sleep(12);
                }
                Thread.Sleep(270);
            }

            StartSettings();
        }

        private void Handler()
        {
            // обработчик для нажатия кнопок, вызываются определённые методы объектов

            // пользователь выбирает следующеее меню
            if (k.Key == ConsoleKey.DownArrow)
            {
                userInterface.SetChoiceNextElem();
                GameSound.ChoiceMenu();
            }

            // пользователь нажал 'enter', т.е. выбрал какое-то меню
            else if (k.Key == ConsoleKey.Enter)
                {
                    IElement elem = userInterface.GetChoiceElem();

                    if (elem.GetValue().StartsWith(" Начать игру"))
                    {
                        StartGameSettings();
                    }

                    else if (elem.GetValue().StartsWith(" Об авторе"))
                    {
                        OpenBrowser.OpenGitHub();
                    }

                    else if (elem.GetValue().StartsWith(" Выйти"))
                    {
                        Console.Clear();
                        SaveRecord();  // запись в файл рекорда
                        Environment.Exit(0);
                    }


                    else if (elem.GetValue().StartsWith(" Назад"))
                    {
                        StartSettings();
                    }

                    else if (elem.GetValue().StartsWith(" Заново"))
                    {
                        StartGameSettings();
                    }

                    else if (elem.GetValue().StartsWith(" Пауза"))
                    {
                        try
                        {
                            UpdateInterface(new Pause());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        // останавливаем игру
                        isPlay = false;
                    }

                    else if (elem.GetValue().Contains("Продолжить"))
                    {
                        try
                        {
                            UpdateInterface(new Continue());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        // продолжаем игру
                        isPlay = true;
                    }

                    GameSound.ClickBtn();
                }

            // игровые кнопки
            if (isPlay && figure != null && gameField != null)
            {
                if (k.Key == ConsoleKey.LeftArrow)
                {
                    try
                    {
                        figure.Move(Direction.LEFT, gameField);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sleep = (int)((float)speed / 4.25);
                }

                else if (k.Key == ConsoleKey.RightArrow)
                {
                    try
                    {
                        figure.Move(Direction.RIGHT, gameField);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    sleep = (int)((float)speed / 4.25);
                }

                else if (k.Key == ConsoleKey.UpArrow)
                {
                    figure.Turn();
                    GameSound.ChangeFigure();
                }

                else if (k.Key == ConsoleKey.Spacebar)
                {
                    try
                    {
                        figure.FastDown(gameField);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


        private void CheckRecordPoints()
        {
            if (points > recordPoints)
            {
                if (!brokeRecord)
                {
                    brokeRecord = true;
                    GameSound.BrokeRecord();
                }
                recordPoints = points;

                try
                {
                    UpdateInterface(new UpdateRecordPoints());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GenFigure()
        {
            // генерим на рандоме фигуру
            Random r = new Random();
            Coord coord = new Coord((GameField.WIDTH_F / 2) - 1, 0);

            switch (r.Next(0, PrototypeFigure.N_TYPE_FIGURES))
            {
                case 1:
                    nextFigure = new ObjFigure(TypeFigure.SQUARE, coord);
                    break;

                case 2:
                    nextFigure = new ObjFigure(TypeFigure.L1, coord);
                    break;

                case 3:
                    nextFigure = new ObjFigure(TypeFigure.INVERTED_L1, coord);
                    break;

                case 4:
                    nextFigure = new ObjFigure(TypeFigure.Z1, coord);
                    break;

                case 5:
                    nextFigure = new ObjFigure(TypeFigure.INVERTED_Z1, coord);
                    break;

                case 6:
                    nextFigure = new ObjFigure(TypeFigure.T1, coord);
                    break;

                default:
                    nextFigure = new ObjFigure(TypeFigure.LINE1, coord);
                    break;
            }
        }

        private void UpdateInterface(IUpdatableInterface update)
        {
            if (update == null) throw new Exception("Reference IUpdatableInterface must be not null!");

            update.Update(this);
        }

        private void ShowInterface()
        {
            userInterface.Show();
        }


        private void StartGameSettings()
        {
            Console.Clear();

            // игра начинается (начальные значения)
            isPlay = true;
            brokeRecord = false;
            speed = MIN_SPEED;
            sleep = speed;
            points = 0;
            timeOnly = new TimeOnly();

            // создаём игровое поле и выводим
            gameField = new GameField();
            gameField.Show();

            // создаём игровой интерейс и выводим
            userInterface = new GameInterface();
            userInterface.InitialInterface();
            ShowInterface();

            try
            {
                // обновляем рекорд очков
                UpdateInterface(new UpdateRecordPoints());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            // генерим фигуру, сохраняем, снова генерим и выводим какая фигура будет следующей
            GenFigure();
            figure = nextFigure;
            GenFigure();

            try
            {
                // обновляем фигуру
                UpdateInterface(new UpdateFigure());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StartSettings()
        {
            Console.Clear();

            figure = null;
            nextFigure = null;
            gameField = null;

            // игра ещё не началась
            isPlay = false;

            // создали основное меню
            userInterface = new MainInterface();
            userInterface.InitialInterface();

            // вывод интерфейса
            ShowInterface();
        }

        private void SetConsole()
        {
            Console.SetWindowSize(WIDTH, HEIGHT);
            Console.SetBufferSize(WIDTH, HEIGHT);
            Console.Title = "Tetris";
            Console.CursorVisible = false;
        }

        private void SaveRecord()
        {
            // если рекорд больше, чем записано в файле, то происходит запись в файл(сохранение) рекорда
            if (recordPoints > RECORD_POINTS)
            {
                try
                {
                    fileRecord.WriteFile(recordPoints.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}