using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NaturalElementEffect
{
    public string effectType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class NaturalElementModel
{
    public string elementID;
    public string elementName;
    public string elementType;
    public string description;
    public int baseValue;
    public float growthRate;
    public List<NaturalElementEffect> effects;
    public bool isActive;
}

[Serializable]
public class NaturalElementData
{
    public NaturalElementModel[] naturalElements;
}