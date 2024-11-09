using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TracerSystem))]
[RequireComponent(typeof(FlameThrowerLogic))]

public class CFlameThrower : CWeapon
{
    TracerSystem tracerSystem;
    FlameThrowerLogic flameThrowerLogic;

    void Start() => flameThrowerLogic = GetComponent<FlameThrowerLogic>();

    public override void fire(Ammunition ammunition)
    {
        base.fire(ammunition);

        //tracerSystem.createTracer(firePoint.position, firePoint.forward);
        flameThrowerLogic.shot(firePoint, damage);
    }

    public override WeaponTypes getWeaponType()
    {
        return WeaponTypes.Flamer;
    }
}
