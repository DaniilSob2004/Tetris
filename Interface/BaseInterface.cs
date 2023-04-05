using static Tetris.EnumColl;


namespace Tetris
{
    // абстрактный класс, для интерфейса меню программы
    public abstract class BaseInterface
    {
        public const Color colorSelect = Color.GREEN;
        protected List<IElement> elements;  // список элемнтов интерфейса

        public BaseInterface()
        {
            elements = new List<IElement>();
        }

        public IElement GetChoiceElem()
        {
            // возвращает выбранный элемент по указанному цвету, иначе исключение
            foreach (IElement elem in elements)
            {
                if (elem.GetValue()[0] == ' ' && elem.Color == colorSelect)
                {
                    return elem;
                }
            }
            throw new Exception("No element selected!");
        }

        public IElement GetElementByValue(string value)
        {
            // возвращает элемент по значению 'value'
            foreach (IElement elem in elements)
            {
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
                if (elementsMenu[i].Color == colorSelect)
                {
                    elementsMenu[i].Color = Color.WHITE;

                    // если это последний элемент, то делаем выбранный элемент первым 
                    if (i == elementsMenu.Count - 1)
                    {
                        elementsMenu[0].Color = colorSelect;
                    }
                    // еиначе, делаем выбранный элемент следующий
                    else
                    {
                        elementsMenu[i + 1].Color = colorSelect;
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

        // для доступа к списку элементов через квадратные скобки
        public IElement this[string value]
        {
            get { return GetElementByValue(value); }
        }

        public abstract void InitialInterface();
    }
}
