using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class MinionScr : MonoBehaviour
{

    NavMeshAgent agent;
    Rigidbody rb;
    int state;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();  
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        state = 0;

        Debug.Log(rb.velocity.magnitude);

        if (rb.velocity.magnitude > 1f)
            state = 1;

        anim.SetInteger("state", state);
    }
    
    public void GoForvard(Vector3 point) 
    {
        agent.SetDestination(point);
    }
}
