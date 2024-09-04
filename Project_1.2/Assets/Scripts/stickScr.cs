using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickScr : MonoBehaviour
{
    [Range(1, 300)]
    public float speed = 10;

    Rigidbody rb;

    bool up = true;
    float time = 1.3f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        time -= Time.deltaTime;

        if (up)
            rb.MovePosition(rb.position - Vector3.up/12);
        else 
            rb.MovePosition(rb.position + Vector3.up/12);

        if (time <= 0)
        {
            time = 1.3f;
            up = !up;
        }
    }
}
