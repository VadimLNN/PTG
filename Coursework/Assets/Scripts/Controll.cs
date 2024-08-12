using UnityEngine;

public class Controll : MonoBehaviour
{
    // ������ �� ���������� ����, ��������� � ���������
    Rigidbody rb;
    int state = 0;
    Animator anim;

    // �������� ������������ � ��������
    float speed = 3;
    public float ang_speed = 72;

    // �������������� ��� ������
    [Range(1f, 10f)]
    public float jumpForce = 0.35f;
    public bool onGround;

    // ��������� ����� � �����
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
        // ��������� �������� �������
        state = 0;

        // ���� ��� �������� �����
        if (attacking == false)
        {
            // ��������� �������� � ������������ �����, ����� 
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    state = 11;                                                      // ��������� �������� X2 �� ���
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
                    state = 22;                                                         // �������� �������� �� �������� �����
                    rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * speed / 1.5f);
                }
                else
                {
                    state = 2;                                                           // �������� �������� �� �������� �����
                    rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
                }
            }

            // ������ � �������
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

            // ����� ����� �� ��� + ctrl, ���� �������� ����� ��� �����
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
                state = 55;
            // ������� ����� �� ���, ���� �������� �����, ��� �����
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0))
                state = 5;

            // ����� ����� �� ��� + ctrl, ���� �������� �����, ��� �����
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftControl))
                state = 66;
            // ������� ����� �� ���, ���� �������� ����� ��� �����
            if (onGround == true && (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1))
                state = 6;

            // ������ (����)
            if (onGround == true && Input.GetKey(KeyCode.Space))
            {
                state = 44;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            // ����
            if (onGround == false)
            {
                state = 74;
                flying = true;
            }
            // �����������
            if (onGround == true && flying == true)
            {
                state = 84;
                flying = false;
            }
        }

        // ��������������� ��������
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
