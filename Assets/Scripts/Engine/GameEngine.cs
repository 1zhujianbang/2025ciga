using UnityEngine;
using System.Collections.Generic;

public class GameEngine : MonoBehaviour
{
    public static GameEngine Instance { get; private set; }
    
    [Header("Game State")]
    public int currentTurn = 1;
    public bool isGameRunning = false;
    
    [Header("Systems")]
    public ResourceSystem resourceSystem;
    public BuildingSystem buildingSystem;
    public TechnologySystem technologySystem;
    public DiplomacySystem diplomacySystem;
    public EventSystem eventSystem;
    public AchievementSystem achievementSystem;
    public MeasuresSystem measuresSystem;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        InitializeSystems();
    }
    
    private void InitializeSystems()
    {
        Debug.Log("初始化游戏引擎...");
        
        // 初始化所有系统
        resourceSystem = new ResourceSystem();
        buildingSystem = new BuildingSystem();
        technologySystem = new TechnologySystem();
        diplomacySystem = new DiplomacySystem();
        eventSystem = new EventSystem();
        achievementSystem = new AchievementSystem();
        measuresSystem = new MeasuresSystem();
        
        // 设置系统间的依赖关系
        buildingSystem.SetResourceSystem(resourceSystem);
        technologySystem.SetResourceSystem(resourceSystem);
        
        // 初始化系统
        resourceSystem.Initialize();
        buildingSystem.Initialize(resourceSystem);
        technologySystem.Initialize(resourceSystem);
        diplomacySystem.Initialize();
        eventSystem.InitializeEventSystem();
        achievementSystem.Initialize();
        
        // 加载数据
        DataManager.Instance.LoadAllData();
        
        Debug.Log("游戏引擎初始化完成");
    }
    
    public void StartGame()
    {
        isGameRunning = true;
        currentTurn = 1;
        Debug.Log("游戏开始");
    }
    
    public void NextTurn()
    {
        if (!isGameRunning) return;
        
        Debug.Log($"开始第 {currentTurn} 回合");
        
        // 更新所有系统
        resourceSystem.UpdateResources();
        buildingSystem.UpdateBuildings();
        technologySystem.UpdateTechnologies();
        diplomacySystem.UpdateDiplomacy();
        eventSystem.UpdateEvents();
        achievementSystem.UpdateAchievements();
        
        currentTurn++;
        Debug.Log($"第 {currentTurn - 1} 回合完成");
    }
    
    public void PauseGame()
    {
        isGameRunning = false;
        Debug.Log("游戏暂停");
    }
    
    public void ResumeGame()
    {
        isGameRunning = true;
        Debug.Log("游戏恢复");
    }
} 