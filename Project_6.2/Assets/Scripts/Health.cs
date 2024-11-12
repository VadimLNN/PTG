using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] int maxHealth;
    [Range(1, 100)]
    [SerializeField] int currentHealth;

    public UnityEvent<int, int> onHealthChange;

    private void Start() => onHealthChange?.Invoke(currentHealth, maxHealth);
 
    public bool changeHealth(int amount)
    {
        if (currentHealth == maxHealth)
            return false;

        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        if(currentHealth < 0)
            currentHealth = 0;

        onHealthChange?.Invoke(currentHealth, maxHealth);

        return true;
    }
}
