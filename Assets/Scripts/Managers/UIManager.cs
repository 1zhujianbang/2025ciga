using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;
    
    [Header("Game UI")]
    public GameObject resourcePanel;
    public GameObject buildingPanel;
    public GameObject technologyPanel;
    public GameObject diplomacyPanel;
    public GameObject eventPanel;
    public GameObject achievementPanel;
    
    private void Start()
    {
        ShowMainMenu();
    }
    
    public void ShowMainMenu()
    {
        HideAllPanels();
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }
    }
    
    public void ShowGame()
    {
        HideAllPanels();
        if (gamePanel != null)
        {
            gamePanel.SetActive(true);
        }
    }
    
    public void ShowSettings()
    {
        HideAllPanels();
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }
    
    private void HideAllPanels()
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
        if (gamePanel != null) gamePanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
    }
    
    // 游戏内UI切换方法
    public void ShowResourcePanel()
    {
        HideGamePanels();
        if (resourcePanel != null) resourcePanel.SetActive(true);
    }
    
    public void ShowBuildingPanel()
    {
        HideGamePanels();
        if (buildingPanel != null) buildingPanel.SetActive(true);
    }
    
    public void ShowTechnologyPanel()
    {
        HideGamePanels();
        if (technologyPanel != null) technologyPanel.SetActive(true);
    }
    
    public void ShowDiplomacyPanel()
    {
        HideGamePanels();
        if (diplomacyPanel != null) diplomacyPanel.SetActive(true);
    }
    
    public void ShowEventPanel()
    {
        HideGamePanels();
        if (eventPanel != null) eventPanel.SetActive(true);
    }
    
    public void ShowAchievementPanel()
    {
        HideGamePanels();
        if (achievementPanel != null) achievementPanel.SetActive(true);
    }
    
    private void HideGamePanels()
    {
        if (resourcePanel != null) resourcePanel.SetActive(false);
        if (buildingPanel != null) buildingPanel.SetActive(false);
        if (technologyPanel != null) technologyPanel.SetActive(false);
        if (diplomacyPanel != null) diplomacyPanel.SetActive(false);
        if (eventPanel != null) eventPanel.SetActive(false);
        if (achievementPanel != null) achievementPanel.SetActive(false);
    }
}