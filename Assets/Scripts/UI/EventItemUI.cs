using UnityEngine;
using UnityEngine.UI;
using System;

public class EventItemUI : MonoBehaviour
{
    [Header("Event Display")]
    public Text eventNameText;
    public Text eventTypeText;
    public Text eventPriorityText;
    public Button selectButton;
    
    private EventModel eventData;
    public event Action<EventModel> OnEventSelected;
    
    private void Start()
    {
        if (selectButton != null)
            selectButton.onClick.AddListener(OnSelectEvent);
    }
    
    public void SetupEvent(EventModel evt)
    {
        eventData = evt;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        if (eventData == null) return;
        
        if (eventNameText != null)
            eventNameText.text = eventData.eventName;
        
        if (eventTypeText != null)
            eventTypeText.text = GetEventTypeString(eventData.eventCategory);
        
        if (eventPriorityText != null)
            eventPriorityText.text = GetPriorityString(eventData.duration);
    }
    
    private string GetEventTypeString(string type)
    {
        switch (type?.ToLower())
        {
            case "natural": return "自然事件";
            case "diplomatic": return "外交事件";
            case "economic": return "经济事件";
            case "social": return "社会事件";
            default: return "未知事件";
        }
    }
    
    private string GetPriorityString(int duration)
    {
        switch (duration)
        {
            case 1: return "低优先级";
            case 2: return "中优先级";
            case 3: return "高优先级";
            case 4: return "紧急";
            case 5: return "危机";
            default: return "普通";
        }
    }
    
    private void OnSelectEvent()
    {
        OnEventSelected?.Invoke(eventData);
    }
} 