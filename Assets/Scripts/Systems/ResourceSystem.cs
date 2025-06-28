using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem
{
    private Dictionary<string, ResourceModel> resources;
    private Dictionary<string, int> currentResources;
    private Dictionary<string, int> maxStorage;

    public Dictionary<string, int> CurrentResources => new Dictionary<string, int>(currentResources);
    public Dictionary<string, int> MaxStorage => new Dictionary<string, int>(maxStorage);

    public void Initialize()
    {
        resources = new Dictionary<string, ResourceModel>();
        currentResources = new Dictionary<string, int>();
        maxStorage = new Dictionary<string, int>();

        var resourceData = DataManager.Instance.Resources;
        if (resourceData != null && resourceData.resources != null)
        {
            foreach (var resource in resourceData.resources)
            {
                resources[resource.resourceID] = resource;
                currentResources[resource.resourceID] = resource.baseValue;
                maxStorage[resource.resourceID] = resource.maxStorage;
            }
        }

        Debug.Log($"资源系统初始化完成: {resources.Count} 个资源");
    }

    public void UpdateResources()
    {
        foreach (var resource in resources.Values)
        {
            if (resource.regenerationRate > 0)
            {
                AddResource(resource.resourceID, (int)resource.regenerationRate);
            }
        }
    }

    public bool ConsumeResource(string resourceID, int amount)
    {
        if (currentResources.ContainsKey(resourceID) && currentResources[resourceID] >= amount)
        {
            currentResources[resourceID] -= amount;
            return true;
        }
        return false;
    }

    public void AddResource(string resourceID, int amount)
    {
        if (currentResources.ContainsKey(resourceID))
        {
            var maxStorage = this.maxStorage[resourceID];
            var newAmount = Mathf.Min(currentResources[resourceID] + amount, maxStorage);
            var actualChange = newAmount - currentResources[resourceID];
            currentResources[resourceID] = newAmount;
        }
    }

    public int GetResourceAmount(string resourceID)
    {
        return currentResources.ContainsKey(resourceID) ? currentResources[resourceID] : 0;
    }

    public int GetMaxStorage(string resourceID)
    {
        return maxStorage.ContainsKey(resourceID) ? maxStorage[resourceID] : 0;
    }

    public void SetResourceAmount(string resourceID, int amount)
    {
        if (currentResources.ContainsKey(resourceID))
        {
            var oldAmount = currentResources[resourceID];
            currentResources[resourceID] = Mathf.Min(amount, maxStorage[resourceID]);
        }
    }

    public List<ResourceModel> GetAllResources()
    {
        return new List<ResourceModel>(resources.Values);
    }

    public ResourceModel GetResource(string resourceID)
    {
        return resources.ContainsKey(resourceID) ? resources[resourceID] : null;
    }
}