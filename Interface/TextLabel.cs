﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class TextLabel : Element
{
    public TextLabel(string title, Color color, Coord coord) :
        base(title, color, coord) { }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public override void Show()
    {
        // устанавливаем курсор, меняем цвет и отображаем метку
        Console.SetCursorPosition(coord.x, coord.y);
        SetForegroundColor(color);
        Console.WriteLine(title);
        SetForegroundColor(Color.WHITE);
    }

    public override void Hide()
    {
        // удаляем текстовую метку
        for (int i = 0; i < title.Length; i++)
        {
            Console.SetCursorPosition(coord.x + i, coord.y);
            Console.WriteLine(" ");
        }
    }
}
