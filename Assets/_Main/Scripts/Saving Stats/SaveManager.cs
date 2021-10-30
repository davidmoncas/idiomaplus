using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This object should be present to allow saving/loading data when opening/closing the game
/// </summary>
public class SaveManager : MonoBehaviour
{
    void Awake()
    {

        DontDestroyOnLoad(this);

        var otherObjects = FindObjectsOfType<SaveManager>();    //make sure that only one object of this type is in the game
        foreach (SaveManager other in otherObjects)
        {
            if (other != this)
            {
                DestroyImmediate(other.gameObject);
            }
        }

        GlobalStats.LoadData();
    }

    private void OnApplicationPause(bool pause)
    {
        print(Application.persistentDataPath);
        if (pause) GlobalStats.SaveData();
    }

    private void OnApplicationQuit()
    {
        print(Application.persistentDataPath);
        GlobalStats.SaveData();
    }


}
