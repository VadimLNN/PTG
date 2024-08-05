using UnityEngine;

public class SlimeScr : InteractableObj
{
    public GameObject panel;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void interact()
    {
        anim.SetTrigger("IsTalking");
    }

    public void hello()
    {
        panel.SetActive(true);
    }
    public void closePanel()
    {
        panel.SetActive(false);
    }
}
