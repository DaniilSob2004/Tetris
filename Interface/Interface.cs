using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface Interface
{
    public IElement GetChoiceElem();
    public IElement GetElementByValue(string value);
    public void SetChoiceNextElem();
    public void InitialInterface();
    public void Show();
    public IElement this[string value] { get; }
}
