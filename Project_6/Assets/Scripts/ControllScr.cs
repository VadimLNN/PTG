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
    bool dead = false;

    float detectRadius = 0.025f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (dead == false)
        {
            state = 0;

            // нажатие ЛКМ
            if (Input.GetMouseButton(0)) 
            {
                // проекция курсора в сцену
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                // если найдено пересечение
                if (Physics.Raycast(ray, out hit, 1000f, ground))
                {
                    // установка точки назначения агенту
                    agent.SetDestination(hit.point);
                }
                
                // если скорость перемещения меньше 0.1: простой, иначе бег 
                if (agent.velocity.magnitude < 0.1f)
                    state = 0;
                else 
                    state = 1;
            }

            // проверка объекта в радиусе
            Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, interactable);

            // если coin попал в радиус
            if (cols.Length > 0)
            {
                //agent.SetDestination(transform.position);
                state = 2;
            }
            
            anim.SetInteger("state", state);
        }
    }
    public void attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, interactable);

        if (cols.Length > 0)
        {
            InteractableObj c = cols[0].transform.GetComponent<InteractableObj>();
            if (c != null) 
                c.interact();
        }
    }
}
