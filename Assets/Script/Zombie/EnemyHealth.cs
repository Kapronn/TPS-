using System;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 100;
    

    private void Start()
    {
       
    }

    public void TakeDamage(int damage)
    {
        if (enemyHealth > 0)
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0) EnemyDeath();
            else Debug.Log("hit");
        }
    }

    void EnemyDeath()
    {
        Destroy(gameObject);
    }
}