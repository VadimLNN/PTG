using UnityEngine;

public class TargetsUpperScr : MonoBehaviour
{
    public GameObject[] targets;
    public int state = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (state == 1)
               foreach (GameObject target in targets)
                    target.GetComponent<TargetMoverScr>().upTarget();

            if (state == 2)
                for (int i = 0; i < targets.Length; i++)
                    targets[i].GetComponent<TargetMoverScr>().moveTarget((float)(i+1)/10);
        }
    }
}
