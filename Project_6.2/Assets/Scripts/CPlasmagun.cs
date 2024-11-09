using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(PlasmagunLogic))]

public class CPlasmagun : CWeapon
{
    TracerSystem tracerSystem;
    PlasmagunLogic plasmagunLogic;

    void Start() => plasmagunLogic = GetComponent<PlasmagunLogic>();

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        //tracerSystem.createTracer(firePoint.position, firePoint.forward);
        plasmagunLogic.shot(firePoint, damage);
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Plasmagun;
    }
}
