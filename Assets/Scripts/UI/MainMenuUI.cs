using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button startGameButton;
    public Button settingsButton;
    public Button exitButton;
    
    [Header("UI Elements")]
    public Text titleText;
    public Text subtitleText;
    public Text versionText;
    
    private UIManager uiManager;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        SetupButtons();
        SetupTexts();
    }
    
    private void SetupButtons()
    {
        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
        }
        
        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(OnSettingsClicked);
        }
        
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitClicked);
        }
    }
    
    private void SetupTexts()
    {
        if (titleText != null)
        {
            titleText.text = "Nature: Alive";
        }
        
        if (subtitleText != null)
        {
            subtitleText.text = "与自然和谐共生的策略游戏";
        }
        
        if (versionText != null)
        {
            versionText.text = "2025 Game Jam - Version 1.0";
        }
    }
    
    private void OnStartGameClicked()
    {
        Debug.Log("开始游戏按钮被点击");
        if (uiManager != null)
        {
            uiManager.ShowGame();
        }
    }
    
    private void OnSettingsClicked()
    {
        Debug.Log("设置按钮被点击");
        if (uiManager != null)
        {
            uiManager.ShowSettings();
        }
    }
    
    private void OnExitClicked()
    {
        Debug.Log("退出按钮被点击");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}