using UnityEngine;
using UnityEngine.UI;

/*
 * UI设置指南
 * 
 * 在Unity编辑器中按以下步骤设置UI：
 * 
 * 1. 创建主Canvas
 *    - 右键Hierarchy -> UI -> Canvas
 *    - 设置Canvas Scaler为Scale With Screen Size
 *    - 参考分辨率：1920x1080
 * 
 * 2. 在Canvas下创建主菜单面板
 *    - 右键Canvas -> UI -> Panel，命名为"MainMenuPanel"
 *    - 添加Image组件作为背景
 *    - 添加按钮：开始游戏、设置、退出
 * 
 * 3. 在Canvas下创建游戏主面板
 *    - 右键Canvas -> UI -> Panel，命名为"GamePanel"
 *    - 初始状态设为隐藏
 * 
 * 4. 在GamePanel下创建各个功能面板：
 *    - 事件面板 (EventPanel)
 *    - 建筑面板 (BuildingPanel) 
 *    - 科技面板 (TechnologyPanel)
 *    - 资源面板 (ResourcePanel)
 *    - 外交面板 (DiplomacyPanel)
 *    - 成就面板 (AchievementPanel)
 * 
 * 5. 每个功能面板的结构：
 *    - 左侧：ScrollView用于显示列表
 *    - 右侧：详情显示区域
 *    - 底部：操作按钮区域
 * 
 * 6. 创建预制体：
 *    - 事件项预制体 (EventItem)
 *    - 建筑项预制体 (BuildingItem)
 *    - 科技项预制体 (TechnologyItem)
 *    - 资源项预制体 (ResourceItem)
 * 
 * 7. 绑定脚本：
 *    - 将对应的UI脚本挂载到面板上
 *    - 在Inspector中拖拽绑定UI元素引用
 * 
 * 8. 设置UIManager：
 *    - 创建空物体，命名为"UIManager"
 *    - 挂载UIManager脚本
 *    - 绑定各个面板引用
 * 
 * 9. 设置GameEngine：
 *    - 创建空物体，命名为"GameEngine"
 *    - 挂载GameEngine脚本
 *    - 绑定UIManager引用
 */

public class UISetupGuide : MonoBehaviour
{
    [Header("UI References")]
    public Canvas mainCanvas;
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    
    [Header("Game Panels")]
    public GameObject eventPanel;
    public GameObject buildingPanel;
    public GameObject technologyPanel;
    public GameObject resourcePanel;
    public GameObject diplomacyPanel;
    public GameObject achievementPanel;
    
    [Header("Prefabs")]
    public GameObject eventItemPrefab;
    public GameObject buildingItemPrefab;
    public GameObject technologyItemPrefab;
    public GameObject resourceItemPrefab;
    
    void Start()
    {
        // 初始显示主菜单
        ShowMainMenu();
    }
    
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
    
    public void ShowGame()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    
    public void ShowEventPanel()
    {
        HideAllGamePanels();
        eventPanel.SetActive(true);
    }
    
    public void ShowBuildingPanel()
    {
        HideAllGamePanels();
        buildingPanel.SetActive(true);
    }
    
    public void ShowTechnologyPanel()
    {
        HideAllGamePanels();
        technologyPanel.SetActive(true);
    }
    
    public void ShowResourcePanel()
    {
        HideAllGamePanels();
        resourcePanel.SetActive(true);
    }
    
    public void ShowDiplomacyPanel()
    {
        HideAllGamePanels();
        diplomacyPanel.SetActive(true);
    }
    
    public void ShowAchievementPanel()
    {
        HideAllGamePanels();
        achievementPanel.SetActive(true);
    }
    
    private void HideAllGamePanels()
    {
        eventPanel.SetActive(false);
        buildingPanel.SetActive(false);
        technologyPanel.SetActive(false);
        resourcePanel.SetActive(false);
        diplomacyPanel.SetActive(false);
        achievementPanel.SetActive(false);
    }
} 