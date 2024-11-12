using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TracerSystem : MonoBehaviour
{
    public GameObject tracerPrefab;
    public int poolSize;
    public int maxPoolSize;

    IObjectPool<GameObject> tracers;

    void Start() =>
        tracers = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, poolSize, maxPoolSize);

    GameObject CreatePooledItem()
    {
        GameObject tracer = Instantiate(tracerPrefab);
        tracer.GetComponent<TracerScr>().pool = tracers;
        return tracer;
    }

    void OnReturnedToPool(GameObject tracer) =>
        tracer.gameObject.SetActive(false);   
    
    void OnTakeFromPool(GameObject tracer) =>
        tracer.gameObject.SetActive(true);   
    
    void OnDestroyPoolObject(GameObject tracer) =>
        Destroy(tracer);

    public void createTracer(Vector3 position, Vector3 direction)
    {
        GameObject tracer = tracers.Get();
        tracer.GetComponent<TracerScr>().setPoints(position, direction);
    }
}
