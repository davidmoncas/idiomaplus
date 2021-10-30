using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPotion : Collectable
{
    [SerializeField] int attackMultiplier;
    [SerializeField] int duration;

    public override void OnConsume() {
        PlayerStats stats = FindObjectOfType<PlayerStats>();
        stats.MakeAttackStronger(attackMultiplier , duration);
    }

}
