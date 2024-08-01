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

            // если скорость перемещения меньше 0.1: бег, иначе простой 
            if (agent.velocity.magnitude < 0.1f)
                state = 0;
            else
                state = 1;

            anim.SetInteger("state", state);
        }
        
    }

    public void takeDamage()
    {
        dead = true;                                // смерть 
        agent.SetDestination(transform.position);   // остановка движения 
        anim.SetInteger("state", 3);                // запуск анимации смерти
        Destroy(this.gameObject, 2);                // уничтожение объекта через 2 секунды
    }
}
