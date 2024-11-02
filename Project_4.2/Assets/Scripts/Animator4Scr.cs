using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator4Scr : MonoBehaviour
{
    Animator anim;

    private void Start() => anim = GetComponent<Animator>();
    private void Update()
    {
        anim.SetBool("Block", false);

        if (Input.GetMouseButton(1))
            anim.SetBool("Block", true);
    }

    public void setAnimatorParameters(float x, float z)
    {
        anim.SetFloat("speed_X", x);
        anim.SetFloat("speed_Z", z);
    }
}
