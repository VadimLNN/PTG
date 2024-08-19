using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinionScr : MonoBehaviour
{
    // ссылка на нав. агента, аниматора 
    public NavMeshAgent agent;
    Animator anim;

    // 
    public LayerMask enemyLayer;

    // параметр состояния и времени на осмотр перед возвращением 
    int state;
    float inspectionTime = 0.5f;

    //
    float atkRadius = 1f;
    int hp = 40;

    // точки для определения состояния простоя или ходьбы 
    Vector3 assignmentPnt;
    Vector3 newPos;
    Vector3 oldPos;

    // состояния "на задании"
    public bool isOnAssignment = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  
    }

    void LateUpdate()
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



        // установка анимации
        anim.SetInteger("state", state);
    }
    
    public void FollowOrder(Vector3 point) 
    {
        assignmentPnt = point;
        
        // пробежка до задания и установка состояния 
        agent.SetDestination(point);
        isOnAssignment = true;
    }
    public void FollowMaster(Vector3 point)
    {
        assignmentPnt = point;
        // преследование мастера
        agent.SetDestination(point);
        isOnAssignment = false;
    }

    public bool GetIsOnAssignment()
    {
        // возвращение состояния на задании
        return isOnAssignment;
    }

    void stopFollowOrder()
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

    public void takeDamage()
    {
        agent.SetDestination(transform.position);   
        anim.SetInteger("state", -1);                
        Destroy(this.gameObject, 1);
    }
}
