using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    [Range(1f, 100f)]
    public float zSpeed = 5;
    [Range(0.5f, 50f)]
    public float xSpeed = 3;

    Rigidbody rb;

    Vector3 xV;
    Vector3 zV;
    Vector3 V;

    public PlayerAnimations anims;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        xV = new Vector3();
        zV = new Vector3();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        zV = new Vector3 (0, 0, z);
        xV = new Vector3 (x, 0, 0);

        V = (zV + xV).normalized;

        V.x *= xSpeed;
        V.z *= zSpeed;

        anims.setAnimatorParameters(V.x/xSpeed, V.z/zSpeed);

        V = transform.TransformDirection(V);

        V.y = rb.velocity.y;

        rb.velocity = V;
    }
}
