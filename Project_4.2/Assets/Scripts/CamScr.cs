using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CamScr : MonoBehaviour
{
    Transform target;

    public float mSpeed = 5f;
    public float rSpeed = 5f;

    public bool camInFace = false;

    void FixedUpdate()
    {
        Vector3 resPos = new Vector3();

        if (camInFace) 
            resPos = target.position + target.forward*2.5f;
        else 
            resPos = target.position - target.forward*2.5f;

        resPos.y += 3;

        Vector3 resTergertPos = target.position + new Vector3(0,2,0);
        transform.LookAt(resTergertPos);

        transform.position = Vector3.MoveTowards(transform.position, resPos, mSpeed * Time.fixedDeltaTime);
        //transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rSpeed * Time.fixedDeltaTime);
    }

    public void changeTraget(Transform newTarget)
    {
        this.target = newTarget;
    }
}
