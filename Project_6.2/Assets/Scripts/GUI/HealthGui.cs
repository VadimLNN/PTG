using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthGUI : MonoBehaviour
{
    [SerializeField] TMP_Text healthTxt;

    public void updateHealth(int currentHp, int maxHp)
    {
        healthTxt.text = currentHp.ToString() + "/" + maxHp.ToString();
    }
}
