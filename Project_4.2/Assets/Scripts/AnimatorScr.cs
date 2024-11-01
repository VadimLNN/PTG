using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScr : MonoBehaviour
{
    Animator anim;
    bool onGround = true;
    int injuredLayerIndex;

    void Start()
    {
        anim = GetComponent<Animator>();
        injuredLayerIndex = anim.GetLayerIndex("injured");
    }

    public void setAnimatorParameters(float x, float z)
    {
        if(onGround)
        {
            anim.SetFloat("speed_X", x);
            anim.SetFloat("speed_Z", z);
        }
    }
    public void damageTaken(float hpRatio)
    {
        anim.SetTrigger("onHit");
        anim.SetLayerWeight(injuredLayerIndex, 1 - hpRatio);
    }
}
