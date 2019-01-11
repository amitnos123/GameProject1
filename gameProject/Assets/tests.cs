using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class tests : MonoBehaviour {

    public int publicIntTest;
    public float publicFloatTest = Constants.GRAVITY_MULTIPLIER;

    // Use this for initialization
    void Start () {
        //LogWriter.LogMessage(Constants.DEBUG, "Testing Testing 123 Mip");

        //SaveControler saveData = new SaveControler(10);
        //string fileName = "saveTest1";
        //SaveControler.save_json(fileName, saveData);
        //SaveControler loadData = SaveControler.load_json(fileName+"2");
        //LogWriter.log_message(Constants.DEBUG, JsonUtility.ToJson(loadData));
        mipTeachingCSharp();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void mipTestLogName(string mip, int a)
    {
        LogWriter.Start(MethodBase.GetCurrentMethod().Name);
    }

    private void mipTeachingCSharp() {
        string mip = "hllo warld";
        //int bleee = 7;
        //int reee = 4;
        //int wambo = reee * bleee;
        //LogWriter.Debug(wambo.ToString());

        //for (before start loop; if todo the loop; after round)
        //i++ <==> i = 1 + i
        for (int i = 0; i < mip.Length;i++)
        {
            LogWriter.Debug(mip[i].ToString());
        }
    }
}
