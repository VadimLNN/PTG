using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningProjectile : MonoBehaviour
{
    public float burnDamagePerSecond = 0.3f; // Урон от горения
    public float burnDuration = 3f; // Длительность эффекта

    private void OnTriggerEnter(Collider other)
    {
        Health enemy = other.GetComponent<Health>();
        if (enemy != null)
        {
            enemy.hpDecrease(0.5f);

            // Накладываем эффект горения
            enemy.ApplyBurnEffect(burnDamagePerSecond, burnDuration);

            Destroy(gameObject);
        }
    }
}
