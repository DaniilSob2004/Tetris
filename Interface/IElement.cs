using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public interface IElement
{
    public Color GetColor();
    public void SetColor(Color color);
    public string GetValue();
    public void SetValue(object value);
    public void Show();
    public void Hide();
}
