using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinionScr : MonoBehaviour
{
    // ссылка на нав. агента и аниматора 
    NavMeshAgent agent;
    Animator anim;

    // параметр состояния и времени на осмотр перед возвращением 
    int state;
    float inspectionTime = 2f;
    
    // точки для определения состояния простоя или ходьбы 
    Vector3 oldPos;
    Vector3 newPos;

    // состояния "на задании"
    bool isOnAssignment = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  
    }

    void Update()
    {
        // новая точка для сравнения со старым положением
        newPos = transform.position;
        
        //  если старая точка и новая равны = простой
        if (oldPos == newPos)
        {
            state = 0;

            // отсчёт времени до прекращения состояния "на задании" 
            inspectionTime -= Time.deltaTime;
            if (inspectionTime <= 0 && isOnAssignment == true)
                isOnAssignment = false;
        }
        else
        {
            state = 1;
            // время осмотра 
            inspectionTime = 2f;
        }
            
        oldPos = newPos;


        // установка анимации
        anim.SetInteger("state", state);
    }
    
    public void FollowOrder(Vector3 point) 
    {
        // пробежка до задания и установка состояния 
        agent.SetDestination(point);
        isOnAssignment = true;
    }
    public void FollowMaster(Vector3 point)
    {
        // преследование мастера
        agent.SetDestination(point);
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
}
