using Unity.VisualScripting;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    Animator anim;

    public float deletRate = 2f;
    public float nextDelet = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (transform.parent != null)
            if (transform.parent.childCount > 2 && Time.time >= nextDelet)
            {
                nextDelet = Time.time + 1 / deletRate;
                
                Destroy(transform.parent.GetChild(1));
            }
    }

    public void Hit()
    {
        GameObject scoreBoard = GameObject.FindWithTag("ScoreBoard");
        if (scoreBoard != null)
            scoreBoard.GetComponent<ScoreScr>().scoreUp(1);

        GetComponent<MeshDestroy>().DestroyThis();
    }
}
