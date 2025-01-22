using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScr : MonoBehaviour
{
    [Range(200f, 500f)]
    public float mSpeed = 300f;

    Rigidbody rb;
    public Camera cam;
    float baseFOV;
    public float sprintFOV = 1.25f;

    [Range(1000f, 5000f)]
    public float jumpForce = 2000f;

    public LayerMask ground;
    public Transform groundDetect;

    void Start()
    {
        baseFOV = cam.fieldOfView;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // �������� ���������� ������ �� ����������� 
        bool groundCheck = Physics.Raycast(groundDetect.position, Vector3.down, 0.1f, ground);
        bool jump = Input.GetKey(KeyCode.Space) && groundCheck;

        // ������ ���� ����� �� � �����
        if (jump) rb.AddForce(Vector3.up * jumpForce);

        // ����������� ���������� ��� ����������� ��������� ���� 
        bool sprint = (Input.GetKey(KeyCode.LeftShift));

        // �������� ������� w a s d
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        // ��������� ����������� �������� � ��������� X/Z
        Vector3 dir = new Vector3(xMove, 0, zMove);
        // ������������ ������� 
        dir.Normalize();

        Vector3 v;

        // ������ �������� = ����������� * �������� * ����� � ���������� ������
        // ���� ��������� x1.25 ��� ���� 
        if (sprint && zMove > 0)
        { 
            v = transform.TransformDirection(dir) * mSpeed*2 * Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV * sprintFOV, Time.fixedDeltaTime * 8f);
        }
        else
        {
            v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV, Time.fixedDeltaTime * 8f);
        }

        // �������������� �������� �� Y
        v.y = rb.linearVelocity.y;
        // ���������� ��������
        rb.linearVelocity = v;
    }
}
