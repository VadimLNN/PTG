using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScr : MonoBehaviour
{
    // урон и дальность 
    public float dmg = 10f;
    public float range = 1000f;

    //  скорость стрельбы (10 в секунду) и время до след. выстрела 
    public float fireRate = 10f;
    public float nextShot = 0f;

    // ссылки на камеру, сисетму частиц при выстреле и попадании
    public Camera cam;
    public ParticleSystem flash;
    public ParticleSystem onHit;

    // ссылка на гильзу 
    public GameObject gilza_orig;
    void Update()
    {
        // вызов выстрела при нажатии кнопки стрельбы 
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            // расчёт времени до след выстрела и выстрел
            nextShot = Time.time + 1 /fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // воспроизведение вспышки 
        flash.Play();
        
        // создание объекта гильзы 
        GameObject gilza = Instantiate(gilza_orig, transform.position, transform.rotation);
        // создание физического тела гильзы для придания ускорения
        Rigidbody rb_g = gilza.GetComponent<Rigidbody>();
        rb_g.AddForce(Vector3.up * 400f);
        // уничтожение эффекта через 5 секунд 
        Destroy(gilza.gameObject, 5f);


        // если луч из камеры попал во что-то
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // если это что-то имеет тэг "цель"
            if (hit.transform.CompareTag("target"))
            {
                // получение доступа к скрипту цели
                TargetScr t = hit.transform.GetComponent<TargetScr>();
                // вызов метода получения урона 
                t.Hit(range);            
            }

            // создание и воспроизведение эффекта выстрела в точке попадания 
            ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
            // воспроизведение анимации 
            hitEffect.Play();
            // уничтожение эффекта через секунду 
            Destroy(hitEffect.gameObject, 1f);
        }
    }
}
