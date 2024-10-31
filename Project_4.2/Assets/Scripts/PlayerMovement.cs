using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManagerScr;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 100f)]
    public float runSpeed = 10;
    [Range(1f, 100f)]
    public float sideStepSpeed = 5;

    [Range(0.1f, 10f)]
    public float acceleration = 3f;
    [Range(0.1f, 10f)]
    public float deceleration = 5f;

    float maxXSpeed;
    float xSpeed = 0;
    float maxZSpeed;
    float zSpeed = 0;

    Rigidbody rb;
    Vector3 V;

    public PlayerAnimations pa;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxZSpeed = runSpeed;
        maxXSpeed = sideStepSpeed;
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        getAnimationState();

        bool sprint = (Input.GetKey(KeyCode.LeftShift));

        if (sprint)
            maxZSpeed = runSpeed * 1.5f;
        else 
            maxZSpeed = runSpeed;


        if (x != 0)
            xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, acceleration * Time.deltaTime);
        else 
            if (xSpeed != 0)
            xSpeed = Mathf.Lerp(xSpeed, x * maxXSpeed, deceleration * Time.deltaTime);

        if (z != 0)
            zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, acceleration * Time.deltaTime);
        else
            if (zSpeed != 0)
            zSpeed = Mathf.Lerp(zSpeed, z * maxZSpeed, deceleration * Time.deltaTime);

        pa.setAnimatorParameters(xSpeed / sideStepSpeed, zSpeed / runSpeed);

        V = new Vector3(x, 0, z).normalized;
        V.x *= xSpeed < 0 ? -xSpeed : xSpeed;
        V.z *= zSpeed < 0 ? -zSpeed : zSpeed;



        V = transform.TransformDirection(V);

        V.y = rb.velocity.y;

        rb.velocity = V;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ground"))
            pa.setGroundState(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            pa.setGroundState(false);
    }

    void getAnimationState()
    {
        state st = pa.getCurrentState();

        switch (st) 
        {
            case state.falling:
            {
                maxXSpeed = sideStepSpeed / 2;
                maxZSpeed = runSpeed / 2;
                break;
            }
            case state.langing:
            {
                xSpeed = 0;
                zSpeed = 0;
                maxXSpeed = 0;
                maxZSpeed = 0;
                break;
            }
            default:
            {
                maxXSpeed = sideStepSpeed;
                return;
            }
        }
    }
}
