using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Range(0.1f, 3f)]
    public float sensetivity = 1.0f;

    float y = 0;

    void Update()
    {
        y += Input.GetAxis("Mouse X") * sensetivity;
        transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}
