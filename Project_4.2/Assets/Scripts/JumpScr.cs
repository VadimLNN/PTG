using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScr : MonoBehaviour
{
    [Range(1f, 100f)]
    public float jumpForce = 10f;

    public PlayerAnimations pa;

    Rigidbody rb;

    void Start() => rb = GetComponent<Rigidbody>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            pa.jump();
    }
    public void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
