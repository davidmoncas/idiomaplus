using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Trigger attached to the front of the enemy that tells if the enemy is hitting the player
/// </summary>
public class EnemyReach : MonoBehaviour
{

    public bool touchingPlayer = false;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
        if (stats != null) {
            touchingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
        if (stats != null)
        {
            touchingPlayer = false;
        }
    }
}
