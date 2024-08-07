using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    public float hp = 10f;
    public ParticleSystem explosion;

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0) Death();
    }

    void Death()
    {
        // создание копии эффекта взрыва и размещение её по координатам цели
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        // воспроизведение анимации 
        exp.Play();
        
        // уничтожение системы частиц через секунду 
        Destroy(exp.gameObject, 1f);
        // уничтожение цели 
        Destroy(gameObject);
    }
}
