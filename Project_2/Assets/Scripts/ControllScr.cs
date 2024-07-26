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

    // ������������ ��������� �����
    public bool attacking = false;


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
        // ���� �� ���������� �����
        if (attacking == false){
            state = 0;

            // ��������� �������� � ������������ �����, ����� 
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (onGround == true)
                {
                    state = 2;
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

            // ��������� �������� � ������������ ������, �����
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                state = 4;
                rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                state = 5;
                rb.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * speed);
            }

            /*// �������� � �������
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * ang_speed); ;
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * -ang_speed);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }*/

            // ������ 
            if (onGround == true && Input.GetKey(KeyCode.Space))
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // ��������� �������� �������� � ����� 
            if (onGround == false)
                state = 1;

            if (onGround && (state == 0 || state == 2) && Input.GetKey(KeyCode.LeftControl))
                state = 6;

            if (onGround && (state == 0 || state == 2) && Input.GetKey(KeyCode.LeftShift))
                state = 7;
        }

        // ��������������� ��������
        anim.SetInteger("state", state);
    }

    public void AttackOn()
    {
        attacking = true;
    }
    
    public void AttackOff() 
    {
        attacking = false;
    }
}
