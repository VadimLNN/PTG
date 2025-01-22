using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement2Scr : MonoBehaviour
{
    [Range(0.5f, 10f)]
    public float lifeTime = 5;
    [Range(1f, 100f)]
    public float moveSpeed = 15;

    Rigidbody rb;
    SphereCollider sCol;
    public bool scale = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sCol = transform.GetComponent<SphereCollider>();
    }

    void Update()
    {
        if (scale)
            sCol.transform.localScale *= 1.01f;

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
