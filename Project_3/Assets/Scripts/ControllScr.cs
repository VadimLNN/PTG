using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ControllScr : MonoBehaviour
{
    // ссылки на физическое тело, состояние и аниматора
    Rigidbody rb;
    int state = 0;
    Animator anim;

    // скорость передвижения и поворота
    float speed = 5;
    public float ang_speed = 72;

    // Характеристики для прыжка
    [Range(0.1f, 1f)]
    public float jumpForce = 0.35f;
    public bool onGround;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ground"))
            onGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("ground"))
            onGround = false;
    }

    void LateUpdate()
    {
        state = 0;

        // установка анимации и передвижения вперёд, назад 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            state = 1;
            rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            state = 2;                                                           // снижение скорости тк движение назад
            rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
        }

        // повороты в стороны
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * ang_speed); ;
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * -ang_speed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // прыжок 
        if (onGround == true && Input.GetKey(KeyCode.Space))
        {
            state = 3;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (onGround && (state == 0 || state == 1) && Input.GetAxis("Fire1") == 1)
            state = 6;

        if (onGround && (state == 0 || state == 1) && Input.GetAxis("Fire2") == 1)
            state = 7;

        // воспроизведение анимации
        anim.SetInteger("state", state);
    }
}
