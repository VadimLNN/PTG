using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchColliderScript : MonoBehaviour
{
    public Camera cam;
    public LayerMask floor;

    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);

        if(Physics.Raycast(ray, out hit, 1000, floor))
        {
            Vector3 pnt = hit.point;
            pnt.y = transform.position.y;

            Vector3 dir = (pnt - transform.position);
            dir.Normalize();
            dir *= 2;

            lr.SetPosition(1, (transform.position + dir));
        }
    }
}
