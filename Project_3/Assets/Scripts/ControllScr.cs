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
    [Range(1f, 10f)]
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
        onGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    void LateUpdate()
    {
        state = 0;

        // установка анимации и передвижения вперёд, назад 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if(onGround && Input.GetKey(KeyCode.LeftShift))
            {
                state = 3;                                                      // умножение скорости X2 тк бег
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed*2);
            }
            else
            {
                state = 1;
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
            }
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
            state = 4;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // прямой крос правой на пкм, если персонаж стоит, идёт вперёд/назад, бежит
        if (onGround && (state == 0 || state == 1 || state == 2 || state == 3) && Input.GetAxis("Fire1") == 1)
            state = 5;

        // удар левым локтем на лкм, если персонаж стоит, идёт вперёд/назад, бежит
        if (onGround && (state == 0 || state == 1 || state == 2 || state == 3) && Input.GetAxis("Fire2") == 1)
            state = 6;

        // воспроизведение анимации
        anim.SetInteger("state", state);
    }
}
