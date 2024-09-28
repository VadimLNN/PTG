using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunScr : MonoBehaviour
{
    // ���� � ��������� 
    public float dmg = 10f;
    public float range = 1000f;

    //  �������� �������� (10 � �������) � ����� �� ����. �������� 
    public float fireRate = 2f;
    public float nextShot = 0f;

    // ������ �� ������, ������� ������ ��� �������� � ���������
    public Camera cam;
    public ParticleSystem flash;
    public ParticleSystem flash_2;
    public ParticleSystem onHit;

    // ������ �� ������ 
    public GameObject gilza_orig;

    public TMP_Text bulletsTxt;
    int bullets = 10;
    int state;
    int state_2;

    // ������ �� ��������  
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

        // ����� �������� ��� ������� ������ �������� 
        if (Input.GetButton("Fire1") && Time.time >= nextShot && bullets > 0)
        {
            // ������ ������� �� ���� �������� � �������
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
        // ��������������� ������� 
        if (right_shoot)
            flash.Play();
        else 
            flash_2.Play();
        
        // �������� ������� ������ 
        GameObject gilza = Instantiate(gilza_orig, transform.position, transform.rotation);
        // �������� ����������� ���� ������ ��� �������� ���������
        Rigidbody rb_g = gilza.GetComponent<Rigidbody>();
        // ����������� ������ ������
        Vector3 dir = new Vector3(0f, 300f, -100f); 
        // �������� ��������� ������ 
        rb_g.AddForce(dir);
        // ����������� ������ ����� 5 ������ 
        Destroy(gilza.gameObject, 5f);


        // ���� ��� �� ������ ����� �� ���-��
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            // ���� ��� ���-�� ����� ��� "����"
            if (hit.transform.CompareTag("target"))
                hit.transform.GetComponent<TargetScr>().Hit();

            
            
            // �������� � ��������������� ������� �������� � ����� ��������� 
            ParticleSystem hitEffect = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal));
            // ��������������� �������� 
            hitEffect.Play();
            // ����������� ������� ����� ������� 
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
