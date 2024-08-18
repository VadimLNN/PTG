using System.Collections.Generic;
using UnityEngine;

public class MinionCrowd : MonoBehaviour
{
    // ссылки на игрока
    public GameObject player;

    //
    List<Transform> minions = new List<Transform>();

    Vector3 playerPos;

    // ����� �������� � ����� 
    int crowdCount;


    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
            minions.Add(transform.GetChild(i));
    }

    void Update()
    {

        

        crowdCount = minions.Count;

        List<Vector3> places = new List<Vector3>();

        playerPos = player.transform.position - player.transform.forward*0.7f;
        float indentDown = 0.4f;
        float indentRight = 0.42f;

        int previousRow = 0;
        int currentRow = 0;
        int currentMinions = 0;

        while (currentMinions < crowdCount)
        {
            currentRow = previousRow + 1;
            
            if (currentRow + currentMinions <= crowdCount)
                for (float j = -(currentRow - 1 ) / 2f; j <= (currentRow - 1) / 2f; j++)
                    places.Add(playerPos - player.transform.forward * indentDown * currentRow
                                                    + player.transform.right * indentRight * j);
                    /*Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * currentRow
                                                    + player.transform.right * indentRight * j, 0.2f);*/
            else
            {
                currentRow = crowdCount - currentMinions;
                for (float j = -(currentRow - 1) / 2f; j <= (currentRow - 1) / 2f; j++)
                    places.Add(playerPos - player.transform.forward * indentDown * (previousRow + 1)
                                                    + player.transform.right * indentRight * j);
                /*Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * (previousRow+1)
                                                + player.transform.right * indentRight * j, 0.2f);*/
            }
            currentMinions += currentRow;
            previousRow = currentRow;
        }

        for (int i = 0; i < crowdCount; i++)
        {
            Debug.Log(minions[i].name);
            minions[i].position = places[i];
            Debug.Log(places[i]);
        }

    }
    
    private void OnDrawGizmos()
    {
        playerPos = player.transform.position - player.transform.forward*0.7f;
        float indentDown = 0.4f;
        float indentRight = 0.42f;

        int previousRow = 0;
        int currentRow = 0;
        int currentMinions = 0;

        while (currentMinions < crowdCount)
        {
            currentRow = previousRow + 1;
            
            if (currentRow + currentMinions <= crowdCount)
                for (float j = -(currentRow - 1 ) / 2f; j <= (currentRow - 1) / 2f; j++)
                    Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * currentRow
                                                    + player.transform.right * indentRight * j, 0.2f);
            else
            {
                currentRow = crowdCount - currentMinions;
                for (float j = -(currentRow - 1) / 2f; j <= (currentRow - 1) / 2f; j++)
                    Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * (previousRow+1)
                                                    + player.transform.right * indentRight * j, 0.2f);
            }
            currentMinions += currentRow;
            previousRow = currentRow;

           
        }




    }
}
