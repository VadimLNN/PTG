using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    // �������������� �����, ����� 
    public float hp = 20f;
    float score = 100;
    float scale;

    // ������ �� ������� ������ ������ ��� ������, ��������  
    public ParticleSystem explosion;
    Animator anim;

    // ������ �� ������ � ������ ��� ���� 
    public GunScr gunScr;

    // ����������������� �����
    float lifeTime;

    private void Start()
    {
        anim = GetComponent<Animator>();

        // ����������� ������ ������� ���� ������������,
        // ��� ������ � ������������� ��������� �����
        lifeTime = Random.Range(5f, 60f);
        scale = Random.Range(0.5f, 1.5f);
        
        transform.localScale *= scale;
        //transform.Rotate(Vector3.up, -Mathf.PI / 8, Space.World);

        score /= scale;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            Death();

        score -= Time.deltaTime;
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0 && score > 0)
        {
            Death();
            gunScr.GetScore(score);
            score = -1;
        }
    }

    void Death()
    {
        // ������ �������� ������
        anim.SetBool("isDead", true);
        Invoke("Explosion", 0.4f);
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
