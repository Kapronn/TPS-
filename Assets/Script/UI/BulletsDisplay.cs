using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletsDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    WeaponManager weapon;
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        weapon = FindObjectOfType<WeaponManager>();
    }


    void Update()
    {
        healthText.text =  $"Ammo {weapon.currentAmmo}/{weapon.extraAmmo}";
        
    }
}

