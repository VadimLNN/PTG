using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScr : MonoBehaviour
{
    // ссылки на игрока и камеру
    public Transform player;
    public Transform cam;

    // чувствительность мыши
    [Range(50f, 100f)]
    public float xSens = 70f;
    [Range(50f, 100f)]
    public float ySens = 70f;

    // начальный поворот камеры
    Quaternion center;

    void Start()
    {
        center = cam.localRotation;
    }

    void Update()
    {
        // получение поворота по X
        float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);
    
        // ограничение поворота на более чем 90 градусов 
        if (Quaternion.Angle(center, yRot) < 90f)
            cam.localRotation = yRot;
        
        // получение поворота по Y 
        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        Quaternion xRot = cam.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);
    
        // поворот игрока 
        player.localRotation = xRot;
    }
}
