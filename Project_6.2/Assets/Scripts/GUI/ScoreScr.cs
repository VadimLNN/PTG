using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScr : MonoBehaviour
{
    public TMP_Text scoreTxt;
    int score = 0;

    public void scoreUp()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
}
