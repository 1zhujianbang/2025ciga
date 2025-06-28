using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Systems")]
    public ResourceSystem resourceSystem;
    public BuildingSystem buildingSystem;
    public TechnologySystem technologySystem;
    public DiplomacySystem diplomacySystem;
    public EventSystem eventSystem;
    public AchievementSystem achievementSystem;
    
    [Header("UI")]
    public UIManager uiManager;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializeGame()
    {
        Debug.Log("初始化游戏系统...");
        
        // 初始化所有系统
        resourceSystem = new ResourceSystem();
        buildingSystem = new BuildingSystem();
        technologySystem = new TechnologySystem();
        diplomacySystem = new DiplomacySystem();
        eventSystem = new EventSystem();
        achievementSystem = new AchievementSystem();
        
        // 加载数据
        DataManager.Instance.LoadAllData();
        
        Debug.Log("游戏系统初始化完成");
    }
    
    private void Start()
    {
        // 显示主菜单
        if (uiManager != null)
        {
            uiManager.ShowMainMenu();
        }
    }
}