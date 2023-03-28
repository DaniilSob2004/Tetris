using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public class Element : IElement
    {
        protected string value;
        protected Color color;
        protected Coord coord;

        public Element(string value, Color color, Coord coord)
        {
            this.value = value;
            SetColor(color);
            this.coord = coord;
        }

        public string GetValue()
        {
            return value;
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public virtual void SetValue(object value) { }

        public virtual void Show() { }

        public virtual void Hide() { }
    }
}
