using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyScriptable enemyScriptable;
    private int health;
    private int damage;
    
    private void Start()
    {
        health = enemyScriptable.health;
        damage = enemyScriptable.damage;
        Debug.Log("can = " + health);
        Debug.Log("hasar =" + damage);
    }
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("can = " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
