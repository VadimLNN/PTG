using TMPro;
using UnityEngine;

public class ScoreScr : MonoBehaviour
{
    public TMP_Text score_text;
    public TMP_Text time_text;

    public GameObject win_panel;
    public TMP_Text final_time_text;

    int score = 0;
    float time = 0;

    void Start()
    {
        scoreUpdate();
    }

    private void Update()
    {
        time += Time.deltaTime;
        time_text.text = Mathf.Round(time).ToString();
    }

    public void scoreUp(int points)
    {
        score += points;
        scoreUpdate();
    }

    public void scoreUpdate()
    {
        score_text.text = score.ToString();

        if (score == 4)
        {
            Time.timeScale = 0;
            win_panel.SetActive(true);
            final_time_text.text = time.ToString();

            Cursor.lockState = CursorLockMode.None;
        }
    }
}
