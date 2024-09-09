using UnityEngine;

public class TargetterLineScr : MonoBehaviour
{
    [Range(10, 1000)]
    public float lenght = 100;

    LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.forward * lenght);
    }
}
