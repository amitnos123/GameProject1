using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.IO;
using System;

public class SaveControler {

    private bool success;
    public bool Success//It will not be printed in the save file
    {
        get { return Success; }
        protected set { Success = value; }
    }

    //All The vars must be public, that way JsonUtility.ToJson will get them all
    public int testInt;

    public SaveControler(){}

    public SaveControler(int testInt)
    {
        this.testInt = testInt;
    }

    public static void save_json(string fileName, SaveControler saveData)
    {
        LogWriter.Start(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().GetParameters());

        if (!Validation(saveData))
            return;

        string filePath = Constants.SAVES_PATH + fileName + "." + Constants.SAVES_FILENAME_EXTENSION;

        if (!File.Exists(filePath))
            File.Create(filePath).Close();

        File.WriteAllText(filePath, JsonUtility.ToJson(saveData));

        LogWriter.Success("Saved file: " + filePath);

        LogWriter.End(MethodBase.GetCurrentMethod().Name);
    }

    //TODO: Test the new Success bool that was added
    public static SaveControler load_json(string fileName)
    {
        LogWriter.Start(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().GetParameters());

        string filePath = Constants.SAVES_PATH + fileName + "." + Constants.SAVES_FILENAME_EXTENSION;

        SaveControler loadData;

        if (!File.Exists(filePath))
        {
            LogWriter.Error("File not found " + fileName + "." + Constants.SAVES_FILENAME_EXTENSION);
            loadData = new SaveControler();
            loadData.Success = false;
            return loadData;
        }

        string str = File.ReadAllText(filePath);

        LogWriter.Success("Loaded file: " + filePath);

        loadData = JsonUtility.FromJson<SaveControler>(str);

        LogWriter.End(MethodBase.GetCurrentMethod().Name, loadData);
        if (Validation(loadData))
        {
            loadData.Success = true;
            LogWriter.End(MethodBase.GetCurrentMethod().Name, loadData);
            return loadData;
        }

        loadData = new SaveControler();
        loadData.Success = false;
        LogWriter.Error("Loaded Data isn't Valid");
        LogWriter.End(MethodBase.GetCurrentMethod().Name, loadData);
        return loadData;
    }

    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }

    protected static bool Validation(SaveControler saveData)
    {
        return true;
    }
}
