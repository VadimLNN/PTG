using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour, IItem
{
    [SerializeField] WeaponTypes weaponType;
    [Range(1, 1000)]
    [SerializeField] int amount = 1;

    public void onPickUp(GameObject player)
    {
        if (player.GetComponent<Ammunition>().addAmmo(weaponType, amount))
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            onPickUp(other.gameObject);
    }

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
