using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam; // ������ �� ������

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit; // ��������� ��� �������� ���������� � ������������ 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //  �������� ���� �� ������� ������� ���� ����� ����� 

        if (Physics.Raycast(ray, out hit)) // ����� ����������� ���� � �������� ����� 
        {
            Transform objectHit = hit.transform;

            BallScr_SetVelosity bs_sv;
            BallScr_MovePosition bs_mp;
            BallScr_AddForce bs_af;
            BallScr_Translate bs_t;
            BallScr_SetPosition bs_sp;

            // ���� ������ � ������� ��������� ������������ �������� BallScript_
            if (objectHit.TryGetComponent<BallScr_SetVelosity>(out bs_sv) == true)
            {
                
                bs_sv.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs_sv.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_MovePosition>(out bs_mp) == true)
            {
                bs_mp.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs_mp.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_AddForce>(out bs_af) == true)
            {
                bs_af.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs_af.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_Translate>(out bs_t) == true)
            {
                bs_t.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs_t.start = true;
            }
            else if (objectHit.TryGetComponent<BallScr_SetPosition>(out bs_sp) == true)
            {
                bs_sp.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs_sp.start = true;
            }
        }
    }
}
