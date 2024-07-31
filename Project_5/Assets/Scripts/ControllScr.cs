using UnityEngine;
using UnityEngine.AI;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void LateUpdate()
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

        if (agent.velocity.magnitude > 0.1f)
            anim.SetInteger("state", 1);
        else
            anim.SetInteger("state", 0);
    }
}
