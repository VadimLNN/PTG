using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class TargetScr : MonoBehaviour
{
    // характеристики жизни, очков 
    public float hp = 20f;
    float score = 100;
    float scale;

    // ссылка на систему частиц взрыва при смерти, аниматор  
    public ParticleSystem explosion;
    Animator anim;

    // ссылка на оружие и скрипт дл€ него 
    public GunScr gunScr;

    // продолжительность жизни
    float lifeTime;

    private void Start()
    {
        anim = GetComponent<Animator>();

        // случайность решает сколько ещЄ жить скелетончику,
        // его размер и следовательно множитель очков
        lifeTime = Random.Range(5f, 60f);
        scale = Random.Range(0.5f, 2f);
        
        transform.localScale *= scale;
        score /= scale;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
            Death();

        score -= Time.deltaTime;
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
            gunScr.GetScore(score);
            
            //########  ќ—“џЋ№ #######//
            /* */ gunScr = null; /* */       
            //########################//
        }
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
