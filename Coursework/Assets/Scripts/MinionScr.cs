using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinionScr : MonoBehaviour
{

    NavMeshAgent agent;
    int state;
    Animator anim;

    Vector3 oldPos;
    Vector3 newPos;

    bool isOnAssignment = false;

    float inspectionTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        
        if (oldPos == newPos)
        {
            state = 0;

            inspectionTime -= Time.deltaTime;
            if (inspectionTime <= 0 && isOnAssignment == true)
                isOnAssignment = false;
        }
        else
        {
            state = 1;
            inspectionTime = 2f;
        }
            

        oldPos = newPos;



        anim.SetInteger("state", state);
    }
    
    public void FollowOrder(Vector3 point) 
    {
        agent.SetDestination(point);
        isOnAssignment = true;
    }
    public void FollowMaster(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public bool GetIsOnAssignment()
    {
        return isOnAssignment;
    }

    void stopFollowOrder()
    {
        isOnAssignment = false;
    }
}
