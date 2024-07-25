using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        onGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        state = 0;

        // установка анимации и передвижения вперёд, назад 
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (onGround == true)
            {
                state = 1;
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
            }
            else                                                                            // снижение скорости тк в полёте         
                rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * (speed * (float)0.75));
            
            
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (onGround == true)
            {
                state = 3;                                                           // снижение скорости тк движение назад
                rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
            }
            else                                                                     // снижение скорости тк движение назад в полёте
                rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * ((speed / 2) * (float)0.75));
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
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // установка анимация конфузии в полёте 
        if (onGround == false)
            state = 5;

        /*if (state == 0) // покой
        {
            float y = rb.velocity.y;
            rb.velocity = new Vector3 (0, y, 0);
        }*/

        // воспроизведение анимации
        anim.SetInteger("state", state);
    }


}
