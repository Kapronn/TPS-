
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    private EnemyHealth _enemyHealth;
    private LevelManager _levelManager;
    private SaveWinDeathsCount _saveWinDeathsCount;
    
    void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _saveWinDeathsCount = FindObjectOfType<SaveWinDeathsCount>();
    }

    
    void Update()
    {
        int numberOfZombies = FindObjectsOfType<EnemyHealth>().Length;
        if (numberOfZombies <= 0)
        {
            _saveWinDeathsCount.AddWins(1);
            _levelManager.LoadWinScene();
        }
    }
}
