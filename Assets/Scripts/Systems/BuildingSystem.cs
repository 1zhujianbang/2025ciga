using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem
{
    private Dictionary<string, BuildingModel> buildings;
    private Dictionary<string, int> builtBuildings;
    private ResourceSystem resourceSystem;

    public Dictionary<string, int> BuiltBuildings => new Dictionary<string, int>(builtBuildings);

    public void Initialize(ResourceSystem resourceSystem = null)
    {
        buildings = new Dictionary<string, BuildingModel>();
        builtBuildings = new Dictionary<string, int>();
        this.resourceSystem = resourceSystem;

        var buildingData = DataManager.Instance.Buildings;
        if (buildingData != null && buildingData.buildings != null)
        {
            foreach (var building in buildingData.buildings)
            {
                buildings[building.buildingID] = building;
                builtBuildings[building.buildingID] = 0;
            }
        }

        Debug.Log($"建筑系统初始化完成: {buildings.Count} 个建筑");
    }

    public bool CanBuildBuilding(string buildingID)
    {
        if (!buildings.ContainsKey(buildingID))
        {
            return false;
        }

        var building = buildings[buildingID];
        
        if (resourceSystem != null)
        {
            // 检查资源是否足够
            if (building.costWood > 0 && resourceSystem.GetResourceAmount("RES002") < building.costWood)
                return false;
            if (building.costIron > 0 && resourceSystem.GetResourceAmount("RES003") < building.costIron)
                return false;
            if (building.costCopper > 0 && resourceSystem.GetResourceAmount("RES004") < building.costCopper)
                return false;
            if (building.costGold > 0 && resourceSystem.GetResourceAmount("RES005") < building.costGold)
                return false;
            if (building.costSpiritEnergy > 0 && resourceSystem.GetResourceAmount("RES009") < building.costSpiritEnergy)
                return false;
        }

        return true;
    }

    public bool BuildBuilding(string buildingID)
    {
        if (!CanBuildBuilding(buildingID))
        {
            return false;
        }

        var building = buildings[buildingID];

        // 消耗资源
        if (resourceSystem != null)
        {
            if (building.costWood > 0)
                resourceSystem.ConsumeResource("RES002", building.costWood);
            if (building.costIron > 0)
                resourceSystem.ConsumeResource("RES003", building.costIron);
            if (building.costCopper > 0)
                resourceSystem.ConsumeResource("RES004", building.costCopper);
            if (building.costGold > 0)
                resourceSystem.ConsumeResource("RES005", building.costGold);
            if (building.costSpiritEnergy > 0)
                resourceSystem.ConsumeResource("RES009", building.costSpiritEnergy);
        }

        // 建造建筑
        builtBuildings[buildingID]++;
        Debug.Log($"建造建筑: {building.buildingName}");

        return true;
    }

    public void UpdateBuildings()
    {
        foreach (var building in buildings.Values)
        {
            var count = builtBuildings[building.buildingID];
            if (count > 0 && resourceSystem != null)
            {
                // 建筑生产资源
                if (building.productionRate > 0)
                {
                    var production = building.productionRate * count;
                    switch (building.buildingCategory)
                    {
                        case "Production":
                            if (building.buildingName.Contains("Farm"))
                                resourceSystem.AddResource("RES006", production); // Food
                            else if (building.buildingName.Contains("Lumber"))
                                resourceSystem.AddResource("RES002", production); // Wood
                            else if (building.buildingName.Contains("Mine"))
                                resourceSystem.AddResource("RES003", production); // Iron
                            break;
                    }
                }

                // 建筑维护费用
                if (building.maintenanceCost > 0)
                {
                    var maintenance = building.maintenanceCost * count;
                    resourceSystem.ConsumeResource("RES005", maintenance);
                }
            }
        }
    }

    public int GetBuildingCount(string buildingID)
    {
        return builtBuildings.ContainsKey(buildingID) ? builtBuildings[buildingID] : 0;
    }

    public BuildingModel GetBuilding(string buildingID)
    {
        return buildings.ContainsKey(buildingID) ? buildings[buildingID] : null;
    }

    public List<BuildingModel> GetAllBuildings()
    {
        return new List<BuildingModel>(buildings.Values);
    }

    public List<BuildingModel> GetAvailableBuildings()
    {
        var available = new List<BuildingModel>();
        foreach (var building in buildings.Values)
        {
            if (CanBuildBuilding(building.buildingID))
            {
                available.Add(building);
            }
        }
        return available;
    }

    public void SetBuildingCount(string buildingID, int count)
    {
        if (builtBuildings.ContainsKey(buildingID))
        {
            builtBuildings[buildingID] = Mathf.Max(0, count);
        }
    }

    public void SetResourceSystem(ResourceSystem resourceSystem)
    {
        this.resourceSystem = resourceSystem;
    }
    
    public bool UpgradeBuilding(string buildingID)
    {
        if (!buildings.ContainsKey(buildingID) || builtBuildings[buildingID] <= 0)
        {
            return false;
        }

        var building = buildings[buildingID];
        
        // 检查升级资源需求（这里简化处理，使用建造成本的一半）
        if (resourceSystem != null)
        {
            var upgradeCostWood = building.costWood / 2;
            var upgradeCostIron = building.costIron / 2;
            
            if (upgradeCostWood > 0 && resourceSystem.GetResourceAmount("RES002") < upgradeCostWood)
                return false;
            if (upgradeCostIron > 0 && resourceSystem.GetResourceAmount("RES003") < upgradeCostIron)
                return false;
            
            // 消耗升级资源
            if (upgradeCostWood > 0)
                resourceSystem.ConsumeResource("RES002", upgradeCostWood);
            if (upgradeCostIron > 0)
                resourceSystem.ConsumeResource("RES003", upgradeCostIron);
        }

        Debug.Log($"升级建筑: {building.buildingName}");
        return true;
    }
    
    public bool DemolishBuilding(string buildingID)
    {
        if (!buildings.ContainsKey(buildingID) || builtBuildings[buildingID] <= 0)
        {
            return false;
        }

        var building = buildings[buildingID];
        
        // 拆除建筑
        builtBuildings[buildingID]--;
        
        // 返还部分资源（这里简化处理，返还建造成本的1/4）
        if (resourceSystem != null)
        {
            var refundWood = building.costWood / 4;
            var refundIron = building.costIron / 4;
            
            if (refundWood > 0)
                resourceSystem.AddResource("RES002", refundWood);
            if (refundIron > 0)
                resourceSystem.AddResource("RES003", refundIron);
        }

        Debug.Log($"拆除建筑: {building.buildingName}");
        return true;
    }
}