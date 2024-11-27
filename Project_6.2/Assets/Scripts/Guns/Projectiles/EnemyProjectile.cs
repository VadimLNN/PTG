using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Range(0.5f, 50f)]
    public float explosionRadius = 5;

    public LayerMask player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHp = other.transform.GetComponent<Health>();
            if (playerHp != null)
            {
                playerHp.hpDecrease(5);
                Destroy(gameObject);
            }
        }
    }
}
