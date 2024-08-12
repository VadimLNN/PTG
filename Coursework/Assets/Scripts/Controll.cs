using UnityEngine;

public class Controll : MonoBehaviour
{
    // ссылки на физическое тело, состояние и аниматора
    Rigidbody rb;
    int state = 0;
    Animator anim;

    // скорость передвижения и поворота
    float speed = 3;
    public float ang_speed = 72;

    // Характеристики для прыжка
    [Range(1f, 10f)]
    public float jumpForce = 0.35f;
    public bool onGround;

    // состояние атаки и полёта
    bool attacking = false;
    bool flying = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        onGround = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            onGround = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            onGround = false;
    }

    void LateUpdate()
    {
        // установка анимации простоя
        state = 0;

        // если нет анимации атаки
        if (attacking == false)
        {
            // установка анимации и передвижения вперёд, назад 
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = 11;                                                      // умножение скорости X2 тк бег
                    rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed * 2);
                }
                else
                {
                    state = 1;
                    rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed);
                }
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = 22;                                                         // снижение скорости тк движение назад
                    rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * speed / 1.5f);
                }
                else
                {
                    state = 2;                                                           // снижение скорости тк движение назад
                    rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
                }
            }

            // ходьба в стороны
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = 33;                                                        
                    rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed * 2);
                }
                else
                {
                    state = 3;                                                           
                    rb.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * speed);
                }
                
                //state = 3;
                //Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * ang_speed); ;
                //rb.MoveRotation(rb.rotation * deltaRotation);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = 44;
                    rb.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * speed * 2);
                }
                else
                {
                    state = 4;
                    rb.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * speed);
                }
                
                //state = 4;
                //Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Time.deltaTime * -ang_speed);
                //rb.MoveRotation(rb.rotation * deltaRotation);
            }

            // атака мечом на пкм + ctrl, если персонаж стоит или ходит
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
                state = 55;
            // команда вперёд на пкм, если персонаж стоит, идёт вперёд
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0))
                state = 5;

            // атака мечом на пкм + ctrl, если персонаж стоит, идёт вперёд
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftControl))
                state = 66;
            // команда назад на лкм, если персонаж стоит или ходит
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1))
                state = 6;

            // прыжок (взлёт)
            if (onGround == true && Input.GetKey(KeyCode.Space))
            {
                state = 44;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            // полёт
            if (onGround == false)
            {
                state = 74;
                flying = true;
            }
            // приземление
            if (onGround == true && flying == true)
            {
                state = 84;
                flying = false;
            }
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
