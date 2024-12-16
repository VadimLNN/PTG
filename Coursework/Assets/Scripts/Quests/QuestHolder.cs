using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolderZomb : MonoBehaviour
{
    public RectTransform quePnl;
    public int points = 1;
    QuestManager questManager;

    private void Start()
    {
        questManager = quePnl.GetComponent<QuestManager>();
    }

    private void OnDestroy()
    {
        foreach (var quest in questManager.quests)
        {
            if (quest.questName == "Kill Zombie")
            {
                questManager.UpdateQuest(quest, points);
            }
        }
    }
}
