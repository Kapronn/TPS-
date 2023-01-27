
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    private LevelManager _levelManager;
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    
    void Update()
    {
        int numberOfZombies = FindObjectsOfType<EnemyHealth>().Length;
        if(numberOfZombies <= 0) _levelManager.LoadWinScene();
    }
}
