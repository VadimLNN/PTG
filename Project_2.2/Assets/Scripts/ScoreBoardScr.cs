using TMPro;
using UnityEngine;

public class ScoreBoardScr : MonoBehaviour
{
    public GameObject dead_panel;
    public TMP_Text score_text;
    int score = 0;

    void Start()
    {
        scoreUpdate();    
    }

    public void scoreUp(int points)
    {
        score += points;
        scoreUpdate();
    }

    public void scoreDown(int points)
    {
        score -= points;
        scoreUpdate();
    }
    public void scoreUpdate()
    {
        score_text.text = $"Score: {score}";

        if (score < 0)
        {
            Time.timeScale = 0;
            dead_panel.SetActive(true);
            score = 0;
        }

    }

}
