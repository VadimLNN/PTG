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

            // проверка наличия монет в радиусе обнаружения 
            Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, coinsLayer);

            // если coin попал в радиус
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
        dead = true;                                // смерть 
        agent.SetDestination(transform.position);   // остановка движения 
        anim.SetInteger("state", 3);                // запуск анимации смерти
        Destroy(this.gameObject, 1);                // уничтожение объекта через 2 секунды
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
