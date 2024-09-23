using UnityEngine;
using UnityEngine.SceneManagement;

public class UiScr : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
