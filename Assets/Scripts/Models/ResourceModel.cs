using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class ResourceModel
{
    public string resourceID;
    public string resourceName;
    public string resourceType;
    public int baseValue;
    public float regenerationRate;
    public int maxStorage;
    public string description;
    public string iconPath;
    public int consciousnessLevel;
    public int amount;
}

[Serializable]
public class ResourceData
{
    public ResourceModel[] resources;
}