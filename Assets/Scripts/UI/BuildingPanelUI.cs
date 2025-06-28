using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuildingPanelUI : MonoBehaviour
{
    [Header("Building Display")]
    public Transform buildingContainer;
    public GameObject buildingItemPrefab;
    public Text selectedBuildingText;
    public Text buildingDescriptionText;
    public Text buildingCostText;
    
    [Header("Building Controls")]
    public Button buildButton;
    public Button upgradeButton;
    public Button demolishButton;
    public Button closeButton;
    
    [Header("Building Info")]
    public Text buildingNameText;
    public Text buildingLevelText;
    public Text buildingEffectText;
    
    private List<GameObject> buildingItems = new List<GameObject>();
    private BuildingModel selectedBuilding;
    private BuildingSystem buildingSystem;
    
    private void Start()
    {
        buildingSystem = GameEngine.Instance?.buildingSystem;
        SetupButtons();
        RefreshBuildingList();
    }
    
    private void SetupButtons()
    {
        if (buildButton != null)
            buildButton.onClick.AddListener(OnBuildBuilding);
        
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(OnUpgradeBuilding);
        
        if (demolishButton != null)
            demolishButton.onClick.AddListener(OnDemolishBuilding);
        
        if (closeButton != null)
            closeButton.onClick.AddListener(OnCloseBuilding);
    }
    
    public void RefreshBuildingList()
    {
        // 清除现有建筑项
        foreach (var item in buildingItems)
        {
            if (item != null)
                Destroy(item);
        }
        buildingItems.Clear();
        
        if (buildingSystem != null)
        {
            var buildings = buildingSystem.GetAvailableBuildings();
            foreach (var building in buildings)
            {
                CreateBuildingItem(building);
            }
        }
    }
    
    private void CreateBuildingItem(BuildingModel building)
    {
        if (buildingItemPrefab != null && buildingContainer != null)
        {
            var item = Instantiate(buildingItemPrefab, buildingContainer);
            var buildingItemUI = item.GetComponent<BuildingItemUI>();
            
            if (buildingItemUI != null)
            {
                buildingItemUI.SetupBuilding(building);
                buildingItemUI.OnBuildingSelected += OnBuildingSelected;
            }
            
            buildingItems.Add(item);
        }
    }
    
    private void OnBuildingSelected(BuildingModel building)
    {
        selectedBuilding = building;
        ShowBuildingDetails(building);
    }
    
    private void ShowBuildingDetails(BuildingModel building)
    {
        if (buildingNameText != null)
            buildingNameText.text = building.buildingName;
        
        if (buildingDescriptionText != null)
            buildingDescriptionText.text = building.description;
        
        if (buildingCostText != null)
            buildingCostText.text = $"成本: {building.costWood}木材, {building.costIron}铁矿";
        
        if (buildingLevelText != null)
            buildingLevelText.text = $"等级: 1";
        
        if (buildingEffectText != null)
            buildingEffectText.text = $"效果: {building.productionRate}";
        
        // 显示建筑操作按钮
        if (buildButton != null)
            buildButton.gameObject.SetActive(true);
        
        if (upgradeButton != null)
            upgradeButton.gameObject.SetActive(false); // 暂时禁用升级
        
        if (demolishButton != null)
            demolishButton.gameObject.SetActive(false); // 暂时禁用拆除
    }
    
    private void OnBuildBuilding()
    {
        if (selectedBuilding != null && buildingSystem != null)
        {
            buildingSystem.BuildBuilding(selectedBuilding.buildingID);
            RefreshBuildingList();
            ClearBuildingDetails();
        }
    }
    
    private void OnUpgradeBuilding()
    {
        if (selectedBuilding != null && buildingSystem != null)
        {
            buildingSystem.UpgradeBuilding(selectedBuilding.buildingID);
            RefreshBuildingList();
            ClearBuildingDetails();
        }
    }
    
    private void OnDemolishBuilding()
    {
        if (selectedBuilding != null && buildingSystem != null)
        {
            buildingSystem.DemolishBuilding(selectedBuilding.buildingID);
            RefreshBuildingList();
            ClearBuildingDetails();
        }
    }
    
    private void OnCloseBuilding()
    {
        ClearBuildingDetails();
    }
    
    private void ClearBuildingDetails()
    {
        selectedBuilding = null;
        
        if (buildingNameText != null)
            buildingNameText.text = "";
        
        if (buildingDescriptionText != null)
            buildingDescriptionText.text = "";
        
        if (buildingCostText != null)
            buildingCostText.text = "";
        
        if (buildingLevelText != null)
            buildingLevelText.text = "";
        
        if (buildingEffectText != null)
            buildingEffectText.text = "";
        
        if (buildButton != null)
            buildButton.gameObject.SetActive(false);
        
        if (upgradeButton != null)
            upgradeButton.gameObject.SetActive(false);
        
        if (demolishButton != null)
            demolishButton.gameObject.SetActive(false);
    }
} 