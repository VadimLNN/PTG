using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    // характеристики жизни, очков 
    public float hp = 30f;
    float score = 1000;
    float scale = 1;

    // ссылка на систему частиц взрыва при смерти, аниматор  
    public ParticleSystem explosion;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scale = Random.Range(0.1f, 2.5f);
        transform.localScale *= scale;
        score /= scale;
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0) Death();
    }

    void Death()
    {
        // запуск анимации смерти
        anim.SetBool("isDead", true);
        Invoke("Explosion", 1);
    }

    void Explosion()
    {
        // создание копии эффекта взрыва и размещение её по координатам цели
        ParticleSystem exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.transform.localScale *= scale;
        // воспроизведение анимации 
        exp.Play();
        
        // уничтожение системы частиц через секунду 
        Destroy(exp.gameObject, 1f);
        // уничтожение цели 
        Destroy(gameObject);
    }
}
