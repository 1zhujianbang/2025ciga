using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventTrigger
{
    public string triggerType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class EventEffect
{
    public string effectType;
    public string target;
    public float value;
    public string description;
}

[Serializable]
public class EventChoice
{
    public string choiceID;
    public string choiceText;
    public List<EventEffect> effects;
    public string nextEventID;
}

[Serializable]
public class EventModel
{
    public string eventID;
    public string eventName;
    public string eventCategory;
    public string eventText;
    public List<EventTrigger> triggerConditions;
    public List<EventChoice> choices;
    public bool isActive;
    public int duration;
}

[Serializable]
public class EventData
{
    public EventModel[] events;
}