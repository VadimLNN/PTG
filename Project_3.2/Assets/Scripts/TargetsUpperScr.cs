using UnityEngine;

public class TargetsUpperScr : MonoBehaviour
{
    public GameObject[] targets;
    public int state = 1;

    public bool onlyOne = false;

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!onlyOne)
            {
                if (state == 1)
                    foreach (GameObject target in targets)
                        target.GetComponent<TargetMoverScr>().upTarget();

                if (state == 2)
                    for (int i = 0; i < targets.Length; i++)
                        targets[i].GetComponent<TargetMoverScr>().moveTarget((float)(i + 1) / 10);
            }
            else
                upNext();
        }
    }

    public void upNext()
    {
        if (state == 1)
            targets[i].GetComponent<TargetMoverScr>().upTarget();

        if (state == 2)
            targets[i].GetComponent<TargetMoverScr>().moveTarget((float)(1 + 1) / 10);

        i++;
    }
}
