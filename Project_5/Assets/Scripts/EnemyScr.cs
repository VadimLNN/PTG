using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : MonoBehaviour
{
    public Transform[] wayPoints;       // точки маршрута 
    public float detectRadius = 50;     // радиус обнаружния
    int ind = 0;                        // индекс след. точки
    int state = 0;
    public float atkRadius = 2;


    public LayerMask playerLayer;

    Animator anim;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // установка первой точки в качестве пункта назначения
        agent.SetDestination(wayPoints[ind].position);

        anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        // если агент приблизился к текущей точке маршрута
        if (Vector3.Distance(transform.position, wayPoints[ind].position) < 2f)
        {
            // смена точки
            ind++;

            // обнуление индекса при переполнении
            if (ind >= wayPoints.Length) ind = 0;

            // установка новой точки назначения 
            agent.SetDestination(wayPoints[ind].position);
        }

        // если скорость перемещения больше 0.1: бег, иначе простой 
        if (agent.velocity.magnitude < 0.1f)
            state = 0;
        else
            state = 1;

        // проверка наличия игрока в радиусе обнаружения 
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, playerLayer);

        // если игрок попал в радиус
        if (cols.Length > 0)
        {
            if (Vector3.Distance(transform.position, cols[0].transform.position) <= atkRadius)
            {
                Debug.Log("In");
                agent.SetDestination(transform.position);
                state = 2;
            }
            else 
                // направление к игроку
                agent.SetDestination(cols[0].transform.position);
        }
        // иначе
        else 
        // возврат к точке маршрута
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
