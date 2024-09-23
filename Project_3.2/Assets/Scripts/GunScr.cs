using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunScr : MonoBehaviour
{
    // урон и дальность 
    public float dmg = 10f;
    public float range = 1000f;

    //  скорость стрельбы (10 в секунду) и время до след. выстрела 
    public float fireRate = 2f;
    public float nextShot = 0f;

    // ссылки на камеру, сисетму частиц при выстреле и попадании
    public Camera cam;
    public ParticleSystem flash;
    public ParticleSystem onHit;

    // ссылка на гильзу 
    public GameObject gilza_orig;

    public TMP_Text bulletsTxt;
    int bullets = 10;
    int state;

    // ссылка на аниматор  
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        state = 0;

        // вызов выстрела при нажатии кнопки стрельбы 
        if (Input.GetButton("Fire1") && Time.time >= nextShot && bullets > 0)
        {
            // расчёт времени до след выстрела и выстрел
            nextShot = Time.time + 1 /fireRate;
            
            Shoot();
            bullets -= 1;
            
            state = 1;

            bulletsTxt.text = bullets.ToString();
        }
        if (Input.GetKey(KeyCode.R))
        {
            state = 2;
            bullets = 10;

            bulletsTxt.text = bullets.ToString();
        }

        anim.SetInteger("satate", state);
    }

    void Shoot()
    {
        // воспроизведение вспышки 
        flash.Play();
        
        // создание объекта гильзы 
        GameObject gilza = Instantiate(gilza_orig, transform.position, transform.rotation);
        // создание физического тела гильзы для придания ускорения
        Rigidbody rb_g = gilza.GetComponent<Rigidbody>();
        // направление вылета гильзы
        Vector3 dir = new Vector3(0f, 300f, -100f); 
        // придание ускорения вылету 
        rb_g.AddForce(dir);
        // уничтожение гильзы через 5 секунд 
        Destroy(gilza.gameObject, 5f);


        // если луч из камеры попал во что-то
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // если это что-то имеет тэг "цель"
            if (hit.transform.CompareTag("target"))
                hit.transform.GetComponent<TargetScr>().Hit();

            
            
            // создание и воспроизведение эффекта выстрела в точке попадания 
            ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
            // воспроизведение анимации 
            hitEffect.Play();
            // уничтожение эффекта через секунду 
            Destroy(hitEffect.gameObject, 1f);
        }
    }
}
