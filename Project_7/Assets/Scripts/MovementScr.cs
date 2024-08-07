using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScr : MonoBehaviour
{
    [Range(200f, 500f)]
    public float mSpeed = 300f;

    Rigidbody rb;
    public Camera cam;
    float baseFOV;
    public float sprintFOV = 1.25f;

    void Start()
    {
        baseFOV = cam.fieldOfView;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool sprint = (Input.GetKey(KeyCode.LeftShift));

        // проверка нажатий w a s d
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        // получения направления движения в плоскости X/Z
        Vector3 dir = new Vector3(xMove, 0, zMove);
        // нормализация вектора 
        dir.Normalize();

        Vector3 v;

        // вектор вкорости = направление * скорость * время с прошедшего вызова
        if (sprint && zMove > 0)
        { 
            v = transform.TransformDirection(dir) * mSpeed*2 * Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV * sprintFOV, Time.fixedDeltaTime * 8f);
        }
        else
        {
            v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV, Time.fixedDeltaTime * 8f);
        }

        // восстановление смещения по Y
        v.y = rb.velocity.y;
        // применение скорости
        rb.velocity = v;
    }
}
