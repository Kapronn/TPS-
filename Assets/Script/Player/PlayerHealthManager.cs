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
    private SaveWinDeathsCount _saveWinDeathsCount;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _saveWinDeathsCount = FindObjectOfType<SaveWinDeathsCount>();
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
        _saveWinDeathsCount.AddDeaths(1);
        Destroy(gameObject);
        _levelManager.LoadGameOverScene();
    }
    

    public int Health()
    {
        return health;
    }
}
