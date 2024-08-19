using System.Collections.Generic;
using UnityEngine;

public class MinionCrowd : MonoBehaviour
{
    // ссылки на игрока
    public GameObject player;

    //
    List<Transform> minions = new List<Transform>();

    Vector3 playerPos;

    // кол-во приспешников
    int crowdCount;


    void Start()
    {
        
    }

    void Update()
    {
        // переменная для отслеживания изменений колличества приспешников
        int newCrowdCount = transform.childCount;

        // перепись миньёнов в списке при изменении их колличества
        if (newCrowdCount != crowdCount)
        {
            minions.Clear();
            for(int i = 0; i < transform.childCount; i++)
                minions.Add(transform.GetChild(i));
        }
        
        // число миньёнов
        crowdCount = minions.Count;

        // список мест прихвостней 
        List<Vector3> places = new List<Vector3>();

        // позиция чуть позади игрока 
        playerPos = player.transform.position - player.transform.forward*0.7f;
        
        // параметры смещения мест вниз и в сторону 
        float indentDown = 0.4f;
        float indentRight = 0.42f;

        // параметры и алгоритм построения
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
            else
            {
                currentRow = crowdCount - currentMinions;
                for (float j = -(currentRow - 1) / 2f; j <= (currentRow - 1) / 2f; j++)
                    places.Add(playerPos - player.transform.forward * indentDown * (previousRow + 1)
                                                    + player.transform.right * indentRight * j);
            }
            currentMinions += currentRow;
            previousRow = currentRow;
        }

        // расстановка прихвостней по местам
        for (int i = 0; i < crowdCount; i++)
        {
            if (minions[i].GetComponent<MinionScr>().GetIsOnAssignment() == false)
                minions[i].GetComponent<MinionScr>().FollowMaster(places[i]);
        }

    }

    public void GoForward()
    {
        bool minionSent = false;
        for (int i = 0; i < crowdCount; i++)
        {
            if (minions[i].GetComponent<MinionScr>().GetIsOnAssignment() == false)
            {
                // вычисление точки перед игроком и приказ посылающий миньёна вперёд
                Vector3 point = player.transform.position + player.transform.forward * 10;
                
                minions[i].GetComponent<MinionScr>().FollowOrder(point);

                minionSent = true;
            }

            if (minionSent == true)
                break;
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
