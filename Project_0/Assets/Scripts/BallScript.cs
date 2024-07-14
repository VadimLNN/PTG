using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
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

    // ���������� ��� ������ �����
    public void select()
    {
        ren.material = selectedMat;
    }


    // ���������� ����� ������ ������
    void Start()
    {
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
            transform.position += transform.right * Time.deltaTime * speed;
        }
        
    }
}
