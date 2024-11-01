using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAimingRotation : MonoBehaviour
{
    [Range(1f, 1000f)]
    public float sensetivity = 1.0f;

    public GameObject character;
    Animator anim;

    public float x, y;
    private Vector3 lastMousePosition;

    private void Start() => anim = character.GetComponent<Animator>();

    void Update()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseDelta = currentMousePosition - lastMousePosition;


        if (mouseDelta != Vector3.zero)
        {
            if (-1 < x + mouseDelta.x / sensetivity && x + mouseDelta.x / sensetivity < 1)
                x += mouseDelta.x / sensetivity;

            if (-1 < y + mouseDelta.y / sensetivity && y + mouseDelta.y / sensetivity < 1)
                y += mouseDelta.y / sensetivity;
        }

        anim.SetFloat("x_axis", -x);
        anim.SetFloat("y_axis", y);


        lastMousePosition = currentMousePosition;
        
    }
}
