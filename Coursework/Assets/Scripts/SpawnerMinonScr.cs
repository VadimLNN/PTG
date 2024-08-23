using UnityEngine;

public class SpawnerMinonScr : InteractableObj
{
    public Transform Minions;
    public GameObject minion;
    //MinionCrowd minionCrowd;

    int minionsMax = 10;

    public override void interact()
    {
        if (minionsMax > 0)
        {
            Instantiate(minion, Minions);
            minionsMax--;
        }
    }

    /*void Update()
    {
        
    }*/
}
