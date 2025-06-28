using UnityEngine;
using UnityEngine.UI;

public class ResourceItemUI : MonoBehaviour
{
    [Header("Resource Display")]
    public Text resourceNameText;
    public Text resourceAmountText;
    public Text resourceDescriptionText;
    public Image resourceIcon;
    
    private ResourceModel resourceData;
    
    public void SetupResource(ResourceModel resource)
    {
        resourceData = resource;
        UpdateDisplay();
    }
    
    private void UpdateDisplay()
    {
        if (resourceData == null) return;
        
        if (resourceNameText != null)
            resourceNameText.text = resourceData.resourceName;
        
        if (resourceAmountText != null)
            resourceAmountText.text = resourceData.amount.ToString();
        
        if (resourceDescriptionText != null)
            resourceDescriptionText.text = GetResourceDescription(resourceData.resourceID);
    }
    
    private string GetResourceDescription(string resourceID)
    {
        switch (resourceID)
        {
            case "RES001": return "基础劳动力，用于建造和生产";
            case "RES002": return "基础建筑材料，用于建造建筑";
            case "RES003": return "重要工业资源，用于高级建筑";
            case "RES004": return "导电材料，用于电力设施";
            case "RES005": return "通用货币，用于贸易和升级";
            case "RES006": return "维持人口生存的基本需求";
            case "RES007": return "研究新技术的关键人才";
            case "RES008": return "管理城市发展的专业人才";
            case "RES009": return "神秘能量，用于特殊建筑";
            case "RES010": return "对外关系的影响力";
            case "RES011": return "知识积累，用于研究技术";
            default: return "未知资源";
        }
    }
} 