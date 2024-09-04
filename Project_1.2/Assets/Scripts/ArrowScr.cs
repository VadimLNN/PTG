using UnityEngine;

public class ArrowScr : MonoBehaviour
{
    [Range(10, 100)]
    public float force;

    public int dir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dir == 1)
        {
            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player") && dir == 2)
        {
            other.transform.GetComponent<Rigidbody>().AddForce(-Vector3.up * force, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player") && dir == 3)
        {
            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * force, ForceMode.Impulse);
        }
        else if (other.CompareTag("Player") && dir == 4)
        {
            other.transform.GetComponent<Rigidbody>().AddForce(Vector3.right * force, ForceMode.Impulse);
        }
    }
}
