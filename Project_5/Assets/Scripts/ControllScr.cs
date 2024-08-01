using UnityEngine;
using UnityEngine.AI;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    Animator anim;
    int state = 0;
    bool dead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (dead == false)
        {
            // ������� ���
            if (Input.GetMouseButton(0)) 
            {
                // �������� ������� � �����
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                // ���� ������� �����������
                if (Physics.Raycast(ray, out hit, 1000f, ground))
                {
                    // ��������� ����� ���������� ������
                    agent.SetDestination(hit.point);
                }
            }

            // ���� �������� ����������� ������ 0.1: ���, ����� ������� 
            if (agent.velocity.magnitude < 0.1f)
                state = 0;
            else
                state = 1;

            anim.SetInteger("state", state);
        }
        
    }

    public void takeDamage()
    {
        dead = true;                                // ������ 
        agent.SetDestination(transform.position);   // ��������� �������� 
        anim.SetInteger("state", 3);                // ������ �������� ������
        Destroy(this.gameObject, 2);                // ����������� ������� ����� 2 �������
    }
}
