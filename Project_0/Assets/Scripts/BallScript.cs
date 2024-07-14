using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    // ��� ������ � UI
    public Text val;


    // ���������� ��� ������ �����
    public void select()
    {
        ren.material = selectedMat;
    }

    public void setSpeed(float value)
    {
        Debug.Log(value.ToString());
        speed = value;
        val.text = speed.ToString();
    }


    // ���������� ����� ������ ������
    void Start()
    {
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
            transform.position += transform.right * Time.deltaTime * speed;
        }
        
    }
}
