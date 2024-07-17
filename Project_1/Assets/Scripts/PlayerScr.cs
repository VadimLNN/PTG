using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScr : MonoBehaviour
{
    // ссылки на объекты и UI
    public Camera cam;     
    public GameObject deadfloor;
    public GameObject player;

    public Slider speedSlider;

    LineRenderer lr;
    Rigidbody rb;
    float speed;
    bool isCalm;
    bool isDead;


    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        lr = player.GetComponent<LineRenderer>();
        isCalm = true;
        isDead = false;
    }

    void Update()
    {
        /*if (rb.velocity == Vector3.zero)
            isCalm = true;
        else 
            isCalm = false;*/


        if (isCalm)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position);


            if (Physics.Raycast(ray, out hit))
            {
                // работа с указателем 
                lr.SetPosition(1, CalculatingVector(hit));

                // Наращевание скорости и на ЛКМ
                if (Input.GetAxis("Fire1") == 1 && speed <= speedSlider.maxValue)
                {
                    speed += 0.1f;
                    speedSlider.value = speed;
                }
                if (Input.GetMouseButtonUp(0) && speed != 0)
                {
                    Vector3 vect = (hit.point - player.transform.position) * speed * 5;
                    rb.AddForce(vect);
                    speed = 0;
                    speedSlider.value = 0;
                }
            }
        }


        //if (transform.position.y < deadfloor.transform.position.y)
        //    isDead = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Обработка смерти 
        if (collision.transform.CompareTag("Dead"))
        {
            /*speedSlider.value = 100;*/

            
        }

        // Обработка победы
        if (collision.transform.CompareTag("Win"))
        {

        }
    }

    private Vector3 CalculatingVector(RaycastHit hit)
    {
        Vector3 nodet = hit.point;
        Vector3 nodef = transform.position;
        float step = 1.5f;

        float dx = nodet.x - nodef.x;
        float dy = nodet.y - nodef.y;
        float dz = nodet.z - nodef.z;

        float r = (float)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
        float xx = dx * ((float)step / r);
        float zz = dz * ((float)step / r);

        return new Vector3(nodef.x + xx, nodef.y, nodef.z + zz);
    }
}
