using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

public class Ammunition : MonoBehaviour
{
    public List<WeaponAmmo> ammoList = new List<WeaponAmmo>();
    public Dictionary<WeaponTypes, int> ammoDictionary;

    public UnityEvent onAmmoChange;

    public void listToDictionary()
    {
        ammoDictionary = new Dictionary<WeaponTypes, int>();

        foreach (var ammo in ammoList)
            if (ammoDictionary.ContainsKey(ammo.type) == false)
                ammoDictionary.Add(ammo.type, ammo.ammo);
    }

    private void Start()
    {
        listToDictionary();
        onAmmoChange?.Invoke();
    }

    public bool checkAmmo(WeaponTypes type)
    {
        if (ammoDictionary.ContainsKey(type) == false)
            return false;
        if (ammoDictionary[type] < 1) 
            return false;

        return true;
    }

    public bool getAmmo(WeaponTypes type) 
    {
        if (ammoDictionary.ContainsKey(type) == false)
            return false;
        if (ammoDictionary[type] < 1)
            return false;

        ammoDictionary[type]--;
        onAmmoChange?.Invoke();

        return true;
    }

    public bool addAmmo(WeaponTypes type, int amount)
    {
        if(ammoDictionary.ContainsKey(type) == false)
            return false;

        ammoDictionary[type] += amount;
        onAmmoChange?.Invoke();

        return true;
    }
}
