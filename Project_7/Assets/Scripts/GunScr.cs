using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScr : MonoBehaviour
{
    // урон и дальность 
    public float dmg = 10f;
    public float range = 1000f;

    // ссылки на камеру и сисетму частиц
    Camera cam;
    public ParticleSystem flash;

    void Update()
    {
        // вызов выстрела при нажатии кнопки стрельбы 
        if (Input.GetButton("Fire1")) Shoot();    
    }

    void Shoot()
    {
        // воспроизведение вспышки 
        flash.Play();

        // если луч из камеры попал во что-то
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // если это что-то имеет тэг "цель"
            if(hit.transform.CompareTag("target"))
            {
                // получение доступа к скрипту цели
                TargetScr t = hit.transform.GetComponent<TargetScr>();
                // вызов метода урона 
                t.Hit(range);            
            }
        }
    }
}
