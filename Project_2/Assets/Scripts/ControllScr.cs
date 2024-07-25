using System.Collections;
using System.Collections.Generic;
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
    public float jumpForce = 0.5f;
    public bool onGround;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
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

        // ��������������� �������� ������������ �����
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (onGround == true)
                state = 1;

            Vector3 v = transform.forward * speed;
            v.y += rb.velocity.y;
            rb.velocity = v;
        }

        // �������� � �������
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up, ang_speed * Time.deltaTime, Space.Self);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(Vector3.up, -ang_speed * Time.deltaTime, Space.Self);
        }

        // ������
        if (onGround == true && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (onGround == false)
            state = 2;

        if (state == 0) // �����
        {
            //float y = rb.velocity.y;
            //rb.velocity = new Vector3 (0, y, 0);
        }

        anim.SetInteger("state", state);
    }


}
