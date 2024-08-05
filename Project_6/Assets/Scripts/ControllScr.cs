using UnityEngine;
using UnityEngine.AI;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    
    public LayerMask interactable;
    public LayerMask ground;

    NavMeshAgent agent;
    Animator anim;
    
    int state = 0;

    float detectRadius = 1f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

        // ���� �������� ����������� ������ 0.1: �������, ����� ��� 
        if (agent.velocity.magnitude < 0.3f)
            state = 0;

        if (agent.velocity.magnitude > 0.3f)
            state = 1;

        // �������� ������� � �������
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, interactable);

        // ���� coin ����� � ������
        if (cols.Length > 0 && Input.GetKey(KeyCode.Space))
        {
            agent.SetDestination(transform.position);
            state = 2;
        }
            
        anim.SetInteger("state", state);
    }
    public void attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, interactable);

        if (cols.Length > 0)
        {
            InteractableObj c = cols[0].transform.GetComponent<InteractableObj>();
            if (c != null) 
                c.interact();

            anim.SetInteger("state", 0);
        }
    }
}
