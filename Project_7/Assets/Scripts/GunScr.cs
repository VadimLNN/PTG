using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScr : MonoBehaviour
{
    // ���� � ��������� 
    public float dmg = 10f;
    public float range = 1000f;

    // ������ �� ������ � ������� ������
    Camera cam;
    public ParticleSystem flash;

    void Update()
    {
        // ����� �������� ��� ������� ������ �������� 
        if (Input.GetButton("Fire1")) Shoot();    
    }

    void Shoot()
    {
        // ��������������� ������� 
        flash.Play();

        // ���� ��� �� ������ ����� �� ���-��
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // ���� ��� ���-�� ����� ��� "����"
            if(hit.transform.CompareTag("target"))
            {
                // ��������� ������� � ������� ����
                TargetScr t = hit.transform.GetComponent<TargetScr>();
                // ����� ������ ����� 
                t.Hit(range);            
            }
        }
    }
}
