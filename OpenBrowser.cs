using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


public class OpenBrowser
{
    public static void OpenGitHub()
    {
        // открываем ссылку на мой гитхаб в браузере 
        string url = "https://github.com/DaniilSob2004";
        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
    }
}
