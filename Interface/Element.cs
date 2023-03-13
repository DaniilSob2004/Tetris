using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class Element : IElement
{
    protected string title;
    protected Color color;
    protected Coord coord;

    public Element(string title, Color color, Coord coord)
    {
        this.title = title;
        this.color = color;
        this.coord = coord;
    }

    public string GetTitle()
    {
        return title;
    }

    public Color GetColor()
    {
        return color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }

    public virtual void Show() {}

    public virtual void Hide() {}
}
