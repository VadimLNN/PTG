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

            BallScript bs;

            // ���� ������ � ������� ��������� ������������ �������� BallScript
            if (objectHit.TryGetComponent<BallScript>(out bs) == true)
            {
                bs.select(); // ����� ����� ���������

                if (Input.GetAxis("Fire1") > 0) // ���� ������ ����� ������ ���� - ������ �������� 
                    bs.start = true;
            }
        }
    }
}
