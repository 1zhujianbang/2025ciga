using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AchievementCondition
{
    public string conditionType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class AchievementReward
{
    public string rewardType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class AchievementModel
{
    public string achievementID;
    public string achievementName;
    public string achievementCategory;
    public string description;
    public bool isUnlocked;
    public int unlockDate;
    public List<AchievementCondition> conditions;
    public List<AchievementReward> rewards;
}

[Serializable]
public class AchievementData
{
    public AchievementModel[] achievements;
}