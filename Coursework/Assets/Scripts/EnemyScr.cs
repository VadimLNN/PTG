using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScr : InteractableObj
{
    Animator anim;
    NavMeshAgent agent;
    public Transform[] wayPoints;
    float detectRadius = 10;
    float atkRadius = 0.8f;

    int state;
    int ind = 0;

    public LayerMask playerLayer;
    public LayerMask minionLayer;

    Vector3 oldPos;
    Vector3 newPos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.SetDestination(wayPoints[ind].position);
    }

    void Update()
    {
        //
        if (Vector3.Distance(transform.position, wayPoints[ind].position) < 2f)
        {
            ind++;

            if (ind >= wayPoints.Length) ind = 0;

            agent.SetDestination(wayPoints[ind].position);
        }

        newPos = transform.position;

        if (oldPos == newPos)
        {
            state = 0;
        }
        else
        {
            state = 1;
        }


        oldPos = newPos;

        anim.SetInteger("state", state);
    }
    public override void interact()
    {
        anim.SetInteger("state", 2);

        Collider[] colsP = Physics.OverlapSphere(transform.position, detectRadius, playerLayer);
        Collider[] colsM = Physics.OverlapSphere(transform.position, detectRadius, minionLayer);

        if (colsP.Length > 0 || colsM.Length > 0)
        {
            if (Vector3.Distance(transform.position, colsP[0].transform.position) <= atkRadius)
            {
                agent.SetDestination(transform.position);
                state = 3;
            }
            else
                agent.SetDestination(colsP[0].transform.position);
        }
        else
            agent.SetDestination(wayPoints[ind].position);
    }

    public void dead()
    {
        Destroy(this.gameObject, 2);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.DrawWireSphere(transform.position, atkRadius);
    }
}
