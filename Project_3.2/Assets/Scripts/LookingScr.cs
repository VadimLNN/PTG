using UnityEngine;

public class LookingScr : MonoBehaviour
{
    // ������ �� ������, ������ � �������� �������
    public Transform player;
    public Transform cam;
    public static bool cursorLock = true;

    // ���������������� ����
    [Range(100f, 300f)]
    public float xSens = 120f;
    [Range(100f, 300f)]
    public float ySens = 120f;

    // ��������� ������� ������
    Quaternion center;

    void Start()
    {
        center = cam.localRotation;
    }

    void Update()
    {
        // ��������� �������� �� X
        float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);

        // ����������� �������� �� ����� ��� 90 �������� 
        if (Quaternion.Angle(center, yRot) < 90f)
            cam.localRotation = yRot;

        // ��������� �������� �� Y 
        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        // ������� ������ 
        player.localRotation = xRot;



        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.L))
                cursorLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.L))
                cursorLock = true;
        }
    }
}
