using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Calls the attack function of the enemy with the animation of the attack (to make it more precise)
/// </summary>
public class EnemyAttackAnimation : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    public void Attack() {
        enemy.Attack();
    }


}
