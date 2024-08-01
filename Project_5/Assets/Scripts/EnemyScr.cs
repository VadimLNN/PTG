using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    public Transform[] wayPoints;       // ����� �������� 
    public float detectRadius = 50;     // ������ ����������
    int ind = 0;                        // ������ ����. �����
    int state = 0;

    public LayerMask playerLayer;

    Animator anim;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // ��������� ������ ����� � �������� ������ ����������
        agent.SetDestination(wayPoints[ind].position);

        anim = GetComponent<Animator>();
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

        //Debug.Log(cols);
        // ���� ����� ����� � ������
        if (cols.Length > 0)
        // ����������� � ������
            agent.SetDestination(cols[0].transform.position);
        // �����
        else 
        // ������� � ����� ��������
            agent.SetDestination(wayPoints[ind].position);


        // ���� �������� ����������� ������ 0.1: ���, ����� ������� 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        anim.SetInteger("state", state);
    }
}
