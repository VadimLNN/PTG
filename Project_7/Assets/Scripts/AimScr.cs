using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScr : MonoBehaviour
{
    // ������ �� ��������, ������, 
    public Animator anim;
    public Camera cam;
    Coroutine zoomCor;

    // ��������� ������������ 
    bool isAim = false;

    void Update()
    {
        isAim = false;

        if (Input.GetButton("Fire2"))
            isAim = true;

        anim.SetBool("isAim", isAim);
    }
}
                                                                                                                                                                                            