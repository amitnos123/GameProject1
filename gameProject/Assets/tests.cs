using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class tests : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LogWriter.log_message(Constants.DEBUG, "Testing Testing 123 Mip");
        SaveControler saveData = new SaveControler(10);
        string fileName = "saveTest1";
        SaveControler.save_json(fileName, saveData);
        SaveControler loadData = SaveControler.load_json(fileName+"2");
        //LogWriter.log_message(Constants.DEBUG, JsonUtility.ToJson(loadData));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void mipTestLogName(string mip, int a)
    {
        LogWriter.log_message(Constants.DEBUG, "Starting " + MethodBase.GetCurrentMethod().Name);
    }
}
