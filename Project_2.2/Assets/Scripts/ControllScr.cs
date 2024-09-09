using UnityEngine;

public class ControllScr : MonoBehaviour
{
    public Camera cam;

    public Transform stand;
    public Transform barrels;
    public LayerMask farPlane;

    [Range(5f, 100f)]
    public float horizontal_speed = 50;
    [Range(5f, 100f)]
    public float vertical_speed = 50;

    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, farPlane))
        {
            Vector3 dir = hit.point;// - transform.position/5;
            
            Vector3 xz = dir;
            xz.y = 0;

            stand.rotation = Quaternion.RotateTowards(stand.rotation, Quaternion.LookRotation(xz), horizontal_speed * Time.deltaTime);
            barrels.rotation = Quaternion.RotateTowards(barrels.rotation, Quaternion.LookRotation(dir), vertical_speed * Time.deltaTime);
        }
    }
}
