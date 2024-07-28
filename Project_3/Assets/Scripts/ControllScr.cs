using System.Collections;
using System.Collections.Generic;
using System.Resources;
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
    [Range(1f, 10f)]
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

    void LateUpdate()
    {
        state = 0;

        // ��������� �������� � ������������ �����, ����� 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if(onGround && Input.GetKey(KeyCode.LeftShift))
            {
                state = 3;                                                      // ��������� �������� X2 �� ���
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed*2);
            }
            else
            {
                state = 1;
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
            }
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            state = 2;                                                           // �������� �������� �� �������� �����
            rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
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
        {
            state = 4;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // ������ ���� ������ �� ���, ���� �������� �����, ��� �����/�����, �����
        if (onGround && (state == 0 || state == 1 || state == 2 || state == 3) && Input.GetAxis("Fire1") == 1)
            state = 5;

        // ���� ����� ������ �� ���, ���� �������� �����, ��� �����/�����, �����
        if (onGround && (state == 0 || state == 1 || state == 2 || state == 3) && Input.GetAxis("Fire2") == 1)
            state = 6;

        // ��������������� ��������
        anim.SetInteger("state", state);
    }
}
