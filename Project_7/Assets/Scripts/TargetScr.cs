using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    public float hp = 10f;
    public ParticleSystem explosion;

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0) Death();
    }

    void Death()
    {
        // �������� ����� ������� ������ � ���������� � �� ����������� ����
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        // ��������������� �������� 
        exp.Play();
        
        // ����������� ������� ������ ����� ������� 
        Destroy(exp.gameObject, 1f);
        // ����������� ���� 
        Destroy(gameObject);
    }
}
