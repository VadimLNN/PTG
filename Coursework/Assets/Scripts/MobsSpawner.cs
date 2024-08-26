using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsSpawner : MonoBehaviour
{
    // ссылки на префабы мобов и куда создавать
    public GameObject[] mobs;
    public GameObject mobsCrowd;

    // зона спавна
    public Vector3 spawnValue;
    
    // время спавна, максимальное и минимальное  
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    
    // время до начала работы спавнера
    public int startWait;

    // состояние спавна 
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

            Instantiate(mobs[Random.Range(0, mobs.Length-1)], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    private void OnDrawGizmos()
    {
        // отрисовка зоны спавна
        Vector3 spawnZonePnt = mobsCrowd.transform.position;

        Vector3 zoneLU = new Vector3(spawnZonePnt.x - spawnValue.x, spawnZonePnt.y, spawnZonePnt.z + spawnValue.z);
        Vector3 zoneRU = new Vector3(spawnZonePnt.x + spawnValue.x, spawnZonePnt.y, spawnZonePnt.z + spawnValue.z);
        Vector3 zoneRD = new Vector3(spawnZonePnt.x + spawnValue.x, spawnZonePnt.y, spawnZonePnt.z - spawnValue.z);
        Vector3 zoneLD = new Vector3(spawnZonePnt.x - spawnValue.x, spawnZonePnt.y, spawnZonePnt.z - spawnValue.z);
            
        Gizmos.DrawLine(zoneLU, zoneRU);
        Gizmos.DrawLine(zoneRU, zoneRD);
        Gizmos.DrawLine(zoneRD, zoneLD);
        Gizmos.DrawLine(zoneLD, zoneLU);
    }
}
