using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScr : MonoBehaviour
{
    public Transform target;

    public float mSpeed = 5f;
    public float rSpeed = 5f;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, mSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rSpeed * Time.fixedDeltaTime);
    }
}
