using UnityEngine;
using UnityEngine.UI;
using System;

public class TechnologyItemUI : MonoBehaviour
{
    [Header("Technology Display")]
    public Text technologyNameText;
    public Text technologyTypeText;
    public Text technologyLevelText;
    public Text technologyCostText;
    public Button selectButton;
    
    private TechnologyModel technologyData;
    public event Action<TechnologyModel> OnTechnologySelected;
    
    private void Start()
    {
        if (selectButton != null)
            selectButton.onClick.AddListener(OnSelectTechnology);
    }
    
    public void SetupTechnology(TechnologyModel technology)
    {
        technologyData = technology;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        if (technologyData == null) return;
        
        if (technologyNameText != null)
            technologyNameText.text = technologyData.techName;
        
        if (technologyTypeText != null)
            technologyTypeText.text = GetTechnologyTypeString(technologyData.techCategory);
        
        if (technologyLevelText != null)
            technologyLevelText.text = $"等级: 1"; // 技术默认等级为1
        
        if (technologyCostText != null)
            technologyCostText.text = $"成本: {technologyData.researchCost}";
    }
    
    private string GetTechnologyTypeString(string type)
    {
        switch (type?.ToLower())
        {
            case "agriculture": return "农业技术";
            case "industry": return "工业技术";
            case "defense": return "防御技术";
            case "environment": return "环境技术";
            case "social": return "社会技术";
            case "research": return "研究技术";
            default: return "基础技术";
        }
    }
    
    private void OnSelectTechnology()
    {
        OnTechnologySelected?.Invoke(technologyData);
    }
} 