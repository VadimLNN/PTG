using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class WeaponGUI
{
    public WeaponTypes weaponType;
    public TMP_Text text;
}

public class AmmunitionGUI : MonoBehaviour
{
    public Ammunition ammunition;

    public List<WeaponGUI> weaponsList;
    Dictionary<WeaponTypes, TMP_Text> weaponDictionary;

    public void listToDictionary()
    {
        weaponDictionary = new Dictionary<WeaponTypes, TMP_Text>();

        foreach (var weapon in weaponsList)
            if (weaponDictionary.ContainsKey(weapon.weaponType) == false)
                weaponDictionary.Add(weapon.weaponType, weapon.text);
    }

    void Start() 
    {
        listToDictionary(); 
        updateGUI();
    }

    public void updateGUI()
    {
        foreach(KeyValuePair<WeaponTypes, int> kvp in ammunition.ammoDictionary)
            if(weaponDictionary.ContainsKey(kvp.Key))
                weaponDictionary[kvp.Key].text = kvp.Value.ToString();
    }
}
