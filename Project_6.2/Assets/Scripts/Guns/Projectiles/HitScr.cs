using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScr : MonoBehaviour
{
    [Range(0.5f, 50f)]
    public float explosionRadius = 5;

    public LayerMask enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, enemy);

            foreach (Collider col in cols)
            {
                Health enemyHp = col.transform.GetComponent<Health>();
                if (enemyHp != null)
                {
                    enemyHp.hpDecrease(20);
                }
            }
        }
    }
}
