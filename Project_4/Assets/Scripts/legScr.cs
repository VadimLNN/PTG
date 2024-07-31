using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legScr : MonoBehaviour
{
    public Transform projector;
    public LayerMask ground;
    public legScr leftLeg;
    public legScr rightLeg;

    float stepDistance = 0.2f;
    float stepSpeed = 10;
    float overShoot = 0.9f;
    float stepHeight = 0.2f;

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
        transform.position = currentPos;

        Vector3 proj1 = Vector3.ProjectOnPlane(projector.position, Vector3.up);
        Vector3 proj2 = Vector3.ProjectOnPlane(currentPos, Vector3.up);

        if (Vector3.Distance(proj1, proj2) > stepDistance && lerp >= 1 
            && leftLeg.isMooving() == false && rightLeg.isMooving() == false)  
        {
            Physics.Raycast(projector.position + (proj1 - proj2) * overShoot, Vector3.down, out hit, 100, ground);
            newPos = hit.point;
            lerp = 0;
        }

        if (lerp < 1) 
        {
            Vector3 tempPos = Vector3.Lerp(oldPos, newPos, lerp);
            tempPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentPos = tempPos;
            lerp += Time.deltaTime * stepSpeed;
        }
        else
        {
            oldPos = newPos;
        }
    }

    public bool isMooving()
    {
        return lerp < 1;
    } 

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(projector.position, Vector3.down * 0.25f);
        Gizmos.DrawWireSphere(transform.position, stepDistance);
    }
}
