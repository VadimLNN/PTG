using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunLogic : MonoBehaviour
{
    [SerializeField] LayerMask enemy;
    [SerializeField] int buckshot = 8;
    [SerializeField] float spread = 40f;

    public int piercingPower = 2;

    public List<Vector3> shot(Transform firePoint, float damage)
    {
        List<Vector3> directions = new List<Vector3>();

        for(int i = 0; i < buckshot; i++)
        {
            var angle = Random.Range(-spread / 2, spread / 2);
            var quaternion = Quaternion.Euler(0, angle, 0);
            var newDirection = quaternion * firePoint.forward;

            directions.Add(newDirection);
        }

        foreach (var direction in directions)
        {
            RaycastHit[] hits;

            Ray ray = new Ray(firePoint.position, firePoint.forward);
            hits = Physics.RaycastAll(ray, 100f, enemy);

            System.Array.Sort(hits, (x, y) => x.distance.CompareTo(y.distance));

            if (hits.Length > 0)
            {
                for (int i = 0; i < Mathf.Min(piercingPower, hits.Length); i++)
                {
                    Health enemyHp = hits[i].transform.GetComponent<Health>();
                    if (enemyHp != null)
                    {
                        enemyHp.hpDecrease(damage);
                    }
                }
            }
        }

        return directions;
    }
}
