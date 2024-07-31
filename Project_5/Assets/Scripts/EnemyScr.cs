using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    // точки маршрута 
    public Transform[] wayPoints;
    // индекс след. точки
    int ind = 0;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

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
    }
}
