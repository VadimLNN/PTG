using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    // характеристики жизни, очков 
    public float hp = 30f;
    float score = 100;
    float scale = 1;

    // ссылка на систему частиц взрыва при смерти, аниматор  
    public ParticleSystem explosion;
    Animator anim;

    // 
    public GameObject gun;
    GunScr gunScore;

    private void Start()
    {
        gunScore = gun.GetComponent<GunScr>();

        anim = GetComponent<Animator>();
        scale = Random.Range(0.1f, 2.5f);
        transform.localScale *= scale;
        score /= scale;
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
            gunScore.GetScore(score);
            
            //########  ќ—“џЋ№ #######//
            /* */ gunScore = null; /* */        }
            //########################//
    }

    void Death()
    {
        // запуск анимации смерти
        anim.SetBool("isDead", true);
        Invoke("Explosion", 1);
    }

    void Explosion()
    {
        // создание копии эффекта взрыва и размещение еЄ по координатам цели
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
