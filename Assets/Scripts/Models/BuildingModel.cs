using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingEffect
{
    public string effectType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class BuildingModel
{
    public string buildingID;
    public string buildingName;
    public string buildingType;
    public string buildingCategory;
    public int costWood;
    public int costIron;
    public int costCopper;
    public int costGold;
    public int costSpiritEnergy;
    public int buildTime;
    public int maintenanceCost;
    public int productionRate;
    public int capacity;
    public float consciousnessChance;
    public string description;
    public string modelPath;
    public string iconPath;
    public string unlockTech;
    public List<BuildingEffect> getEffects;
}

[Serializable]
public class BuildingData
{
    public BuildingModel[] buildings;
}

