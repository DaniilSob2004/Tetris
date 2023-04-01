using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tetris.EnumColl;


namespace Tetris
{
    public interface IElement
    {
        public Color Color { get; set; }
        public string GetValue();
        public void SetValue(object value);
        public void Show();
        public void Hide();
    }
}
