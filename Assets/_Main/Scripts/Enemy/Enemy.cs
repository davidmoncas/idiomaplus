using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement and stats of the Enemy
/// </summary>
public class Enemy : MonoBehaviour
{

    public int maxHealth, health;
    public int attackDamage, defense;

    [SerializeField] float speed;

    Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] Transform Player;
    [SerializeField] EnemyUI ui;

    Vector3 initialPos;
    [SerializeField] float radiusOfSight;
    public enemyState state = enemyState.guarding;

    [SerializeField] EnemyReach reach;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayerFromStart = Vector3.Distance(Player.position, initialPos); //distance from a fixed point
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayerFromStart < radiusOfSight & state == enemyState.guarding)
        { //it's guarding and the player is too close to the range
            state = enemyState.chasing;
            anim.SetInteger("State", 1);
        }

        if (distanceToPlayer < 2 && state == enemyState.chasing)
        {      // it's chasing the player and can attack
            state = enemyState.attacking;
            anim.SetInteger("State", 2);
        }

        if (distanceToPlayer > 3 && state == enemyState.attacking)
        {    // it's attacking the player but the player is far
            state = enemyState.chasing;
            anim.SetInteger("State", 1);
        }

        if (distanceToPlayerFromStart > radiusOfSight && (state == enemyState.attacking || state == enemyState.chasing))    //return to base
        {
            state = enemyState.returning;
            anim.SetInteger("State", 1);
        }

        if (Vector3.Distance(initialPos , transform.position) < 1 && (state == enemyState.returning))   //stay Idle in the base
        {
            state = enemyState.guarding;
            anim.SetInteger("State", 0);
        }


        Move(Time.deltaTime);
    }

    void Move(float deltaTime)
    {
        Vector3 direction;
        switch (state)
        {
            case enemyState.chasing:
                direction = (Player.position - transform.position).normalized;
                direction.y = 0;
                rb.velocity = (direction * speed);
                transform.forward = direction;
                break;

            case enemyState.returning:
                direction = (initialPos - transform.position).normalized;
                direction.y = 0;
                rb.velocity = (direction * speed);
                transform.forward = direction;

                break;
        }
    

    }

    public void GetDamage(int amount) {
        health -= amount;
        ui.SetHealth(health, maxHealth);
        if (health < 0) Die();
    }

    void Die() {
        FindObjectOfType<VictoryScreen>().Victory();
        Destroy(this.gameObject);

    }

public void Attack()
{
    if (reach.touchingPlayer)
    {
        PlayerStats stats = Player.GetComponent<PlayerStats>();

        int damage = attackDamage - stats.defense;
        damage = Mathf.Clamp(damage, 0, 1000);

        stats.AddHealth(-damage);

    }
}

public enum enemyState { guarding, chasing, attacking, returning }
}
