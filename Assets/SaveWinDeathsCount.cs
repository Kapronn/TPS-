
using UnityEngine;

public class SaveWinDeathsCount : MonoBehaviour
{
    private int _wins = 0;
    private int _deaths = 0;

    private void Awake()
    {
        SaveSystem();
    }
    private void SaveSystem()
    {
        int numberOfGameSession = FindObjectsOfType<SaveWinDeathsCount>().Length;
        if (numberOfGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddWins(int plusWin)
    {
        _wins += plusWin;
    }
    
    public void AddDeaths(int plusDeath)
    {
        _deaths += plusDeath;
    }
    public int GetWin()
    {
        return _wins;
    }

    public int GetDeath()
    {
        return _deaths;
    }

}
