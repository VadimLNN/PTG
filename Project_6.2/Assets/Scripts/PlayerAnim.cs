using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    void Start() => anim = GetComponent<Animator>();
    
    public void death()
    {
        anim.SetTrigger("death");
        StartCoroutine(despawn());
    }
    IEnumerator despawn()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
