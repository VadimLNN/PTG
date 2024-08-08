using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    // �������������� �����, ����� 
    public float hp = 30f;
    float score = 100;
    float scale = 1;

    // ������ �� ������� ������ ������ ��� ������, ��������  
    public ParticleSystem explosion;
    Animator anim;

    // 
    public GameObject gun;
    GunScr gunScore;

    private void Start()
    {
        gunScore = gun.GetComponent<GunScr>();

        anim = GetComponent<Animator>();
        scale = Random.Range(0.1f, 2.5f);
        transform.localScale *= scale;
        score /= scale;
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
            gunScore.GetScore(score);
            
            //######## ������� #######//
            /* */ gunScore = null; /* */        }
            //########################//
    }

    void Death()
    {
        // ������ �������� ������
        anim.SetBool("isDead", true);
        Invoke("Explosion", 1);
    }

    void Explosion()
    {
        // �������� ����� ������� ������ � ���������� � �� ����������� ����
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.transform.localScale *= scale;
        // ��������������� �������� 
        exp.Play();
        
        // ����������� ������� ������ ����� ������� 
        Destroy(exp.gameObject, 1f);
        // ����������� ���� 
        Destroy(gameObject);
    }
}
