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

    // кол-во здоровья
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
            // отслеживание состояний простоя и ходьбы
            newPos = transform.position;

            if (oldPos == newPos)
                state = 0;
            else
                state = 1;

            oldPos = newPos;
        }

        // установка анимации
        anim.SetInteger("state", state);
    }

    public void takeDamage(int gamage)
    {
        hp -= gamage;
    }
}
