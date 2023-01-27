using System;
using System.Collections;
using Cinemachine;
using UnityEngine;


public class PlayerHealthManager : MonoBehaviour
{
    private LevelManager _levelManager;
    [SerializeField] int health = 100;
    private float _currentTime;
    [SerializeField] private float takeDamageColdDown = 2f;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void Update()
    {
        
        _currentTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        EnemyDamageDealer enemyDamageDealer = collision.GetComponent<EnemyDamageDealer>();
        if (_currentTime > takeDamageColdDown)
        {
            ProcessHit(enemyDamageDealer);
            _currentTime = 0;
        }

    }

    private void ProcessHit(EnemyDamageDealer enemyDamageDealer)
    {
        health -= enemyDamageDealer.GetDamageDealer();
            if (!enemyDamageDealer)
            {
                return;
            }

            if (health <= 0)
            {
                Die();
            }
        
    }

    void Die()
    {
        _levelManager.LoadGameOverScene();
        Destroy(gameObject);
    }
    

    public int Health()
    {
        return health;
    }
}
