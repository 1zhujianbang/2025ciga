using UnityEngine;
using UnityEngine.UI;
using System;

public class AchievementItemUI : MonoBehaviour
{
    public Text achievementNameText;
    public Text achievementDescText;
    public Button selectButton;

    private AchievementModel achievementData;
    public Action<AchievementModel> OnAchievementSelected;

    public void Setup(AchievementModel model, Action<AchievementModel> onSelect)
    {
        achievementData = model;
        achievementNameText.text = model.achievementName;
        achievementDescText.text = model.description;
        OnAchievementSelected = onSelect;
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => OnAchievementSelected?.Invoke(achievementData));
    }
} 