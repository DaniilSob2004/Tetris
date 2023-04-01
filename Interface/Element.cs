using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public abstract class Element : IElement
    {
        protected string value;
        protected Coord coord;

        public Element(string value, Color color, Coord coord)
        {
            SetValue(value);
            Color = color;
            this.coord = coord;
        }

        public Color Color { get; set; }

        public string GetValue()
        {
            return value;
        }

        public abstract void SetValue(object value);
        public abstract void Show();
        public abstract void Hide();
    }
}
