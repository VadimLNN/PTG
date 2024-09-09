using UnityEngine;

public class ProjectileMovmentScr : MonoBehaviour
{
    [Range(0.5f, 5f)]
    public float lifeTime = 5;
    [Range(5f, 100f)]
    public float moveSpeed = 15;

    public GameObject explosion;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.position += transform.forward * moveSpeed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
            explode();
    }

    private void explode()
    {
       GameObject t = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(t, 2);
        Destroy(gameObject);
    }
}
