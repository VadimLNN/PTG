using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class WanderScr : MonoBehaviour
{
    public NavMeshSurface surface;
    public NavMeshAgent agent;
    NavMeshData data;


    float timer;

    Vector3 destination;

    void Start()
    {
        data = surface.navMeshData;
        agent.destination = SetRandomDest(data.sourceBounds);
        //Debug.Log(data.sourceBounds);
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            agent.destination = SetRandomDest(data.sourceBounds);
            //Debug.Log(data.sourceBounds);
            timer = 0;
        }
    }

    Vector3 SetRandomDest(Bounds bounds)
    {
        var x = Random.Range(bounds.min.x, bounds.max.x);
        var z = Random.Range(bounds.min.z, bounds.max.z);

        destination = new Vector3(x, 1, z);
        return destination;
    }
}