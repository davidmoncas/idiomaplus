using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls and stores the stats of the player (health, attack, defense)
/// </summary>
public class PlayerStats : MonoBehaviour
{
    public int maxHealth;

    public int health;
    public int attackDamage;
    public int defense;

    [SerializeField] UIManager uIManager;


    private void Start()
    {
        uIManager.SetHealthBar(health, maxHealth);
    }

    public void AddHealth(int amount) {

        if (health + amount < 0) FindObjectOfType<VictoryScreen>().Defeat();

        health = Mathf.Clamp(health + amount, 0, maxHealth);
        uIManager.SetHealthBar(health, maxHealth);
    }

    public void MakeAttackStronger(float multiplier, int duration) {
        StartCoroutine(setAttackDamageOverTime(multiplier, duration));    
    }
    IEnumerator setAttackDamageOverTime(float multiplier, int duration) {
        int initialAttackDamage = attackDamage;
        attackDamage =(int) multiplier * attackDamage;
        yield return new WaitForSeconds(duration);
        attackDamage = initialAttackDamage;
    }

}


