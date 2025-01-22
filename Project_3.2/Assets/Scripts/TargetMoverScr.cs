using UnityEngine;
using UnityEngine.Events;

public class TargetMoverScr : MonoBehaviour
{
    Animator anim;

    public UnityEvent upNext;

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
        upNext.Invoke();
    }

    public void moveTarget(float speed)
    {
        anim.SetInteger("state", 2);
        anim.speed = 1f - speed;
    }


}