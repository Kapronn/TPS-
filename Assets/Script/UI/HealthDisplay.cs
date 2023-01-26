using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    PlayerHealthManager player;
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<PlayerHealthManager>();
    }

    
    void Update()
    {
        healthText.text = $" Hp: " + player.Health().ToString();
    }
}
