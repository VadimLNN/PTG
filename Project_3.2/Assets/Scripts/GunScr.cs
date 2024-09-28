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
    public ParticleSystem flash_2;
    public ParticleSystem onHit;

    // ссылка на гильзу 
    public GameObject gilza_orig;

    public TMP_Text bulletsTxt;
    int bullets = 10;
    int state;
    int state_2;

    // ссылка на аниматор  
    Animator gan_anim_1;
    Animator gan_anim_2;
    public GameObject gun_2;

    bool right_shoot = true;

    private void Start()
    {
        gan_anim_1 = GetComponent<Animator>();
        gan_anim_2 = gun_2.GetComponent<Animator>();
        flash_2 = gun_2.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        state = 0;
        state_2 = 0;

        // вызов выстрела при нажатии кнопки стрельбы 
        if (Input.GetButton("Fire1") && Time.time >= nextShot && bullets > 0)
        {
            // расчёт времени до след выстрела и выстрел
            nextShot = Time.time + 1 /fireRate;
            
            Shoot();
            bullets -= 1;


            if (right_shoot)
                state = 1;
            else
                state_2 = 1;

            if (gun_2.active == true)
                right_shoot = !right_shoot;


            bulletsTxt.text = bullets.ToString();
        }
        if (Input.GetKey(KeyCode.R))
        {
            state = 2;
            state_2 = 2;
        }

        gan_anim_1.SetInteger("satate", state);
        gan_anim_2.SetInteger("state", state_2);
    }

    void Shoot()
    {
        // воспроизведение вспышки 
        if (right_shoot)
            flash.Play();
        else 
            flash_2.Play();
        
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
    public void reload()
    {
        if(gun_2.active == true)
            bullets = 16;
        else 
            bullets = 10;

        bulletsTxt.text = bullets.ToString();
    }
}
