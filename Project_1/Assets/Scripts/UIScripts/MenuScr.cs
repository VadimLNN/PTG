using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScr : MonoBehaviour
{
    public GameObject win_pnl;
    public GameObject dead_pnl;
    public GameObject menu_pnl;

    private void Start()
    {
        win_pnl.SetActive(false);
        dead_pnl.SetActive(false);
        menu_pnl.SetActive(false);
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
}
