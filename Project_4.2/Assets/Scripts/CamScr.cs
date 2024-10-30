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
        Vector3 respos = new Vector3(target.position.x, target.position.y + 4, target.position.z - 4);

        transform.position = Vector3.MoveTowards(transform.position, respos, mSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rSpeed * Time.fixedDeltaTime);
    }
}
