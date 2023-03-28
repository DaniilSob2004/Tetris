using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public class FileTxt
{
    private string fileName;
    private static Regex reg = new Regex(@"^[\w\d_\-+ ]+\.txt$");

    private void CheckNull(string value)
    {
        if (value == null)
        {
            throw new Exception("Error, nullReference in variable file value!");
        }
    }

    public FileTxt(string fileName = "")
    {
        FileName = fileName;
    }

    public string FileName
    {
        get { return fileName; }
        set
        {
            Match result = reg.Match(value);

            if (!result.Success) throw new Exception("Invalid filename!");

            fileName = value;
        }
    }

    public string ReadFile()
    {
        string value;

        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            StreamReader sr = new StreamReader(fs);
            value = sr.ReadToEnd();
            sr.Close();
        }

        return value;
    }

    public void WriteFile(string value)
    {
        CheckNull(value);

        using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Write))
        {
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(value);
            sw.Dispose();
        }
    }
}
