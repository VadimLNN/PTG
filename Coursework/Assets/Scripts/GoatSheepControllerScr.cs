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


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ������������ ��������� ������� � ������
        newPos = transform.position;

        if (oldPos == newPos)
            state = 0;
        else
            state = 1;

        oldPos = newPos;

        // ��������� ��������
        anim.SetInteger("state", state);
    }
}
