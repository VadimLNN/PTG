using UnityEngine;
using UnityEngine.UI;

public class SpawnerMinonScr : InteractableObj
{
    //
    public GameObject Minions;
    public GameObject minion;

    //
    int minionsMax = 10;

    //
    float spawnRate = 10f;
    float nextSpawn = 0f;

    
    /*void Update()
    {

    }*/

    public override void interact()
    {
        SpawnMinion();
    }

    void SpawnMinion()
    {
        if (Time.time >= nextSpawn && minionsMax > 0)
        {
            nextSpawn = Time.time + 1 / spawnRate;
            Instantiate(minion, transform.position, Quaternion.identity, Minions.gameObject.transform);
            minionsMax--;
        }
    }
}
