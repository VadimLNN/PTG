using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legScr : MonoBehaviour
{
    public Transform projector;
    public LayerMask ground;
    float stepDistance = 0.2f;

    Vector3 oldPos, newPos, currentPos;

    RaycastHit hit;

    float lerp = 1;

    void Start()
    {
        Physics.Raycast(projector.position, Vector3.down, out hit, 100, ground);
        oldPos = newPos = currentPos = hit.point;
    }

    void LateUpdate()
    {
        transform.position = oldPos;

        Vector3 proj1 = Vector3.ProjectOnPlane(projector.position, Vector3.up);
        Vector3 proj2 = Vector3.ProjectOnPlane(oldPos, Vector3.up);

        if (Vector3.Distance(proj1, proj2) > stepDistance) 
        {
            Physics.Raycast(projector.position, Vector3.down, out hit, 100, ground);
            oldPos = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(projector.position, Vector3.down * 0.25f);
        Gizmos.DrawWireSphere(transform.position, stepDistance);
    }
}
