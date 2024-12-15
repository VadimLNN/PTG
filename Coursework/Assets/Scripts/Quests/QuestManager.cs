using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Quest quest; 
    public TextMeshPro questNameText;
    public TextMeshPro questProgressText;

    private void Start()
    {
        UpdateQuestUI();
    }

    // Метод для обновления прогресса задания
    public void UpdateQuest(int amount)
    {
        if (!quest.IsComplete)
        {
            quest.AddProgress(amount);
            UpdateQuestUI();
        }
    }

    // Обновляем интерфейс задания
    private void UpdateQuestUI()
    {
        questNameText.text = quest.questName;
        questProgressText.text = $"{quest.currentAmount}/{quest.targetAmount}";
    }
}
