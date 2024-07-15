using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallScr_Translate : MonoBehaviour
{
    // для работы со скоростью шара
    [Range(0.1f, 100f)]
    public float speed = 2;

    // для работы с материалом шара при стокновении 
    public Material hitMat;
    private Renderer ren;

    // для работы с материалом шара при выборе 
    [HideInInspector] // сокрытие переменной в инспекторе
    public bool start = false; // переменная определяющая начало движения

    public Material defoultMat; //  материала до выбора
    public Material selectedMat; // материал при выборе

    // для работы с UI
    public Text val;

    // начальная позиция шара
    Vector3 oldPos;


    // вызывается при выборе сферы
    public void select()
    {
        ren.material = selectedMat;
    }

    // установщик скорости 
    public void setSpeed(float value)
    {
        Debug.Log(value.ToString());
        speed = value;
        val.text = speed.ToString();
    }

    // сброс параметров 
    public void reset()
    {
        transform.position = oldPos;
        start = false;
        ren.material = defoultMat;
    }


    // вызывается перед первым кадром
    void Start()
    {
        // сохранение начальной позиции 
        oldPos = transform.position;

        val.text = speed.ToString();

        ren = GetComponent<Renderer>();
        ren.material = defoultMat;
    }

    // вызывается при столкновении 
    private void OnCollisionEnter(Collision collision)
    {
        // смена материала при столкновении 
        ren.material = hitMat; 
    }

    // вызывается каждый кадр
    void Update()
    {
        if (start)        
        {
            //transform.position += transform.right * Time.deltaTime * speed;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }
}
