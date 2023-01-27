using UnityEngine;
using TMPro;

public class WinDisplay : MonoBehaviour
{
    TextMeshProUGUI _scoreText;
    SaveWinDeathsCount _saveWinDeathsCount;

    private void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _saveWinDeathsCount = FindObjectOfType<SaveWinDeathsCount>();
    }
    private void Update()
    {
        _scoreText.text =$" Wins: " + _saveWinDeathsCount.GetWin().ToString();
    }
}
