using System;
using System.Collections;
using UnityEngine;


public class PlayerHealthManager : MonoBehaviour
{
    private Level level;
    [SerializeField] int health = 100;
    private float _currentTime;
    [SerializeField] private float takeDamageColdDown = 2f;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        Debug.Log(_currentTime);
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
        Destroy(gameObject);
        level.LoadGameOverScene();
    }

    IEnumerable shotsColdDown()
    {
        yield return new WaitForSeconds(3);
    }

    public int Health()
    {
        return health;
    }
}
