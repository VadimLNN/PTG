using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Transform weaponHolder;

    int selectedWeaponIndex = 0;

    void Start() => hideWeapon();

    public CWeapon selectNextWeapon()
    {
        hideWeapon();

        selectedWeaponIndex++;

        if (selectedWeaponIndex > weaponHolder.childCount-1)
            selectedWeaponIndex = 0;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }

    public CWeapon selectPrevWeapon()
    {
        hideWeapon();

        selectedWeaponIndex--;

        if (selectedWeaponIndex < 0)
            selectedWeaponIndex = weaponHolder.childCount - 1;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }

    public void selectWeaponByIndex(int ind)
    {
        hideWeapon();

        if (ind > -1 && ind <= weaponHolder.childCount)
        {
            selectedWeaponIndex = ind;
            weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
        }
    }

    void hideWeapon()
    {
        foreach (Transform child in weaponHolder)
            child.gameObject.SetActive(false);
    }

    public CWeapon getSelectedWeapon()
    {
        return weaponHolder.GetChild(selectedWeaponIndex).gameObject.GetComponent<CWeapon>();
    }
}
