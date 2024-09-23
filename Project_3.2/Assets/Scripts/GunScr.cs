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
    public ParticleSystem onHit;

    // ������ �� ������ 
    public GameObject gilza_orig;

    public TMP_Text bulletsTxt;
    int bullets = 10;
    int state;

    // ������ �� ��������  
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        state = 0;

        // ����� �������� ��� ������� ������ �������� 
        if (Input.GetButton("Fire1") && Time.time >= nextShot && bullets > 0)
        {
            // ������ ������� �� ���� �������� � �������
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
        // ��������������� ������� 
        flash.Play();
        
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
}
