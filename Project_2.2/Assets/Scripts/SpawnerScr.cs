using System.Collections;
using UnityEngine;

public class SpawnerScr : MonoBehaviour
{
    public float spawnRate = 2f;
    public float leftBorder = -20;
    public float rightBorder = 20;

    public GameObject target;
    
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            float shift = Random.Range(leftBorder, rightBorder);
            Vector3 pos = transform.position;
            pos.z += shift;

            Instantiate(target, pos, Quaternion.identity);
        }
    }
}
