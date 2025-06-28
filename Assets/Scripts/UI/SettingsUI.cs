using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("Settings Controls")]
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;
    public Dropdown languageDropdown;
    
    [Header("Buttons")]
    public Button saveButton;
    public Button cancelButton;
    public Button backButton;
    
    private UIManager uiManager;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        SetupControls();
        SetupButtons();
        LoadSettings();
    }
    
    private void SetupControls()
    {
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }
        
        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        }
        
        if (fullscreenToggle != null)
        {
            fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
        }
        
        if (qualityDropdown != null)
        {
            qualityDropdown.onValueChanged.AddListener(OnQualityChanged);
        }
        
        if (languageDropdown != null)
        {
            languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        }
    }
    
    private void SetupButtons()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(OnSaveClicked);
        }
        
        if (cancelButton != null)
        {
            cancelButton.onClick.AddListener(OnCancelClicked);
        }
        
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackClicked);
        }
    }
    
    private void LoadSettings()
    {
        // 加载保存的设置
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        }
        
        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.8f);
        }
        
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        }
        
        if (qualityDropdown != null)
        {
            qualityDropdown.value = PlayerPrefs.GetInt("Quality", 2);
        }
        
        if (languageDropdown != null)
        {
            languageDropdown.value = PlayerPrefs.GetInt("Language", 0);
        }
    }
    
    private void OnMusicVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        // 这里可以添加音乐音量控制逻辑
    }
    
    private void OnSFXVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("SFXVolume", value);
        // 这里可以添加音效音量控制逻辑
    }
    
    private void OnFullscreenChanged(bool value)
    {
        PlayerPrefs.SetInt("Fullscreen", value ? 1 : 0);
        Screen.fullScreen = value;
    }
    
    private void OnQualityChanged(int value)
    {
        PlayerPrefs.SetInt("Quality", value);
        QualitySettings.SetQualityLevel(value);
    }
    
    private void OnLanguageChanged(int value)
    {
        PlayerPrefs.SetInt("Language", value);
        // 这里可以添加语言切换逻辑
    }
    
    private void OnSaveClicked()
    {
        PlayerPrefs.Save();
        Debug.Log("设置已保存");
    }
    
    private void OnCancelClicked()
    {
        LoadSettings(); // 重新加载设置，取消更改
    }
    
    private void OnBackClicked()
    {
        if (uiManager != null)
        {
            uiManager.ShowMainMenu();
        }
    }
}