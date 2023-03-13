using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public interface IElement
{
    public string GetTitle();
    public Color GetColor();
    public void SetColor(Color color);
    public void Show();
    public void Hide();
}
