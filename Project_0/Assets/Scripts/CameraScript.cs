using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam; // ссылка на камеру

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit; // структура для хранения информации о пересечениях 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //  проекция луча из позиции курсора мыши через сцену 

        if (Physics.Raycast(ray, out hit)) // поиск пересечений луча и объектов сцены 
        {
            Transform objectHit = hit.transform;

            BallScript bs;

            // если объект с которым произошло столкновение содержит BallScript
            if (objectHit.TryGetComponent<BallScript>(out bs) == true)
            {
                bs.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs.start = true;
            }
        }
    }
}
