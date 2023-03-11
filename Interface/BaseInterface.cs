using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


//namespace Tetris.Interface
//{
public class BaseInterface : Interface
{
    protected List<IElement> elements;

    public BaseInterface()
    {
        elements = new List<IElement>();
    }

    public IElement GetChoiceElem()
    {
        foreach (IElement elem in elements)
        {
            if (elem.GetColor() == Color.GREEN)
            {
                return elem;
            }
        }
        return null;
    }

    public void SetChoiceNextElem()
    {
        List<IElement> elementsMenu = new List<IElement>();
        foreach (IElement elem in elements)
        {
            // если первый символ названия элемента это число, то добавляем в список
            if (char.IsDigit(elem.GetTitle()[0]))
            {
                elementsMenu.Add(elem);
            }
        }

        for (int i = 0; i < elementsMenu.Count; i++)
        {
            if (elementsMenu[i].GetColor() == Color.GREEN)
            {
                elementsMenu[i].SetColor(Color.WHITE);
                if (i == elementsMenu.Count - 1)
                {
                    elementsMenu[0].SetColor(Color.GREEN);
                }
                else
                {
                    elementsMenu[i + 1].SetColor(Color.GREEN);
                }
                Show();
                break;
            }
        }
    }

    public void Show()
    {
        foreach (IElement elem in elements)
        {
            elem.Show();
        }
    }

    public virtual void InitialInterface() { }
}
//}
