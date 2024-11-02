using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll4Scr : MonoBehaviour
{
    public GameObject character;
    Animator4Scr anim;

    void Start() => anim = character.GetComponent<Animator4Scr>();

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
    
        anim.setAnimatorParameters(x, z);
    }
}
