using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class doorAminScr : MonoBehaviour
{
    int ang = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OpenClose", 0, 3);
    }

    public void OpenClose()
    {
        ang *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), -ang * Time.fixedDeltaTime, Space.World);
    }


}
