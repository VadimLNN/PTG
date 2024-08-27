using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class WanderScr : MonoBehaviour
{
    public NavMeshSurface surface;
    public NavMeshAgent agent;

    float timer;

    Vector3 destination;

    public bool isWander = true;

    void Start()
    {
        agent.destination = SetRandomDest(surface.navMeshData.sourceBounds);
        timer = 0;

    }

    void Update()
    {
        if (isWander)
        {   
            timer += Time.deltaTime;
            if (timer > 5)
            {
                agent.destination = SetRandomDest(surface.navMeshData.sourceBounds);
                timer = 0;
            }
        }
    }

    Vector3 SetRandomDest(Bounds bounds)
    {
        var x = Random.Range(transform.position.x - 7, transform.position.x + 7);
        var z = Random.Range(transform.position.z - 7, transform.position.z + 7);

        destination = new Vector3(x, transform.position.y, z);
        return destination;
    }
}