using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCrowd : MonoBehaviour
{
    public GameObject player;
    public GameObject[] crowd;

    Vector3 playerPos;

    public int crowdCount;

    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnDrawGizmos()
    {
        playerPos = player.transform.position;
        float indentDown = 0.3f;
        float indentRight = 0.3f;

        int minionsInRow = 1;

        for (int i = 0; i < crowdCount; i++)
        {
            Gizmos.DrawWireSphere(playerPos - player.transform.forward, 0.5f);

        }

        
    }
}
