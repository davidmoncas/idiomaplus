using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// show the stats in the main menu (victories, defeats, matches)
/// </summary>
public class ShowStats : MonoBehaviour
{
    [SerializeField] Text matches, victories, defeats;

    void Start()
    {
        matches.text = "Number Of Matches: " + GlobalStats.numberOfMatches;
        victories.text = "Number Of Victories: " + GlobalStats.numberOfVictories;
        defeats.text = "Number Of Defeats: " + GlobalStats.numberOfDefeats;
    }
}


