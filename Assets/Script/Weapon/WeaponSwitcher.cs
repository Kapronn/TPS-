using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int weaponSwitch = 0;
    void Start()
    { 
        SelectWeapon();
    }

    
    void Update()
    {
        int currentWeapon = weaponSwitch;
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSwitch = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponSwitch = 2;
        }
        if (currentWeapon != weaponSwitch)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSwitch) weapon.gameObject.SetActive(true);
            
            else weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
