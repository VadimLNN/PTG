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

            BallScr_SetVelosity bs_sv;
            BallScr_MovePosition bs_mp;
            BallScr_AddForce bs_af;
            BallScr_Translate bs_t;
            BallScr_SetPosition bs_sp;

            // если объект с которым произошло столкновение содержит BallScript_
            if (objectHit.TryGetComponent<BallScr_SetVelosity>(out bs_sv) == true)
            {
                
                bs_sv.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs_sv.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_MovePosition>(out bs_mp) == true)
            {
                bs_mp.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs_mp.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_AddForce>(out bs_af) == true)
            {
                bs_af.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs_af.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_Translate>(out bs_t) == true)
            {
                bs_t.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs_t.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_SetPosition>(out bs_sp) == true)
            {
                bs_sp.select(); // вызов смены материала

                if (Input.GetAxis("Fire1") > 0) // если нажата левая кнопка мыши - запуск движения 
                    bs_sp.start = true;
            }
        }
    }
}
