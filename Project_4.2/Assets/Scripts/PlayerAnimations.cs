using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public GameObject character;
    Animator anim;
    
    void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    public void setAnimatorParameters(float x, float z)
    {
        anim.SetFloat("speed_X", x);
        anim.SetFloat("speed_Z", z);
    }
}
