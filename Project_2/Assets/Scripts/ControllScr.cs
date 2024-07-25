using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControllScr : MonoBehaviour
{
    // ������ �� ���������� ����, ��������� � ���������
    Rigidbody rb;
    int state = 0;
    Animator anim;

    // �������� ������������ � ��������
    float speed = 5;
    public float ang_speed = 72;

    // �������������� ��� ������
    [Range(0.1f, 1f)]
    public float jumpForce = 0.35f;
    public bool onGround;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        state = 0;

        // ��������� �������� � ������������ �����, ����� 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (onGround == true)
            {
                state = 1;
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
            }
            else                                                                            // �������� �������� �� � �����         
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * (speed * (float)0.75));
            
            
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (onGround == true)
            {
                state = 3;                                                           // �������� �������� �� �������� �����
                rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
            }
            else                                                                     // �������� �������� �� �������� ����� � �����
                rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * ((speed / 2) * (float)0.75));
        }

        // �������� � �������
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * ang_speed); ;
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * -ang_speed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // ������ 
        if (onGround == true && Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // ��������� �������� �������� � ����� 
        if (onGround == false)
            state = 5;

        /*if (state == 0) // �����
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector3 (0, y, 0);
        }*/

        // ��������������� ��������
        anim.SetInteger("state", state);
    }


}
