using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    public Transform[] wayPoints;       // ����� �������� 
    public float detectRadius = 50;     // ������ ����������
    int ind = 0;                        // ������ ����. �����
    int state = 0;
    public float atkRadius = 2;


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

        // ���� �������� ����������� ������ 0.1: ���, ����� ������� 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        // �������� ������� ������ � ������� ����������� 
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, playerLayer);

        // ���� ����� ����� � ������
        if (cols.Length > 0)
        {
            if (Vector3.Distance(transform.position, cols[0].transform.position) <= atkRadius)
            {
                Debug.Log("In");
                agent.SetDestination(transform.position);
                state = 2;
            }
            else 
                // ����������� � ������
                agent.SetDestination(cols[0].transform.position);
        }
        // �����
        else 
        // ������� � ����� ��������
            agent.SetDestination(wayPoints[ind].position);

        anim.SetInteger("state", state);
    }

    public void attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, atkRadius, playerLayer);

        if (cols.Length > 0)
        {
            ControllScr c = cols[0].transform.GetComponent<ControllScr>();
            if (c != null) c.takeDamage();
        }
    }
}
