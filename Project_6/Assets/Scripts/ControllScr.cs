using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    public LayerMask interactable;

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Clicked on " + hit.transform.name);

                if (hit.transform.GetComponent<InteractableObj>() != null)
                    hit.transform.GetComponent<InteractableObj>().interact();
            }
        }
    }
}
