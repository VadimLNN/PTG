using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        Vector3 resPos = new Vector3(target.position.x, transform.position.y, target.position.z);

        transform.position = resPos;
    }
}
