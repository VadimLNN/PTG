using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Transform weaponHolder;

    int selectedWeaponIndex = 0;

    void Start() => hideWeapon();

    public void selectNextWeapon()
    {
        hideWeapon();

        selectedWeaponIndex++;

        if (selectedWeaponIndex > weaponHolder.childCount-1)
            selectedWeaponIndex = 0;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
    }

    public void selectPrevWeapon()
    {
        hideWeapon();

        selectedWeaponIndex--;

        if (selectedWeaponIndex < 0)
            selectedWeaponIndex = weaponHolder.childCount - 1;

        weaponHolder.GetChild(selectedWeaponIndex).gameObject.SetActive(true);
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
}
