using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractEnemy : MonoBehaviour, IEnemy
{
    protected Transform player;
    public Health enemyHP;

    [Range(1, 60)]
    public float updatesPerSecond = 10;
    [Range(1, 360)]
    public float rotationSpeed = 120;

    NavMeshAgent agent;
    Animator animator;

    protected bool stunned = false;
    protected bool dead = false;

    public Transform Player
    {
        get { return player; }
        set { player = value; }
    }

    public Health EnemyHP { get { return enemyHP; } }

    protected StateMachine stateMachine;

    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        stateMachine = new StateMachine();

        StartCoroutine(updateCall());
    }

    IEnumerator updateCall()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/updatesPerSecond);
        
            updateState();

            if (dead) break;
        }
    }

    public abstract void updateState();
    public virtual void moveTo(Vector3 point)
    {
        agent.SetDestination(point);
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
    public virtual void rotateTo(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed / updatesPerSecond);
    }
    public virtual void attack(bool state)
    {
        animator.SetBool("attack", state);
    }
    public virtual void stunBegin()
    {
        stunned = true;
        animator.SetTrigger("getHit");
    }
    public virtual void stunEnd()
    {
        stunned= false;
    }
    public virtual void stop(bool state)
    {
        agent.isStopped = state;
    }
    public void positionAndRotation(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
    }
    public virtual void death()
    {
        dead = true;
        animator.SetTrigger("death");
        stop(true);

        ScoreScr scorePnl = GameObject.FindWithTag("scorePnl").transform.GetComponent<ScoreScr>();
        scorePnl.scoreUp();

        StartCoroutine(despawn());
    }
    IEnumerator despawn()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
