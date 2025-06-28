using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplayUI : MonoBehaviour
{
    [Header("UI Elements")]
    public Text nameText;
    public Text valueText;
    public Image iconImage;
    public Image backgroundImage;
    
    private ResourceModel resource;
    private GameManager gameManager;
    
    public void SetupResource(ResourceModel resource)
    {
        this.resource = resource;
        gameManager = GameManager.Instance;
        
        if (nameText != null)
        {
            nameText.text = resource.resourceName;
        }
        
        UpdateDisplay();
    }
    
    public void UpdateDisplay()
    {
        if (gameManager != null && gameManager.resourceSystem != null && resource != null)
        {
            var currentAmount = gameManager.resourceSystem.GetResourceAmount(resource.resourceID);
            var maxStorage = gameManager.resourceSystem.GetMaxStorage(resource.resourceID);
            
            if (valueText != null)
            {
                if (resource.resourceType == "Population")
                {
                    valueText.text = currentAmount.ToString();
                }
                else
                {
                    valueText.text = $"{currentAmount}/{maxStorage}";
                }
            }
            
            // 根据储量百分比改变颜色
            if (maxStorage > 0 && backgroundImage != null)
            {
                var percentage = (float)currentAmount / maxStorage;
                if (percentage >= 0.8f)
                {
                    backgroundImage.color = new Color(0.3f, 0.7f, 0.3f); // 绿色
                }
                else if (percentage >= 0.5f)
                {
                    backgroundImage.color = new Color(1f, 0.6f, 0f); // 橙色
                }
                else if (percentage >= 0.2f)
                {
                    backgroundImage.color = new Color(1f, 0.8f, 0f); // 黄色
                }
                else
                {
                    backgroundImage.color = new Color(0.9f, 0.3f, 0.3f); // 红色
                }
            }
        }
    }
    
    private string GetResourceIcon(string resourceName)
    {
        return resourceName switch
        {
            "Water" => "💧",
            "Wood" => "🪵",
            "Iron" => "⛏️",
            "Food" => "🍎",
            "Workers" => "👷",
            "Scientists" => "��‍��",
            "Managers" => "👔",
            "Gold" => "💰",
            "SpiritEnergy" => "✨",
            "Knowledge" => "📚",
            "DiplomaticCredits" => "��",
            _ => "��"
        };
    }
}