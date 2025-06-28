using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResourcePanelUI : MonoBehaviour
{
    [Header("Resource Display")]
    public Transform resourceContainer;
    public GameObject resourceItemPrefab;
    public Text totalPopulationText;
    public Text totalInfluenceText;
    
    private List<GameObject> resourceItems = new List<GameObject>();
    private ResourceSystem resourceSystem;
    
    private void Start()
    {
        resourceSystem = GameEngine.Instance?.resourceSystem;
        RefreshResourceList();
    }
    
    public void RefreshResourceList()
    {
        // 清除现有资源项
        foreach (var item in resourceItems)
        {
            if (item != null)
                Destroy(item);
        }
        resourceItems.Clear();
        
        if (resourceSystem != null)
        {
            var resources = resourceSystem.GetAllResources();
            foreach (var resource in resources)
            {
                CreateResourceItem(resource);
            }
            
            // 更新总人口和影响力
            UpdateTotalStats();
        }
    }
    
    private void CreateResourceItem(ResourceModel resource)
    {
        if (resourceItemPrefab != null && resourceContainer != null)
        {
            var item = Instantiate(resourceItemPrefab, resourceContainer);
            var resourceItemUI = item.GetComponent<ResourceItemUI>();
            
            if (resourceItemUI != null)
            {
                resourceItemUI.SetupResource(resource);
            }
            
            resourceItems.Add(item);
        }
    }
    
    private void UpdateTotalStats()
    {
        if (resourceSystem != null)
        {
            // 计算总人口
            var totalPopulation = resourceSystem.GetResourceAmount("RES001"); // 工人
            totalPopulation += resourceSystem.GetResourceAmount("RES007"); // 科学家
            totalPopulation += resourceSystem.GetResourceAmount("RES008"); // 管理者
            
            if (totalPopulationText != null)
                totalPopulationText.text = $"总人口: {totalPopulation}";
            
            // 计算总影响力
            var totalInfluence = resourceSystem.GetResourceAmount("RES010"); // 影响力
            
            if (totalInfluenceText != null)
                totalInfluenceText.text = $"总影响力: {totalInfluence}";
        }
    }
    
    public void UpdateDisplay()
    {
        RefreshResourceList();
    }
} 