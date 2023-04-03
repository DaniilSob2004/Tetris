using static Tetris.EnumColl;


namespace Tetris
{
    // класс для создания объекта фигуры в интерфейсе программы
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
            // проверяем тип ссылки переданной в параметре
            BaseObjFigure? obj = value as BaseObjFigure;
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
