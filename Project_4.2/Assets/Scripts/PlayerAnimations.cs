using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static StateManagerScr;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    bool onGround = true;

    public UnityEvent jumpEvent;
    
    void Start() => anim = GetComponent<Animator>();

    public void setAnimatorParameters(float x, float z)
    {
        anim.SetFloat("speed_X", x);
        anim.SetFloat("speed_Z", z);
    }

    public void setGroundState(bool state)
    { 
        onGround = state;
        anim.SetBool("onGround", onGround);
    }

    public void jump()
    {
        if (onGround) 
            anim.SetTrigger("jump");
    }

    public void jumpStart()
    {
        jumpEvent?.Invoke();
    }

    public state getCurrentState()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("fall"))
            return state.falling;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("landing")) 
        {
            anim.ResetTrigger("jump");
            return state.langing;
        }

        return state.movement;
    }
}
