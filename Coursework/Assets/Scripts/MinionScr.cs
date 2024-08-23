using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinionScr : MonoBehaviour
{
    // ссылка на нав. агента, аниматора 
    public NavMeshAgent agent;
    Animator anim;

    // слой врагов 
    public LayerMask enemyLayer;

    // параметр состояния и времени на осмотр перед возвращением 
    int state;
    float inspectionTime = 0.5f;

    // радиус атаки, замечания, здоровья
    float atkRadius = 0.7f;
    float detectRadius = 10f;
    int hp = 40;

    // точки для определения состояния простоя или ходьбы 
    Vector3 assignmentPnt;

    // состояния "на задании", "смерти"
    public bool isOnAssignment = false;
    bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  
    }

    void LateUpdate()
    {
        if (hp <= 0)
        {
            agent.SetDestination(transform.position);
            state = -1;
            isDead = true;
            Destroy(this.gameObject, 5);
        }

        if (isDead == false)
        {
            Vector3 posNow = transform.position;
            float razbros = 0.1f;
            if (assignmentPnt.x - razbros <= posNow.x && posNow.x <= assignmentPnt.x + razbros &&
                assignmentPnt.z - razbros <= posNow.z && posNow.z <= assignmentPnt.z + razbros)
            {
                state = 0;

                // отсчёт времени до прекращения состояния "на задании" 
                if (state == 0 && isOnAssignment == true)
                {
                    inspectionTime -= Time.deltaTime;
                }

                if (inspectionTime <= 0 && isOnAssignment == true)
                {
                    isOnAssignment = false;
                    inspectionTime = 0.5f;
                }
            }
            else
                state = 1;


            // отслеживание врага
            Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, enemyLayer);

            // если враг в радиусе 
            if (cols.Length > 0 && isOnAssignment == true)
            {
                if (Vector3.Distance(transform.position, cols[0].transform.position) <= atkRadius)
                {
                    state = 2;
                    agent.SetDestination(transform.position);
                }
                else
                    agent.SetDestination(cols[0].transform.position);
            }
        }


        // установка анимации
        anim.SetInteger("state", state);
    }
    
    public void FollowOrder(Vector3 point) 
    {
        if (isDead == false)
        {
            assignmentPnt = point;
        
            // пробежка до задания и установка состояния 
            agent.SetDestination(point);
            isOnAssignment = true;
        }
    }
    public void FollowMaster(Vector3 point)
    {
        if (isDead == false)
        {
            assignmentPnt = point;
            // преследование мастера
            agent.SetDestination(point);
            isOnAssignment = false;
        }
    }

    public bool GetIsOnAssignment()
    {
        // возвращение состояния на задании
        return isOnAssignment;
    }
    public void stopFollowOrder()
    {
        // прекрашение состояния "на задании"
        isOnAssignment = false;
    }


    void attack()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, atkRadius, enemyLayer);

        if (cols.Length > 0)
        {
            EnemyScr c = cols[0].transform.GetComponent<EnemyScr>();
            if (c != null) c.takeDamage(10);
        }
    }
    public void takeDamage(int gamage)
    {
        hp -= gamage;
    }

    private void OnDrawGizmos()
    {
        // радиус атаки
        //Gizmos.DrawWireSphere(transform.position, atkRadius);
        //Gizmos.DrawWireSphere(transform.position, detectRadius);

    }
}
