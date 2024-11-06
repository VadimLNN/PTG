using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    public WeaponSelector weaponSelector;

    public int numberOfWeapons = 4;

    void Update()
    {
        float mouseWheelDelta = Input.GetAxisRaw("Mouse ScrollWheel");
        if (mouseWheelDelta > 0) weaponSelector.selectNextWeapon();
        if (mouseWheelDelta < 0) weaponSelector.selectPrevWeapon();
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.KeyDown)
        {
            int k = (int)(e.keyCode - KeyCode.Alpha0);

            if (!(k > 0 && k <= numberOfWeapons))
            {
                k = (int)(e.keyCode - KeyCode.Keypad0);

                if(!(k > 0 && k <= numberOfWeapons))
                    return;
            }

            weaponSelector.selectWeaponByIndex(k-2);
        }
    }
}
