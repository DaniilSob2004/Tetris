using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class FigureElement : IElement
{
    public const string value = "Figure";
    private IObjFigure objFigure;

    public FigureElement(IObjFigure objFigure)
    {
        SetValue(objFigure);
    }

    public string GetValue()
    {
        return value;
    }

    public void SetValue(object value)
    {
        objFigure = (IObjFigure)value;
    }

    public Color GetColor()
    {
        return objFigure.GetFigure().GetColor();
    }

    public void SetColor(Color color) {}

    public void Show()
    {
        objFigure.Show();
    }

    public void Hide()
    {
        objFigure.Hide();
    }
}
