using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    // ����� �������� 
    public Transform[] wayPoints;
    // ������ ����. �����
    int ind = 0;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // ��������� ������ ����� � �������� ������ ����������
        agent.SetDestination(wayPoints[ind].position);
    }

    void LateUpdate()
    {
        // ���� ����� ����������� � ������� ����� ��������
        if (Vector3.Distance(transform.position, wayPoints[ind].position) < 2f)
        {
            // ����� �����
            ind++;

            // ��������� ������� ��� ������������
            if (ind >= wayPoints.Length) ind = 0;

            // ��������� ����� ����� ���������� 
            agent.SetDestination(wayPoints[ind].position);
        }
    }
}
