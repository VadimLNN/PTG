using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HPScr : MonoBehaviour
{
    public int maxHP = 100;
    public TMP_Text HPText;

    float currentHP;

    public UnityEvent<float> onHPChange;

    void Start()
    {
        currentHP = maxHP;
        HPText.text = "Heal: " + currentHP.ToString("0");
    }

    public void hpChange(float change)
    {
        currentHP += change;

        if (currentHP <= 0)
            currentHP = maxHP;

        onHPChange?.Invoke(currentHP/maxHP);

        HPText.text = "Heal: " + currentHP.ToString("0");
    }
}
