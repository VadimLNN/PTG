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

    // ����� ��� ���������� ��������� �������
    public void UpdateQuest(int amount)
    {
        if (!quest.IsComplete)
        {
            quest.AddProgress(amount);
            UpdateQuestUI();
        }
    }

    // ��������� ��������� �������
    private void UpdateQuestUI()
    {
        questNameText.text = quest.questName;
        questProgressText.text = $"{quest.currentAmount}/{quest.targetAmount}";
    }
}
