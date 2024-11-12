using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScr : MonoBehaviour
{
    public Ammunition ammunition;
    CWeapon currentWeapon;
    bool isFiring = false;

    public void setWeapon(CWeapon selectedWeapon)
    {
        fireEnd();
        currentWeapon = selectedWeapon;
    }

    public void fireStart()
    {
        isFiring = true;
        if(currentWeapon.weaponEffect != null && currentWeapon.canFire)
            currentWeapon.weaponEffect.Play();
    }
    
    public void fireEnd()
    {
        isFiring = false;
        if(currentWeapon != null)
            if (currentWeapon.weaponEffect != null)
                currentWeapon.weaponEffect.Stop();
    }

    void Update()
    {
        if(currentWeapon != null)
            if(isFiring)
                if (ammunition.checkAmmo(currentWeapon.getWeaponType()))
                {
                    if (currentWeapon.canFire)
                    {
                        currentWeapon.fire(ammunition);

                        if (currentWeapon.weaponEffect != null)
                            if (currentWeapon.weaponEffect.isPlaying == false)
                                currentWeapon.weaponEffect.Play();
                    }
                }
                else
                    if (currentWeapon != null)
                        if (currentWeapon.weaponEffect != null)
                            currentWeapon.weaponEffect.Stop();
    }
}
