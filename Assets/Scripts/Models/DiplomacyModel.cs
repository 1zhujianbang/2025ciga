using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DiplomaticAction
{
    public string actionID;
    public string actionName;
    public string actionType;
    public int cost;
    public string description;
    public List<string> requirements;
}

[Serializable]
public class DiplomaticRelation
{
    public string relationID;
    public string relationName;
    public int relationLevel;
    public string description;
    public List<string> benefits;
    public List<string> requirements;
}

[Serializable]
public class DiplomaticModel
{
    public string diplomacyID;
    public string diplomacyName;
    public string diplomacyType;
    public int cost;
    public string description;
    public string status;
    public List<DiplomaticAction> actions;
    public List<DiplomaticRelation> relations;
}

[Serializable]
public class DiplomacyData
{
    public DiplomaticModel[] diplomacies;
}