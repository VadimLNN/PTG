using UnityEngine;
using UnityEngine.UI;

public class SpawnerMinonScr : InteractableObj
{
    // ссылка на толпу и префаб 
    public GameObject Minions;
    public GameObject minion;

    // кол-во приспешников, которых можно призвать
    int minionsMax = 10;

    // ограничение спавна приспешников 
    float spawnRate = 10f;
    float nextSpawn = 0f;

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
