using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAQSimulator_01
{
    class Log
    {
        string path; // = @"C:\Users\andreas\Documents\_Skole\Visual Studio code\LogFiles\log111.txt";
        bool fileExist;
        public Log(string _path)
        {
            path = _path;
        }

        public bool checkFileExist()
        {
            //path = _path;
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("This is the header of the file");
                }
            }
            else { fileExist = true; }
            return fileExist;
        }

        public void appendToFile(string _text)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(_text);
            }
        }
        
    }
}
