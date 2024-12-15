[System.Serializable]
public class Quest
{
    public string questName;
    public string description;
    public int targetAmount; 
    public int currentAmount;

    public bool IsComplete => currentAmount >= targetAmount;

    // Метод для обновления прогресса
    public void AddProgress(int amount)
    {
        currentAmount += amount;
        if (currentAmount > targetAmount) currentAmount = targetAmount;
    }
}
