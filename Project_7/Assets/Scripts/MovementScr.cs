using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScr : MonoBehaviour
{
    [Range(200f, 500f)]
    public float mSpeed = 300f;

    Rigidbody rb;

    void Start()
    {
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
        if (!sprint)
            v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
        else
            v = transform.TransformDirection(dir) * mSpeed*2 * Time.fixedDeltaTime;

        // восстановление смещения по Y
        v.y = rb.velocity.y;
        // применение скорости
        rb.velocity = v;
    }
}
