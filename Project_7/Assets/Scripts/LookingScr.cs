using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScr : MonoBehaviour
{
    // ������ �� ������ � ������
    public Transform player;
    public Transform cam;

    // ���������������� ����
    [Range(50f, 100f)]
    public float xSens = 70f;
    [Range(50f, 100f)]
    public float ySens = 70f;

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
        Quaternion xRot = cam.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);
    
        // ������� ������ 
        player.localRotation = xRot;
    }
}
