using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    [Header("Navigation Buttons")]
    public Button eventsButton;
    public Button buildingsButton;
    public Button technologyButton;
    public Button measuresButton;
    public Button diplomacyButton;
    public Button achievementsButton;
    
    [Header("Game Control")]
    public Button nextTurnButton;
    public Button menuButton;
    public Text turnText;
    
    [Header("Resource Display")]
    public Transform resourceContainer;
    public GameObject resourceDisplayPrefab;
    
    [Header("Content Panels")]
    public GameObject eventsPanel;
    public GameObject buildingsPanel;
    public GameObject technologyPanel;
    public GameObject measuresPanel;
    public GameObject diplomacyPanel;
    public GameObject achievementsPanel;
    
    private UIManager uiManager;
    private GameManager gameManager;
    private List<GameObject> resourceDisplays = new List<GameObject>();
    private int currentTurn = 1;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameManager = GameManager.Instance;
        
        SetupButtons();
        SetupResourceDisplay();
        ShowEventsPanel(); // 默认显示事件面板
    }
    
    private void SetupButtons()
    {
        if (eventsButton != null)
            eventsButton.onClick.AddListener(() => ShowEventsPanel());
        
        if (buildingsButton != null)
            buildingsButton.onClick.AddListener(() => ShowBuildingsPanel());
        
        if (technologyButton != null)
            technologyButton.onClick.AddListener(() => ShowTechnologyPanel());
        
        if (measuresButton != null)
            measuresButton.onClick.AddListener(() => ShowMeasuresPanel());
        
        if (diplomacyButton != null)
            diplomacyButton.onClick.AddListener(() => ShowDiplomacyPanel());
        
        if (achievementsButton != null)
            achievementsButton.onClick.AddListener(() => ShowAchievementsPanel());
        
        if (nextTurnButton != null)
            nextTurnButton.onClick.AddListener(OnNextTurnClicked);
        
        if (menuButton != null)
            menuButton.onClick.AddListener(OnMenuClicked);
    }
    
    private void SetupResourceDisplay()
    {
        if (gameManager != null && gameManager.resourceSystem != null)
        {
            var resources = gameManager.resourceSystem.GetAllResources();
            
            foreach (var resource in resources)
            {
                CreateResourceDisplay(resource);
            }
        }
    }
    
    private void CreateResourceDisplay(ResourceModel resource)
    {
        if (resourceDisplayPrefab != null && resourceContainer != null)
        {
            var display = Instantiate(resourceDisplayPrefab, resourceContainer);
            var resourceUI = display.GetComponent<ResourceDisplayUI>();
            
            if (resourceUI != null)
            {
                resourceUI.SetupResource(resource);
            }
            
            resourceDisplays.Add(display);
        }
    }
    
    private void ShowEventsPanel()
    {
        HideAllContentPanels();
        if (eventsPanel != null) eventsPanel.SetActive(true);
    }
    
    private void ShowBuildingsPanel()
    {
        HideAllContentPanels();
        if (buildingsPanel != null) buildingsPanel.SetActive(true);
    }
    
    private void ShowTechnologyPanel()
    {
        HideAllContentPanels();
        if (technologyPanel != null) technologyPanel.SetActive(true);
    }
    
    private void ShowMeasuresPanel()
    {
        HideAllContentPanels();
        if (measuresPanel != null) measuresPanel.SetActive(true);
    }
    
    private void ShowDiplomacyPanel()
    {
        HideAllContentPanels();
        if (diplomacyPanel != null) diplomacyPanel.SetActive(true);
    }
    
    private void ShowAchievementsPanel()
    {
        HideAllContentPanels();
        if (achievementsPanel != null) achievementsPanel.SetActive(true);
    }
    
    private void HideAllContentPanels()
    {
        if (eventsPanel != null) eventsPanel.SetActive(false);
        if (buildingsPanel != null) buildingsPanel.SetActive(false);
        if (technologyPanel != null) technologyPanel.SetActive(false);
        if (measuresPanel != null) measuresPanel.SetActive(false);
        if (diplomacyPanel != null) diplomacyPanel.SetActive(false);
        if (achievementsPanel != null) achievementsPanel.SetActive(false);
    }
    
    private void OnNextTurnClicked()
    {
        Debug.Log("下一回合按钮被点击");
        
        if (gameManager != null)
        {
            // 更新所有系统
            gameManager.resourceSystem.UpdateResources();
            gameManager.buildingSystem.UpdateBuildings();
            gameManager.technologySystem.UpdateTechnologies();
            gameManager.diplomacySystem.UpdateDiplomacy();
            gameManager.eventSystem.UpdateEvents();
            gameManager.achievementSystem.UpdateAchievements();
            
            // 更新回合数
            currentTurn++;
            if (turnText != null)
            {
                turnText.text = $"回合: {currentTurn}";
            }
            
            // 更新资源显示
            UpdateResourceDisplays();
            
            Debug.Log($"第{currentTurn}回合完成");
        }
    }
    
    private void OnMenuClicked()
    {
        Debug.Log("游戏菜单按钮被点击");
        // 这里可以显示游戏菜单（保存、加载、设置等）
    }
    
    private void UpdateResourceDisplays()
    {
        foreach (var display in resourceDisplays)
        {
            var resourceUI = display.GetComponent<ResourceDisplayUI>();
            if (resourceUI != null)
            {
                resourceUI.UpdateDisplay();
            }
        }
    }
}