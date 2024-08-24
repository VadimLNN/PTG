using UnityEngine;

public class BilboardScr : MonoBehaviour
{
    public Transform cam;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);    
    }
}
