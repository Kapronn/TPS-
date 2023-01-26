using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 100;
    private RagdollManager _ragdollManager;

    private void Start()
    {
        _ragdollManager = GetComponent<RagdollManager>();
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
        _ragdollManager.TriggerRagdoll();
        Debug.Log("ded");
    }
}