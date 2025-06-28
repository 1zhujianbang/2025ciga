using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EventPanelUI : MonoBehaviour
{
    [Header("Event Display")]
    public Transform eventContainer;
    public GameObject eventItemPrefab;
    public Text currentEventText;
    public Text eventDescriptionText;
    
    [Header("Event Controls")]
    public Button acceptEventButton;
    public Button rejectEventButton;
    public Button closeEventButton;
    
    private List<GameObject> eventItems = new List<GameObject>();
    private EventModel currentEvent;
    private EventSystem eventSystem;
    
    private void Start()
    {
        eventSystem = GameEngine.Instance?.eventSystem;
        SetupButtons();
        RefreshEventList();
    }
    
    private void SetupButtons()
    {
        if (acceptEventButton != null)
            acceptEventButton.onClick.AddListener(OnAcceptEvent);
        
        if (rejectEventButton != null)
            rejectEventButton.onClick.AddListener(OnRejectEvent);
        
        if (closeEventButton != null)
            closeEventButton.onClick.AddListener(OnCloseEvent);
    }
    
    public void RefreshEventList()
    {
        // 清除现有事件项
        foreach (var item in eventItems)
        {
            if (item != null)
                Destroy(item);
        }
        eventItems.Clear();
        
        if (eventSystem != null)
        {
            var events = eventSystem.GetActiveEvents();
            foreach (var evt in events)
            {
                CreateEventItem(evt);
            }
        }
    }
    
    private void CreateEventItem(EventModel evt)
    {
        if (eventItemPrefab != null && eventContainer != null)
        {
            var item = Instantiate(eventItemPrefab, eventContainer);
            var eventItemUI = item.GetComponent<EventItemUI>();
            
            if (eventItemUI != null)
            {
                eventItemUI.SetupEvent(evt);
                eventItemUI.OnEventSelected += OnEventSelected;
            }
            
            eventItems.Add(item);
        }
    }
    
    private void OnEventSelected(EventModel evt)
    {
        currentEvent = evt;
        ShowEventDetails(evt);
    }
    
    private void ShowEventDetails(EventModel evt)
    {
        if (currentEventText != null)
            currentEventText.text = evt.eventName;
        
        if (eventDescriptionText != null)
            eventDescriptionText.text = evt.eventText;
        
        // 显示事件选项按钮
        if (acceptEventButton != null)
            acceptEventButton.gameObject.SetActive(true);
        
        if (rejectEventButton != null)
            rejectEventButton.gameObject.SetActive(true);
    }
    
    private void OnAcceptEvent()
    {
        if (currentEvent != null && eventSystem != null)
        {
            eventSystem.AcceptEvent(currentEvent.eventID);
            RefreshEventList();
            ClearEventDetails();
        }
    }
    
    private void OnRejectEvent()
    {
        if (currentEvent != null && eventSystem != null)
        {
            eventSystem.RejectEvent(currentEvent.eventID);
            RefreshEventList();
            ClearEventDetails();
        }
    }
    
    private void OnCloseEvent()
    {
        ClearEventDetails();
    }
    
    private void ClearEventDetails()
    {
        currentEvent = null;
        
        if (currentEventText != null)
            currentEventText.text = "";
        
        if (eventDescriptionText != null)
            eventDescriptionText.text = "";
        
        if (acceptEventButton != null)
            acceptEventButton.gameObject.SetActive(false);
        
        if (rejectEventButton != null)
            rejectEventButton.gameObject.SetActive(false);
    }
} 