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

    public void Hit()
    {
        GameObject scoreBoard = GameObject.FindWithTag("ScoreBoard");
        if (scoreBoard != null)
            scoreBoard.GetComponent<ScoreScr>().scoreUp(1);

        transform.parent.GetComponent<TargetMoverScr>().downTarget();

        GetComponent<MeshDestroy>().DestroyThis();
    }
}
