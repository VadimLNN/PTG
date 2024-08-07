using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    public float hp = 10f;

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0) Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
