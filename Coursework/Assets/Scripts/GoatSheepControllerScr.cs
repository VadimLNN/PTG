using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatSheepControllerScr : MonoBehaviour
{
    // ������ �� ���������
    Animator anim;

    // ����� ��� ����������� ��������� ������� ��� ������ 
    Vector3 oldPos;
    Vector3 newPos;

    // ��������� ��������
    int state;

    // ���-�� ��������
    public int hp = 15;

    bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            //agent.SetDestination(transform.position);
            state = 1;
            isDead = true;
            Destroy(this.gameObject, 2);
        }

        if (isDead == false)
        {
            // ������������ ��������� ������� � ������
            newPos = transform.position;

            if (oldPos == newPos)
                state = 0;
            else
                state = 1;

            oldPos = newPos;
        }

        // ��������� ��������
        anim.SetInteger("state", state);
    }

    public void takeDamage(int gamage)
    {
        hp -= gamage;
    }
}
