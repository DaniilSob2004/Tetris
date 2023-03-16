﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public interface IObjFigure
{
    public IFigure GetFigure();
    public Coord GetCoord();
    public void Move(Direction direction, GameField gameField);
    public void Show();
    public void Hide();
    public void Turn();
}