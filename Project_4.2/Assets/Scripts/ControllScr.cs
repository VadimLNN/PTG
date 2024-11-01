using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScr : MonoBehaviour
{
    public HPScr hp;
    public AnimatorScr anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            hp.hpChange(-10);

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
    
        anim.setAnimatorParameters(x, z);
    }
}
