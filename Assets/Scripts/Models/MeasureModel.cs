using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MeasureEffect
{
    public string effectType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class MeasureModel
{
    public string measureID;
    public string measureName;
    public string measureType;
    public string description;
    public int cost;
    public int duration;
    public List<MeasureEffect> effects;
    public bool isActive;
}

[Serializable]
public class MeasureData
{
    public MeasureModel[] measures;
}