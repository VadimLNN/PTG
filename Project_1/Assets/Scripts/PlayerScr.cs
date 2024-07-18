using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScr : MonoBehaviour
{
    // параметры и ссылки на объекты, UI
    float speed;
    bool isCalm;
    /*bool isDead;*/
    
    public Camera cam;     
    public GameObject player;
    LineRenderer lr;
    Rigidbody rb;
    
    public Slider speedSlider;
    public GameObject win_pnl;
    public GameObject dead_pnl;


    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        lr = player.GetComponent<LineRenderer>();
        isCalm = true;
        /*isDead = false;*/
    }

    void Update()
    {
        /*if (rb.velocity == Vector3.zero)
            isCalm = true;
        else 
            isCalm = false;*/


        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);


        if (Physics.Raycast(ray, out hit))
        {
            // работа с указателем 
            lr.SetPosition(1, CalculatingVector(hit));

            if (isCalm)
            {    
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Обработка смерти 
        if (collision.transform.CompareTag("Dead"))
        {
            dead_pnl.SetActive(true);
            Time.timeScale = 0;
            
        }

        // Обработка победы
        if (collision.transform.CompareTag("Win"))
        {
            win_pnl.SetActive(true);

            // Сохранение данных, если уровень не был пройден ранее
            int level = SavesData.CurrentLevel();

            if (level == SavesData.LastOpenedLevel())
                SavesData.Save(level + 1);

            Time.timeScale = 0;
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
