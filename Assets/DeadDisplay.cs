using UnityEngine;
using TMPro;

public class DeadDisplay : MonoBehaviour
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
        _scoreText.text = $" Lose: " + _saveWinDeathsCount.GetDeath().ToString();
    }
}
