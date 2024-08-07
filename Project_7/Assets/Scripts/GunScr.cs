using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScr : MonoBehaviour
{
    // ���� � ��������� 
    public float dmg = 10f;
    public float range = 1000f;

    //  �������� �������� (10 � �������) � ����� �� ����. �������� 
    public float fireRate = 10f;
    public float nextShot = 0f;

    // ������ �� ������, ������� ������ ��� �������� � ���������
    public Camera cam;
    public ParticleSystem flash;
    public ParticleSystem onHit;

    // ������ �� ������ 
    public GameObject gilza_orig;
    void Update()
    {
        // ����� �������� ��� ������� ������ �������� 
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            // ������ ������� �� ���� �������� � �������
            nextShot = Time.time + 1 /fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // ��������������� ������� 
        flash.Play();
        
        // �������� ������� ������ 
        GameObject gilza = Instantiate(gilza_orig, transform.position, transform.rotation);
        // �������� ����������� ���� ������ ��� �������� ���������
        Rigidbody rb_g = gilza.GetComponent<Rigidbody>();
        rb_g.AddForce(Vector3.up * 400f);
        // ����������� ������� ����� 5 ������ 
        Destroy(gilza.gameObject, 5f);


        // ���� ��� �� ������ ����� �� ���-��
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // ���� ��� ���-�� ����� ��� "����"
            if (hit.transform.CompareTag("target"))
            {
                // ��������� ������� � ������� ����
                TargetScr t = hit.transform.GetComponent<TargetScr>();
                // ����� ������ ��������� ����� 
                t.Hit(range);            
            }

            // �������� � ��������������� ������� �������� � ����� ��������� 
            ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
            // ��������������� �������� 
            hitEffect.Play();
            // ����������� ������� ����� ������� 
            Destroy(hitEffect.gameObject, 1f);
        }
    }
}
