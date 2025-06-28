using UnityEngine;
using UnityEngine.UI;
using System;

public class BuildingItemUI : MonoBehaviour
{
    [Header("Building Display")]
    public Text buildingNameText;
    public Text buildingTypeText;
    public Text buildingLevelText;
    public Text buildingCostText;
    public Button selectButton;
    
    private BuildingModel buildingData;
    public event Action<BuildingModel> OnBuildingSelected;
    
    private void Start()
    {
        if (selectButton != null)
            selectButton.onClick.AddListener(OnSelectBuilding);
    }
    
    public void SetupBuilding(BuildingModel building)
    {
        buildingData = building;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        if (buildingData == null) return;
        
        if (buildingNameText != null)
            buildingNameText.text = buildingData.buildingName;
        
        if (buildingTypeText != null)
            buildingTypeText.text = GetBuildingTypeString(buildingData.buildingType);
        
        if (buildingLevelText != null)
            buildingLevelText.text = $"等级: 1"; // 建筑默认等级为1
        
        if (buildingCostText != null)
            buildingCostText.text = $"成本: {buildingData.costWood}木材, {buildingData.costIron}铁矿";
    }
    
    private string GetBuildingTypeString(string type)
    {
        switch (type?.ToLower())
        {
            case "production": return "生产建筑";
            case "defense": return "防御建筑";
            case "utility": return "功能建筑";
            case "cultural": return "文化建筑";
            case "research": return "研究建筑";
            default: return "普通建筑";
        }
    }
    
    private void OnSelectBuilding()
    {
        OnBuildingSelected?.Invoke(buildingData);
    }
} 