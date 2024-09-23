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

    public void moveTarget()
    {
        anim.SetInteger("state", 2);
    }
}