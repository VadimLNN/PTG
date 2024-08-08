using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScr : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 spawnValue;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 1, Random.Range(-spawnValue.z, spawnValue.z));

            Instantiate(enemy, spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
