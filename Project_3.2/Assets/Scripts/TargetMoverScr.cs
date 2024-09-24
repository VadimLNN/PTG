using UnityEngine;

public class TargetMoverScr : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void upTarget()
    {
        anim.SetInteger("state", 1);
    }

    public void downTarget()
    {
        anim.SetInteger("state", 0);
    }

    public void moveTarget(float speed)
    {
        anim.SetInteger("state", 2);
        anim.speed = 1f - speed;
    }


}