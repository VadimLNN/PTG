using UnityEngine;

public class DestructionEffect : MonoBehaviour
{
    public float effectDuratione = 1;
    public GameObject destructionEffect;

    public void playDestructionEffect()
    {
        GameObject t = Instantiate(destructionEffect, transform.position, Quaternion.identity);
        Destroy(t, effectDuratione);
        Destroy(gameObject);
    }
}
