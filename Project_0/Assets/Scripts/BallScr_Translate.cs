using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallScr_Translate : MonoBehaviour
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
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }
}
