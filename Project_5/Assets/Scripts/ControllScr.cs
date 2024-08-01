using UnityEngine;
using UnityEngine.AI;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    
    public LayerMask ground;
    public LayerMask coinsLayer;
    
    NavMeshAgent agent;
    Animator anim;
    
    int state = 0;
    bool dead = false;

    float detectRadius = 1f;


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
                
                // ���� �������� ����������� ������ 0.1: �������, ����� ��� 
                if (agent.velocity.magnitude < 0.1f)
                    state = 0;
                else
                    state = 1;
            }

            // �������� ������� ����� � ������� ����������� 
            Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, coinsLayer);

            // ���� coin ����� � ������
            if (cols.Length > 0)
            {

                state = 2;
                //agent.SetDestination(cols[0].transform.position);
            }
            
            anim.SetInteger("state", state);
        }
    }

    public void takeDamage()
    {
        Debug.LogError("YOU DEAD");
        dead = true;                                // ������ 
        agent.SetDestination(transform.position);   // ��������� �������� 
        anim.SetInteger("state", 3);                // ������ �������� ������
        Destroy(this.gameObject, 1);                // ����������� ������� ����� 2 �������
    }

    public void attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, coinsLayer);

        if (cols.Length > 0)
        {
            CoinScr c = cols[0].transform.GetComponent<CoinScr>();
            if (c != null) c.takeDamage();
        }
    }
}
