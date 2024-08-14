using UnityEngine;
using UnityEngine.AI;

public class Controll : MonoBehaviour
{
    // ������ �� ���������� ����, ��������� � ���������
    Rigidbody rb;
    int state = 0;
    Animator anim;

    // ���� ��� ������������� �������� � ������ ��������
    public LayerMask interactable;
    float detectRadius = 1f;

    // �������� ������������
    float speed = 2.5f;

    // �������������� ��� ������
    [Range(1f, 10f)]
    public float jumpForce = 5;
    public bool onGround;

    // ��������� �����, �����, �������� � �����
    bool attacking = false;
    bool isFlying = false;
    bool isCrouch = false;
    bool isBlock = false;


    // ��� ������ � ���������
    public GameObject minon;



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
            // ��������� ��������� �� ������
            if (Input.GetKeyDown(KeyCode.C))
                isCrouch = !isCrouch;

            // ��� ����� �������� � �����
            if (isBlock == false)
            {
                // ��������� �������� � ������������ �����, ����� 
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    if (isCrouch == true)
                    {
                        state = 111;
                        rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime * speed / 1.3f);
                    }
                    else
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
                }
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    if (isCrouch == true)
                    {
                        state = 222;
                        rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * speed / 1.3f);
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            state = 22;                                                         // �������� �������� �� �������� �����
                            rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * speed);
                        }
                        else
                        {
                            state = 2;                                                           // �������� �������� �� �������� �����
                            rb.MovePosition(transform.position - transform.forward * Time.fixedDeltaTime * (speed / 2));
                        }
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
            }

            // ������� ����� �� ���, ���� �������� �����, ��� �����
            if (onGround == true //&& (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0))
            {
                state = 5;
                Vector3 point = transform.position + transform.forward * 10;
                minon.GetComponent<MinionScr>().GoForvard(point);
            }
            // ����� ����� �� ��� + ctrl, ���� �������� ����� ��� �����
            if (onGround == true //&& (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.LeftControl))
                state = 55;
            
            // ������� ����� �� ���, ���� �������� ����� ��� �����
            if (onGround == true //&& (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1))
            {
                state = 6;

            }
            // ���� �� ��� + ctrl, ���� �������� �����, ��� �����
            if (onGround == true //&& (state == 0 || state == 1 || state == 2 || state == 3 || state == 4) 
                && Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftControl))
            {
                isBlock = true;
                state = 66;
            }
            else 
                isBlock = false;
            

            // ������ (����)
            if (onGround == true && Input.GetKey(KeyCode.Space))
            {
                state = 100;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            // ����
            if (onGround == false)
            {
                state = 101;
                isFlying = true;
            }
            // �����������
            if (onGround == true && isFlying == true)
            {
                isFlying = false;
                state = 102;
            }

            // �������� ������� ��� ���������� � �������
            Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, interactable);

            // ���� ������ ����� � ������
            if (cols.Length > 0 && Input.GetKey(KeyCode.E))
            {
                state = 500;
                InteractableObj c = cols[0].transform.GetComponent<InteractableObj>();
                if (c != null)
                    c.interact();
                
            }
        }

        // ��������������� ��������
        anim.SetInteger("state", state);
        anim.SetBool("isCrouch", isCrouch);
        anim.SetBool("isBlock", isBlock);



    
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.localPosition, detectRadius);


        Vector3 point = transform.position + transform.forward * 10;
        Gizmos.DrawWireSphere(point, 0.5f);
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
