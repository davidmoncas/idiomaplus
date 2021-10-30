using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


/// <summary>
/// Static class used to save and load the data to a JSON file
/// </summary>
public static class GlobalStats
{

    public static int numberOfMatches, numberOfVictories, numberOfDefeats;
    static string fileName = "/data.json";

    public static void SaveData() {

        StatsData data = new StatsData();
        data.matches = numberOfMatches;
        data.victories = numberOfVictories;
        data.defeats = numberOfDefeats;

        string DataString = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + fileName, DataString);
    }

    public static void LoadData() {

        if (System.IO.File.Exists(Application.persistentDataPath + fileName))
        {
            string loadedData = File.ReadAllText(Application.persistentDataPath + fileName);
            StatsData data = JsonUtility.FromJson<StatsData>(loadedData);

            numberOfMatches = data.matches;
            numberOfVictories = data.victories;
            numberOfDefeats = data.defeats;
        }

        else {
            numberOfMatches = 0;
            numberOfVictories = 0;
            numberOfDefeats = 0;
        }

    }


    [Serializable]
    public struct StatsData {
        public int matches, victories, defeats;
    }

}
