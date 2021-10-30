using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectable
{
    [SerializeField] int healthAmount;

    public override void OnConsume() {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        stats.AddHealth(healthAmount);
    }

}
