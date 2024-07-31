using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    public Transform[] wayPoints;       // ����� �������� 
    int ind = 0;                        // ������ ����. �����
    public float detectRadius = 50;     // ������ ����������
    Animator anim;
    int state = 0;

    public LayerMask playerLayer;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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
    

        // �������� ������� ������ � ������� ����������� 
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, playerLayer);
        
        // ���� ����� ����� � ������
        //      ����������� � ������ 
        // �����
        //      ������� � ����� ��������
        if (cols.Length > 0)
            agent.SetDestination(cols[0].transform.position);
        else 
            agent.SetDestination(wayPoints[ind].position);

        // ���� �������� ����������� ������ 0.1: ���, ����� ������� 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        anim.SetInteger("state", state);
    }
}
