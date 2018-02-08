using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAQSimulator_01
{
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////
    /// 
    /// Created by: Andreas Rege
    /// V1.0
    /// Date: 2018-02-08
    /// 
    /// Purpose: Class for logging data to file
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Log
    {
        /// <summary>
        /// Object variables
        /// </summary>
        string path; // = @"C:\Users\andreas\Documents\_Skole\Visual Studio code\LogFiles\log111.txt";
        bool fileExist;

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Constructor that defines the path to the log file 
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public Log(string _path)
        {
            path = _path;
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method that checks if the defined log file exists
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public bool checkFileExist()
        {
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

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// 
        /// Created by: Andreas Rege
        /// V1.0
        /// Date: 2018-02-08
        /// 
        /// Purpose: Function/Method that appends new log data to log file
        /// 
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public void appendToFile(string _text,bool _startOfLine=false, bool _endOfLine=false)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                //Checks if it is the start of line
                if (!_startOfLine)
                {
                    sw.Write(',');
                }

                //Writes the new/incoming text to log file
                sw.Write(_text);

                //Checks if it is the end of line
                if (_endOfLine)
                {
                    sw.WriteLine();
                }

            }
        }
        
    }
}
