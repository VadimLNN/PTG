using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScr : MonoBehaviour
{
    // �������� ����������� � ���� ������
    public float speed = 1;
    public float jumpForce = 1000;

    public legScr[] legs;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void LateUpdate()
    {
        // ��������� ����������� �������� �� ��������  
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        
        Vector3 dir = new Vector3 (h, 0, v);
        dir = transform.TransformDirection(dir.normalized); // ���������� �������� ������� � ������� ����������� �������� 
        dir *= speed;                                       // ���������� �������� � ������� �����������
        dir.y = rb.velocity.y;                              // �������������� �������� �� ��� Y
        rb.velocity = dir;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �������� �������� �����
            rb.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            // ������� ������� ������ ������� 
            transform.Rotate(Vector3.up, -Mathf.PI/8, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            // ������� ������� �� ������� 
            transform.Rotate(Vector3.up, Mathf.PI / 8, Space.World);
        }
    
        Vector3 v1 = legs[0].transform.position - legs[3].transform.position; 
        Vector3 v2 = legs[1].transform.position - legs[2].transform.position;

        Vector3 normal = Vector3.Cross(v1, v2).normalized;

        transform.rotation = Quaternion.Slerp(transform.rotation, (Quaternion.FromToRotation(transform.up, normal) * transform.rotation), Mathf.PI / 18);
    }
}
