using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxFactory : ItemFactory
{
    [SerializeField] List<GameObject> ammoBoxes = new List<GameObject>();

    public override IItem getItem()
    {
        GameObject ammoBox = Instantiate(ammoBoxes[Random.Range(0, ammoBoxes.Count)]);

        return ammoBox.GetComponent<AmmoBox>();
    }
}
