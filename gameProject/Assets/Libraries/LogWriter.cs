using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class LogWriter
{
    static bool DebugEnabled = true;
    static bool EnterEnabled = true;
    static bool ExitEnabled = true;
    static bool StartEnabled = true;
    static bool EndEnabled = true;
    static bool SuccessEnabled = true;
    static bool ErrorEnabled = true;

    public static void log_message(string logType, string logMessage)
    {
        DateTime current = DateTime.Now;
        string filePath = Constants.LOGS_PATH + "log-"+ current.ToString("yyyy-dd-MM") + "." + Constants.LOGS_FILENAME_EXTENSION;

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

    public static void Enter(string functionName, params object[] list)
    {
        if (EnterEnabled)
        {
            string parStr = "";
            if (list != null && list.Length > 0)
            {
                parStr = " With Params" + ParamsObjectsToString(list);
            }

            log_message(Constants.ENTER, "Endtering " + functionName + parStr);
        }
    }

    public static void Exit(string functionName, params object[] list)
    {
        if (ExitEnabled)
        {
            string parStr = "";
            if (list != null && list.Length > 0)
            {
                parStr = " With Params" + ParamsObjectsToString(list);
            }

            log_message(Constants.EXIST, "Existing " + functionName + parStr);
        }
    }

    public static void Start(string functionName, params object[] list)
    {
        if (StartEnabled)
        {
            string parStr = "";
            if (list != null && list.Length > 0)
            {
                parStr = " With Params" + ParamsObjectsToString(list);
            }

            log_message(Constants.START, "Starting ");
        }
    }

    public static void End(string functionName, params object[] list)
    {
        if (EndEnabled)
        {
            string parStr = "";
            if (list != null && list.Length > 0)
            {
                parStr = " With Params" + ParamsObjectsToString(list);
            }

            log_message(Constants.END, "Ending " + functionName + parStr);
        }
    }

    public static void Success(string logMessage)
    {
        if (SuccessEnabled)
        {
            log_message(Constants.SUCCESS, logMessage);
        }
    }

    public static void Error(string logMessage)
    {
        if (ErrorEnabled)
        {
            log_message(Constants.ERROR, logMessage);
        }
    }

    private static string ParamsObjectsToString(params object[] args)
    {
        string parStr = "[";
        foreach (object arg in args)
        {
            parStr += arg.ToString() + ",";
        }
        parStr = parStr.Remove(parStr.Length - 1, 1) + "]";
        return parStr;
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
