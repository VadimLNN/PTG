using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallScr_SetVelosity : MonoBehaviour
{
    // ��� ������ �� ��������� ����
    [Range(0.1f, 100f)]
    public float speed = 2;

    // ��� ������ � ���������� ���� ��� ����������� 
    public Material hitMat;
    private Renderer ren;

    // ��� ������ � ���������� ���� ��� ������ 
    [HideInInspector] // �������� ���������� � ����������
    public bool start = false; // ���������� ������������ ������ ��������

    public Material defoultMat; //  ��������� �� ������
    public Material selectedMat; // �������� ��� ������

    // ��� ������ � UI
    public Text val;

    // ��������� ������� ����
    Vector3 oldPos;

    Rigidbody rb;

    // ���������� ��� ������ �����
    public void select()
    {
        ren.material = selectedMat;
    }

    // ���������� �������� 
    public void setSpeed(float value)
    {
        Debug.Log(value.ToString());
        speed = value;
        val.text = speed.ToString();
    }

    // ����� ���������� 
    public void reset()
    {
        transform.position = oldPos;
        start = false;
        ren.material = defoultMat;
    }


    // ���������� ����� ������ ������
    void Start()
    {
        // ���������� ��������� ������� 
        oldPos = transform.position;

        val.text = speed.ToString();

        rb = GetComponent<Rigidbody>();

        ren = GetComponent<Renderer>();
        ren.material = defoultMat;
    }

    // ���������� ��� ������������ 
    private void OnCollisionEnter(Collision collision)
    {
        // ����� ��������� ��� ������������ 
        ren.material = hitMat; 
    }

    // ���������� ������ ����
    void Update()
    {
        if (start)        
        {
            //transform.position += transform.right * Time.deltaTime * speed;
            rb.velocity = Vector3.right * speed;
        }
        
    }
}
