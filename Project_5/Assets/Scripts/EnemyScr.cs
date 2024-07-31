using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    public Transform[] wayPoints;       // точки маршрута 
    int ind = 0;                        // индекс след. точки
    public float detectRadius = 50;     // радиус обнаружния
    Animator anim;
    int state = 0;

    public LayerMask playerLayer;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // установка первой точки в качестве пункта назначения
        agent.SetDestination(wayPoints[ind].position);
    }

    void LateUpdate()
    {
        // если агент приблизился к текущей точке маршрута
        if (Vector3.Distance(transform.position, wayPoints[ind].position) < 2f)
        {
            // смена точки
            ind++;

            // обнуление индекса при переполнении
            if (ind >= wayPoints.Length) ind = 0;

            // установка новой точки назначения 
            agent.SetDestination(wayPoints[ind].position);
        }
    

        // проверка наличия игрока в радиусе обнаружения 
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, playerLayer);
        
        // если игрок попал в радиус
        //      направление к игроку 
        // иначе
        //      возврат к точке маршрута
        if (cols.Length > 0)
            agent.SetDestination(cols[0].transform.position);
        else 
            agent.SetDestination(wayPoints[ind].position);

        // если скорость перемещения больше 0.1: бег, иначе простой 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        anim.SetInteger("state", state);
    }
}
