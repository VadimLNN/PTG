using UnityEngine;

public class SlimeScr : InteractableObj
{
    public GameObject panel;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        panel.SetActive(false);
    }

    public override void interact()
    {
        anim.SetInteger("state", 1);
    }

    public void hello()
    {
        panel.SetActive(true);
        anim.SetInteger("state", 2);
    }
    public void closePanel()
    {
        panel.SetActive(false);
        anim.SetInteger("state", 0);
    }
}
