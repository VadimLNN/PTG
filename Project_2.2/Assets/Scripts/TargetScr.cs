using UnityEngine;

public class TargetScr : MonoBehaviour
{
    [Range(5f, 100f)]
    public float fallSpeed = 1;

    Rigidbody rb;

    public int points = 1;
    public GameObject explosion;

    public DestructionEffect destrEff;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.position += -transform.up * fallSpeed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        GameObject scoreBoard = GameObject.FindWithTag("ScoreBoard");
        if (scoreBoard != null)
            scoreBoard.GetComponent<ScoreBoardScr>().scoreUp(points);

        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("houses"))
        {
            GameObject scoreBoard = GameObject.FindWithTag("ScoreBoard");
            if (scoreBoard != null)
                scoreBoard.GetComponent<ScoreBoardScr>().scoreDown(points);

            destrEff.playDestructionEffect();
        }
    }
}
