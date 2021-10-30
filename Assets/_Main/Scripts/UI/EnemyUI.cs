using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Show the healthbar of the enemy
/// </summary>
public class EnemyUI : MonoBehaviour
{

    [SerializeField] Image healthBar;

    public void SetHealth(int health, int maxHealth) {
        healthBar.fillAmount = (float)health / (float)maxHealth;
    
    }


}
