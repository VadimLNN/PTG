using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementScr : MonoBehaviour
{
    [Range(0.5f, 10f)]
    public float lifeTime = 5;
    [Range(1f, 100f)]
    public float moveSpeed = 15;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.position += transform.forward * moveSpeed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            explode();
    }

    private void explode()
    {
        Destroy(gameObject);
    }
}
