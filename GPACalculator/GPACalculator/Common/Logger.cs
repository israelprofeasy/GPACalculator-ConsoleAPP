using Microsoft.VisualBasic;
using System;
using System.IO;

namespace Common
{
    public class Logger : Ilogger
    {
        public void Log(string items)
        {
            items = DateTime.Now.ToShortDateString() + " " + DateAndTime.Now.ToLongTimeString() + ": " + items;
            string docPath = Directory.GetCurrentDirectory();
            docPath = Path.Combine(docPath, "ErrorLogs");
            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Log.txt"), append: true))
            {
                outputFile.WriteLine(items);
            }
        }
    }
}
