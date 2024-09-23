using UnityEngine;

public class TargetsUpperScr : MonoBehaviour
{
    public GameObject[] targets;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("yup");
            foreach (GameObject target in targets)
            {
                target.GetComponent<TargetMoverScr>().upTarget();
            }
        }
    }
}
