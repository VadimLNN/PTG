using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : InteractableObj
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void interact()
    {
        anim.SetInteger("state", 2);
    }

    public void dead()
    {
        Destroy(this.gameObject, 1);
    }
}
