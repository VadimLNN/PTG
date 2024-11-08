using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;

    public void shot(Transform firePoint, float damage)
    {
        RaycastHit hit;

        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 1000f, enemy))
        {

        }
    }
}
