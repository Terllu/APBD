using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cw2.Models
{
    class Log
    {
        public static void LogIt(string message)
        {
            string filePath = @"Data\log.txt";
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
       
    }
}