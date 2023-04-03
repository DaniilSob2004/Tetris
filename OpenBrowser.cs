using System.Diagnostics;


namespace Tetris
{
    public class OpenBrowser
    {
        public const string url = "https://github.com/DaniilSob2004";

        public static void OpenGitHub()
        {
            // открываем ссылку на мой гитхаб в браузере 
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
        }
    }
}
