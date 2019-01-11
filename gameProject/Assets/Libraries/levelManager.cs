using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public static void moveObject(GameObject gO, Scene s)
    {//TODO: Test public static void moveObject(GameObject gO, Scene s)
        LogWriter.Debug("Object was moved to Scene "+s.name);
        SceneManager.MoveGameObjectToScene(gO, s);
    }

    public static string[] getLoadedScenesName()
    {//TODO: Test public static string[] getLoadedScenesName()
        int numberOfScenes = SceneManager.sceneCount;
        string[] names = new string[numberOfScenes];

        for (int i = 0; i < numberOfScenes; i++)
        {
            names[numberOfScenes] = SceneManager.GetSceneAt(i).name;
        }

        return names;
    }
}
