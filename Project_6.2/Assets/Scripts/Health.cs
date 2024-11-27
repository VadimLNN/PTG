using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] int maxHealth;
    [Range(1, 100)]
    [SerializeField] float currentHealth;

    public UnityEvent<int, int> onHealthChange;

    public UnityEvent <Vector3> spawnOnDeath;
    public UnityEvent onDeath;
    public UnityEvent onHitTaken;

    private Coroutine burnCoroutine;

    private void Start() => onHealthChange?.Invoke((int)currentHealth, maxHealth);
 
    public bool changeHealth(int amount)
    {
        if (currentHealth == maxHealth)
            return false;

        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        if(currentHealth < 0)
            currentHealth = 0;

        onHealthChange?.Invoke((int)currentHealth, maxHealth);

        return true;
    }

    public void hpDecrease(float amount)
    {
        if (currentHealth <= 0) return;

        onHitTaken?.Invoke();

        currentHealth = Mathf.FloorToInt(currentHealth - amount);

        if(currentHealth < 0)
            currentHealth = 0;

        onHealthChange?.Invoke((int)currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
            spawnOnDeath?.Invoke(transform.position);
        }
    }

    public void ApplyBurnEffect(float damagePerSecond, float duration)
    {
        // Если враг уже горит, перезапускаем эффект
        if (burnCoroutine != null)
        {
            StopCoroutine(burnCoroutine);
        }
        burnCoroutine = StartCoroutine(BurnEffect(damagePerSecond, duration));
    }

    private IEnumerator BurnEffect(float damagePerSecond, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            currentHealth -= damagePerSecond * Time.deltaTime;
            elapsedTime += Time.deltaTime;

            if (currentHealth < 0)
                currentHealth = 0;

            if (currentHealth == 0)
            {
                onDeath?.Invoke();
                spawnOnDeath?.Invoke(transform.position);
                yield break; 
            }

            yield return null;
        }

        Debug.Log("Эффект горения закончился.");
    }
}
