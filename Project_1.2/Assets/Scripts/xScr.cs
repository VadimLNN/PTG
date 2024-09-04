using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xScr : MonoBehaviour
{
    [Range(1, 300)]
    public float speed = 100;
    public bool clockwise = true;

    Rigidbody rb;

    Vector3 m_EulerAnlgeVelosity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAnlgeVelosity = new Vector3(0, 0, speed);    
    }

    void FixedUpdate()
    {
        Quaternion deltaRotation;

        if (clockwise)
            deltaRotation = Quaternion.Euler(m_EulerAnlgeVelosity * Time.fixedDeltaTime * -1);
        else
            deltaRotation = Quaternion.Euler(m_EulerAnlgeVelosity * Time.fixedDeltaTime);
    
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
