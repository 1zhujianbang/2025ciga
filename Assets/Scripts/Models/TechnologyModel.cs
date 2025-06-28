using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TechnologyEffect
{
    public string effectType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class TechnologyModel
{
    public string techID;
    public string techName;
    public string techCategory;
    public int researchCost;
    public int researchTime;
    public string prerequisites;
    public string description;
    public string unlocksBuildings;
    public string unlocksMeasures;
    public string iconPath;
    public List<TechnologyEffect> getEffects;
}

[Serializable]
public class TechnologyData
{
    public TechnologyModel[] technologies;
}
