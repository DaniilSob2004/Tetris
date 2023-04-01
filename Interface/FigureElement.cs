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

        public Color Color
        {
            get { return objFigure.ObjFigure.Color; }
            set { }
        }

        public string GetValue()
        {
            return value;
        }

        public void SetValue(object value)
        {
            BaseObjFigure obj = value as BaseObjFigure;
            if (obj == null) throw new Exception("Reference object must be BaseObjFigure!");

            objFigure = obj;
        }

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
