using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class LogWriter
{
    public static void log_message(string logType, string logMessage)
    {
        DateTime current = DateTime.Now;
        string filePath = Constants.LOGS_PATH + "log-"+ current.ToString("yyyy-dd-MM") + ".txt";

        if (!File.Exists(filePath))
            File.Create(filePath).Close();

        using (StreamWriter w = File.AppendText(filePath))
        {
            w.WriteLine("{0} : [{1}] {2}", current.ToString("HH:mm:ss"), logType, logMessage);
        }

        //using (StreamReader r = File.OpenText(filePath))
        //{
        //    DumpLog(r);
        //}
    }

    //public static void DumpLog(StreamReader r)
    //{
    //    string line;
    //    while ((line = r.ReadLine()) != null)
    //    {
    //        Debug.Log(line);
    //    }
    //}
}
