using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnumColl;


public class BaseInterface : Interface
{
    public const Color colorSelect = Color.GREEN;
    protected List<IElement> elements;

    public BaseInterface()
    {
        elements = new List<IElement>();
    }

    public IElement GetChoiceElem()
    {
        // возвращает выбранный элемент по указанному цвету, иначе исключение
        foreach (IElement elem in elements)
        {
            if (elem.GetColor() == colorSelect)
            {
                return elem;
            }
        }
        throw new Exception("No element selected!");
    }

    public IElement GetElementByValue(string value)
    {
        foreach (IElement elem in elements)
        {
            //if (elem.GetValue() == value)
            if (elem.GetValue().Contains(value))
            {
                return elem;
            }
        }
        throw new Exception("No element by this value!");
    }

    // устанавливает следующую выбранную пользователем метку
    public void SetChoiceNextElem()
    {
        // список элементов которые относятся к меню пользователя
        List<IElement> elementsMenu = new List<IElement>();

        foreach (IElement elem in elements)
        {
            // если первый символ названия элемента это (пробел), то добавляем в список
            if (elem.GetValue()[0] == ' ')
            {
                elementsMenu.Add(elem);
            }
        }

        for (int i = 0; i < elementsMenu.Count; i++)
        {
            // находим элемент который был выбран
            if (elementsMenu[i].GetColor() == colorSelect)
            {
                elementsMenu[i].SetColor(Color.WHITE);

                // если это последний элемент, то делаем выбранный элемент первым 
                if (i == elementsMenu.Count - 1)
                {
                    elementsMenu[0].SetColor(colorSelect);
                }
                // еиначе, делаем выбранный элемент следующий
                else
                {
                    elementsMenu[i + 1].SetColor(colorSelect);
                }
                Show();  // показываем изменения
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