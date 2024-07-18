using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelsScr : MonoBehaviour
{
    public GameObject menu_main_pnl;
    public GameObject menu_lvls_pnl;


    void Start()
    {
        // ���������� ������, ����������� �� ������ ������ ���������� ��������� 
        GameObject[] objects = GameObject.FindGameObjectsWithTag("lvlBtn");  // ������ �������� � ����� "levelButton"
        int lastLevel = SavesData.LastOpenedLevel();

        foreach (GameObject btn in objects)
        {
            if (Convert.ToInt32(btn.name.Substring(5)) > lastLevel)  // ����� ��� ������ ������� �������, �� ������� ��� ���������
            {
                btn.transform.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
        }
    }

    // ������� �� ������ �������� �� ������ ������� 
    public void LvlButtonClick()
    {
        SceneManager.LoadScene(
            Convert.ToInt32(
                EventSystem.current.currentSelectedGameObject.name.Substring(0, 1)));
    }

    public void Back()
    {
        menu_lvls_pnl.SetActive(false);
        menu_main_pnl.SetActive(true);
    }
}
