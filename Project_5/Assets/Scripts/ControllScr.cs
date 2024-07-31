using UnityEngine;
using UnityEngine.AI;

public class ControllScr : MonoBehaviour
{
    public Camera cam;
    public LayerMask ground;
    NavMeshAgent agent;
    Animator anim;
    int state = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
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
        }

        // если скорость перемещения больше 0.1: бег, иначе простой 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        anim.SetInteger("state", state);
    }
}
