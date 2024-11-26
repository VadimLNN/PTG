using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyFactory : EnemyFactory
{
    [SerializeField] GameObject meleeEnemyPrefab;

    public override IEnemy getItem()
    {
        GameObject meleeEnemy = Instantiate(meleeEnemyPrefab);

        return meleeEnemy.GetComponent<MeleeEnemy>();
    }
}
