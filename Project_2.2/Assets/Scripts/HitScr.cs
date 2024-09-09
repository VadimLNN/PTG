using UnityEngine;

public class HitScr : MonoBehaviour
{
    [Range(0.5f, 50f)]
    public float explosionRadius = 5;

    public GameObject explosion;

    public LayerMask bomo_layer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("houses"))
        {
            GameObject scoreBoard = GameObject.FindWithTag("ScoreBoard");
            if (scoreBoard != null)
                scoreBoard.GetComponent<ScoreBoardScr>().scoreDown(1);
        }
        else if (!other.CompareTag("Player"))
        {
            dealDamage();
            explode();
        }
    }

    void dealDamage()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, bomo_layer);

        foreach (Collider col in cols)
            col.transform.GetComponent<TargetScr>().TakeDamage();
    }

    void explode()
    {
        GameObject t = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(t, 2);
        Destroy(gameObject);
    }
}
