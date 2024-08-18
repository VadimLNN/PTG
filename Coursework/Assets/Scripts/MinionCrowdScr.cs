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
        playerPos = player.transform.position - player.transform.forward*0.7f;
        float indentDown = 0.37f;
        float indentRight = 0.42f;

        int previousRow = 0;
        int currentRow = 0;
        int currentMinions = 0;


        while (currentMinions < crowdCount)
        {
            currentRow = previousRow + 1;
            
            if (currentRow + currentMinions <= crowdCount)
                for (float j = -(currentRow - 1 ) / 2f; j <= (currentRow - 1) / 2f; j++)
                {
                    Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * currentRow
                                                    + player.transform.right * indentRight * j, 0.2f);
                }
            else
            {
                currentRow = crowdCount - currentMinions;
                for (float j = -(currentRow - 1) / 2f; j <= (currentRow - 1) / 2f; j++)
                {
                    Gizmos.DrawWireSphere(playerPos - player.transform.forward * indentDown * (previousRow+1)
                                                    + player.transform.right * indentRight * j, 0.2f);
                }
            }
            currentMinions += currentRow;
            previousRow = currentRow;

           
        }




    }
}
