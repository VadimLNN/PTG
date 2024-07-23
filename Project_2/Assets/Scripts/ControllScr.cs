using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScr : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        anim.SetInteger("state", 0);
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            anim.SetInteger("state", 1);
        }
    }
}
