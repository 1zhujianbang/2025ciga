using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TechnologyPanelUI : MonoBehaviour
{
    [Header("Technology Display")]
    public Transform technologyContainer;
    public GameObject technologyItemPrefab;
    public Text selectedTechnologyText;
    public Text technologyDescriptionText;
    public Text technologyCostText;
    
    [Header("Technology Controls")]
    public Button researchButton;
    public Button upgradeButton;
    public Button closeButton;
    
    [Header("Technology Info")]
    public Text technologyNameText;
    public Text technologyLevelText;
    public Text technologyEffectText;
    public Text technologyPrerequisitesText;
    
    private List<GameObject> technologyItems = new List<GameObject>();
    private TechnologyModel selectedTechnology;
    private TechnologySystem technologySystem;
    
    private void Start()
    {
        technologySystem = GameEngine.Instance?.technologySystem;
        SetupButtons();
        RefreshTechnologyList();
    }
    
    private void SetupButtons()
    {
        if (researchButton != null)
            researchButton.onClick.AddListener(OnResearchTechnology);
        
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(OnUpgradeTechnology);
        
        if (closeButton != null)
            closeButton.onClick.AddListener(OnCloseTechnology);
    }
    
    public void RefreshTechnologyList()
    {
        // 清除现有技术项
        foreach (var item in technologyItems)
        {
            if (item != null)
                Destroy(item);
        }
        technologyItems.Clear();
        
        if (technologySystem != null)
        {
            var technologies = technologySystem.GetAvailableTechnologies();
            foreach (var tech in technologies)
            {
                CreateTechnologyItem(tech);
            }
        }
    }
    
    private void CreateTechnologyItem(TechnologyModel technology)
    {
        if (technologyItemPrefab != null && technologyContainer != null)
        {
            var item = Instantiate(technologyItemPrefab, technologyContainer);
            var technologyItemUI = item.GetComponent<TechnologyItemUI>();
            
            if (technologyItemUI != null)
            {
                technologyItemUI.SetupTechnology(technology);
                technologyItemUI.OnTechnologySelected += OnTechnologySelected;
            }
            
            technologyItems.Add(item);
        }
    }
    
    private void OnTechnologySelected(TechnologyModel technology)
    {
        selectedTechnology = technology;
        ShowTechnologyDetails(technology);
    }
    
    private void ShowTechnologyDetails(TechnologyModel technology)
    {
        if (technologyNameText != null)
            technologyNameText.text = technology.techName;
        
        if (technologyDescriptionText != null)
            technologyDescriptionText.text = technology.description;
        
        if (technologyCostText != null)
            technologyCostText.text = $"研究成本: {technology.researchCost}";
        
        if (technologyLevelText != null)
            technologyLevelText.text = $"等级: 1";
        
        if (technologyEffectText != null)
            technologyEffectText.text = $"效果: {technology.description}";
        
        if (technologyPrerequisitesText != null)
            technologyPrerequisitesText.text = $"前置条件: {technology.prerequisites}";
        
        // 显示技术操作按钮
        if (researchButton != null)
            researchButton.gameObject.SetActive(true);
        
        if (upgradeButton != null)
            upgradeButton.gameObject.SetActive(false); // 暂时禁用升级
    }
    
    private void OnResearchTechnology()
    {
        if (selectedTechnology != null && technologySystem != null)
        {
            technologySystem.ResearchTechnology(selectedTechnology.techID);
            RefreshTechnologyList();
            ClearTechnologyDetails();
        }
    }
    
    private void OnUpgradeTechnology()
    {
        if (selectedTechnology != null && technologySystem != null)
        {
            technologySystem.UpgradeTechnology(selectedTechnology.techID);
            RefreshTechnologyList();
            ClearTechnologyDetails();
        }
    }
    
    private void OnCloseTechnology()
    {
        ClearTechnologyDetails();
    }
    
    private void ClearTechnologyDetails()
    {
        selectedTechnology = null;
        
        if (technologyNameText != null)
            technologyNameText.text = "";
        
        if (technologyDescriptionText != null)
            technologyDescriptionText.text = "";
        
        if (technologyCostText != null)
            technologyCostText.text = "";
        
        if (technologyLevelText != null)
            technologyLevelText.text = "";
        
        if (technologyEffectText != null)
            technologyEffectText.text = "";
        
        if (technologyPrerequisitesText != null)
            technologyPrerequisitesText.text = "";
        
        if (researchButton != null)
            researchButton.gameObject.SetActive(false);
        
        if (upgradeButton != null)
            upgradeButton.gameObject.SetActive(false);
    }
} 