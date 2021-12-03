using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] public int currentWeapon;

    
    
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();

    }

    // Update is called once per frame
    void Update()
    {
        // curWeapon assign to prevweapon 
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        processScrollWheel();

        // prvWpn & curWpn != than setnextweapon foreach loop
        {
        if (previousWeapon != currentWeapon)
            SetWeaponActive();
        }

    }

    private void processScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0 ;
            }
            else 
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else 
            {
                currentWeapon--;
            }
        }

        
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;

        } 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;

        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;

        } 
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }
    }

    
}
