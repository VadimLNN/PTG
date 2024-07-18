using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScr : MonoBehaviour
{
    public int? level;

    public GameObject win_pnl;
    public GameObject dead_pnl;
    public GameObject menu_pnl;

    public GameObject menu_main_pnl;
    public GameObject menu_lvls_pnl;

    private void Start()
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);
        menu_pnl.SetActive(false);

        menu_lvls_pnl.SetActive(false);
    }

    public void OpenMenu()
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);

        menu_pnl.SetActive(true);

        Time.timeScale = 0;
    }

    public void Continue() 
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);
        menu_pnl.SetActive(false);

        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Next()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            level = SavesData.LastOpenedLevel() > SavesData.CountLevels() ? SavesData.CountLevels() : SavesData.LastOpenedLevel();

            SceneManager.LoadScene(Convert.ToInt32(level));
        }
    }

    public void NewGame()
    {
        // В сохранении и внутри класса устанавливается уровень 1
        level = 1;
        SavesData.Save(1);

        // Можно взаимодействовать с кнопками "Продолжить игру" и "Уровни"
        /*resumeBtn.interactable = false;
        levelsBtn.interactable = false;*/

        // Загрузка первого уровня
        SceneManager.LoadScene(Convert.ToInt32(level));
    }

    public void Levels() 
    {
        menu_main_pnl.SetActive(false);
        menu_lvls_pnl.SetActive(true);
    }
}
