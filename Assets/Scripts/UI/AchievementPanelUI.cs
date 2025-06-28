using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AchievementPanelUI : MonoBehaviour
{
    public Transform achievementListContainer;
    public GameObject achievementItemPrefab;
    public Text achievementNameText;
    public Text achievementDescText;
    public Text achievementStatusText;

    private List<GameObject> achievementItems = new List<GameObject>();
    private AchievementSystem achievementSystem;
    private AchievementModel selectedAchievement;

    void Start()
    {
        achievementSystem = GameEngine.Instance.achievementSystem;
        RefreshAchievementList();
    }

    public void RefreshAchievementList()
    {
        foreach (var item in achievementItems)
            Destroy(item);
        achievementItems.Clear();

        var achievements = achievementSystem.achievements;
        foreach (var ach in achievements)
        {
            var go = Instantiate(achievementItemPrefab, achievementListContainer);
            var ui = go.GetComponent<AchievementItemUI>();
            if (ui != null)
                ui.Setup(ach, OnSelectAchievement);
            achievementItems.Add(go);
        }
    }

    void OnSelectAchievement(AchievementModel ach)
    {
        selectedAchievement = ach;
        achievementNameText.text = ach.achievementName;
        achievementDescText.text = ach.description;
        achievementStatusText.text = achievementSystem.unlockedAchievements.Contains(ach) ? "已解锁" : "未解锁";
    }
} 