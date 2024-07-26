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

    // отслеживание состояния атаки
    public bool attacking = false;


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
        // если не происходит атака
        if (attacking == false){
            state = 0;

            // установка анимации и передвижения вперёд, назад 
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (onGround == true)
                {
                    state = 2;
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

            // установка анимации и передвижения вправо, влево
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                state = 4;
                rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                state = 5;
                rb.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * speed);
            }

            /*// повороты в стороны
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * ang_speed); ;
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * -ang_speed);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }*/

            // прыжок 
            if (onGround == true && Input.GetKey(KeyCode.Space))
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // установка анимация конфузии в полёте 
            if (onGround == false)
                state = 1;

            if (onGround && (state == 0 || state == 2) && Input.GetKey(KeyCode.LeftControl))
                state = 6;

            if (onGround && (state == 0 || state == 2) && Input.GetKey(KeyCode.LeftShift))
                state = 7;
        }

        // воспроизведение анимации
        anim.SetInteger("state", state);
    }

    public void AttackOn()
    {
        attacking = true;
    }
    
    public void AttackOff() 
    {
        attacking = false;
    }
}
