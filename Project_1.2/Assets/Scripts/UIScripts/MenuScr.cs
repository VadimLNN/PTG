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
    public GameObject finish_pnl;

    public GameObject menu_main_pnl;
    public GameObject menu_lvls_pnl;

    private void Start()
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);
        menu_pnl.SetActive(false);
        finish_pnl.SetActive(false);

        menu_lvls_pnl.SetActive(false);
    }

    public void OpenMenu()
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);
        finish_pnl.SetActive(false);

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
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            Debug.Log("exist");
            int level = SavesData.CurrentLevel();
            int countLevels = SavesData.CountLevels();

            Debug.Log(level);
            Debug.Log(countLevels);

            if (level < countLevels && level != -1)
                SceneManager.LoadScene(Convert.ToInt32(level + 1));
            else if (level >= countLevels)
            {
                win_pnl.SetActive(false);
                finish_pnl.SetActive(true);
            }
        }

        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SavesData.DeleteSave();
        
        // В сохранении устанавливается уровень 1
        SavesData.Save(0);

        // Загрузка первого уровня
        SceneManager.LoadScene(0);

        Time.timeScale = 1;
    }

    public void Levels() 
    {
        menu_main_pnl.SetActive(false);
        menu_lvls_pnl.SetActive(true);
    }
}
