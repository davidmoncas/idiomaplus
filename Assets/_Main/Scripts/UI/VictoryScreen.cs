using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Triggers the victory/defeat screen and also counts the number of matches, defeats and victories
/// </summary>
public class VictoryScreen : MonoBehaviour
{

    [SerializeField] GameObject defeatVictoryWindow;
    [SerializeField] Text windowText;


    private void Start()
    {
        GlobalStats.numberOfMatches++;
        GlobalStats.SaveData();
    }

    public void Victory() {
        windowText.text = "Victory";
        defeatVictoryWindow.SetActive(true);
        GlobalStats.numberOfVictories++;
        GlobalStats.SaveData();

    } 
    
    public void Defeat() {
        windowText.text = "Defeat";
        defeatVictoryWindow.SetActive(true);
        GlobalStats.numberOfDefeats++;
        GlobalStats.SaveData();
    }

}
