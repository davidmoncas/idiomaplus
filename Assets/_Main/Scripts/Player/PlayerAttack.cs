using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the act of attacking of the player. There's a cooldown of 2 seconds.
/// </summary>
public class PlayerAttack : MonoBehaviour
{

    bool canAttack = true;
    float attackCoolDown;

    [SerializeField] Animator anim;
    [SerializeField] SearchForItems enemyDetector;
    [SerializeField] PlayerStats stats;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            anim.ResetTrigger("Attack");

            if (canAttack) { 
                anim.SetTrigger("Attack");
                if (enemyDetector.nearEnemy != null) enemyDetector.nearEnemy.GetDamage(stats.attackDamage);
            }
            canAttack = false;
        }

        if (!canAttack) attackCoolDown += Time.deltaTime;
        if (attackCoolDown > 2) {
            attackCoolDown = 0;
            canAttack = true;
        }

    }
}
