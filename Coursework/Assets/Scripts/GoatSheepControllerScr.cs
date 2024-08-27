using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatSheepControllerScr : MonoBehaviour
{
    // ссылка на аниматора
    Animator anim;

    // точки для определения состояния простоя или ходьбы 
    Vector3 oldPos;
    Vector3 newPos;

    // параметры состония
    int state;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // отслеживание состояний простоя и ходьбы
        newPos = transform.position;

        if (oldPos == newPos)
            state = 0;
        else
            state = 1;

        oldPos = newPos;

        // установка анимации
        anim.SetInteger("state", state);
    }
}
