using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningProjectile : MonoBehaviour
{
    public float burnDamagePerSecond = 0.3f; // ���� �� �������
    public float burnDuration = 3f; // ������������ �������

    private void OnTriggerEnter(Collider other)
    {
        Health enemy = other.GetComponent<Health>();
        if (enemy != null)
        {
            enemy.hpDecrease(0.5f);

            // ����������� ������ �������
            enemy.ApplyBurnEffect(burnDamagePerSecond, burnDuration);

            Destroy(gameObject);
        }
    }
}
