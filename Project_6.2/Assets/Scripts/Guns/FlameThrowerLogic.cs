using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;

    public Transform shotPoint;
    public GameObject projectile;

    public void shot(Transform firePoint, float damage)
    {
        Instantiate(projectile, shotPoint.position, shotPoint.rotation);
    }
}
