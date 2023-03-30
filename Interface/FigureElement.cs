using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class FigureElement : IElement
    {
        public const string value = "Figure";
        private BaseObjFigure objFigure;

        public FigureElement(BaseObjFigure objFigure)
        {
            SetValue(objFigure);
        }

        public string GetValue()
        {
            return value;
        }

        public void SetValue(object value)
        {
            objFigure = (BaseObjFigure)value;
        }

        public Color GetColor()
        {
            return objFigure.GetFigure().GetColor();
        }

        public void SetColor(Color color) { }

        public void Show()
        {
            objFigure.Show();
        }

        public void Hide()
        {
            objFigure.Hide();
        }
    }
}
