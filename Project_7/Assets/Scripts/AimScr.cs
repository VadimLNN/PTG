using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScr : MonoBehaviour
{
    // ссылки на аниматор, камеру, 
    public Animator anim;
    public Camera cam;
    Coroutine zoomCor;

    // состояние прицеливания 
    bool isAim = false;

    void Update()
    {
        isAim = false;

        if (Input.GetButton("Fire2"))
            isAim = true;

        anim.SetBool("isAim", isAim);
    }
}
                                                                                                                                                                                            