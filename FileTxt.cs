using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Tetris
{
    public class FileTxt
    {
        public const string DIR = "Files";
        private string fileName;

        private bool CheckNull(string value)
        {
            return value != null;
        }

        private bool IsValidFile(string fileName)
        {
            return CheckNull(fileName) && (File.Exists($@"{DIR}\{fileName}"));
        }

        public FileTxt(string fileName)
        {
            FileName = fileName;
        }

        public string FileName
        {
            get { return fileName; }
            set
            {
                // проверка на null
                if (!CheckNull(value)) throw new Exception("Error, nullReference in variable file value!");

                // проверка существует ли файл
                if (!IsValidFile(value)) throw new Exception("No such file!");

                fileName = value;
            }
        }

        public string ReadFile()
        {
            string value;

            using (var fs = new FileStream($@"{DIR}\{fileName}", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                value = sr.ReadToEnd();
                sr.Close();
            }

            return value;
        }

        public void WriteFile(string value)
        {
            // проверка на null
            if (!CheckNull(value)) throw new Exception("Error, nullReference in variable file value!");

            using (var fs = new FileStream($@"{DIR}\{fileName}", FileMode.Open, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(value);
                sw.Dispose();
            }
        }
    }
}
