using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScr : MonoBehaviour
{
    [Range(0.1f, 5f)]
    public float delay = 0.1f;

    public Transform s_point_L;
    public Transform s_point_R;

    public GameObject prijectilel;

    float time = 0;
    bool left = true;

    void Start()
    {
        time = delay;
    }

    void LateUpdate()
    {
        time += Time.deltaTime;
        
        if (time >= delay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(left)
                    Instantiate(prijectilel, s_point_L.position, s_point_L.rotation);
                else
                    Instantiate(prijectilel, s_point_R.position, s_point_R.rotation);
            
                left = !left;
                time = 0;
            }
        }
    }
}
