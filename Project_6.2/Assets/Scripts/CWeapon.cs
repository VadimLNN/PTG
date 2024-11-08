using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CWeapon : MonoBehaviour, IWeapon
{
    public Transform firePoint;
    public float fireRate;
    public float damage;
    [HideInInspector]
    public bool canFire = true;
    public ParticleSystem weaponEffect;

    private void Awake()
    {
        if (weaponEffect == null) return;

        var main = weaponEffect.main;
        main.duration = 1 / fireRate;
    }

    public virtual void fire(Ammunition ammunition)
    {
        if(ammunition.getAmmo(getWeaponType()) == false) return;
        canFire = false;
        StartCoroutine(coolDown());
    }

    public abstract WeaponTypes getWeaponType();

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1/fireRate);
        canFire = true;
    }

    private void OnEnable()
    {
        if (!canFire)
            StartCoroutine(coolDown());
    }
}
