using System.Collections.Generic;
using UnityEngine;

public class TechnologySystem
{
    private Dictionary<string, TechnologyModel> technologies;
    private Dictionary<string, bool> researchedTechnologies;
    private Dictionary<string, int> researchProgress;
    private ResourceSystem resourceSystem;

    public Dictionary<string, bool> ResearchedTechnologies => new Dictionary<string, bool>(researchedTechnologies);

    public void Initialize(ResourceSystem resourceSystem = null)
    {
        technologies = new Dictionary<string, TechnologyModel>();
        researchedTechnologies = new Dictionary<string, bool>();
        researchProgress = new Dictionary<string, int>();
        this.resourceSystem = resourceSystem;

        var techData = DataManager.Instance.Technologies;
        if (techData != null && techData.technologies != null)
        {
            foreach (var tech in techData.technologies)
            {
                technologies[tech.techID] = tech;
                researchedTechnologies[tech.techID] = false;
                researchProgress[tech.techID] = 0;
            }
        }

        Debug.Log($"科技系统初始化完成: {technologies.Count} 个科技");
    }

    public bool CanResearchTechnology(string technologyID)
    {
        if (!technologies.ContainsKey(technologyID) || researchedTechnologies[technologyID])
        {
            return false;
        }

        var tech = technologies[technologyID];

        // 检查前置技术
        if (!string.IsNullOrEmpty(tech.prerequisites))
        {
            var prerequisites = tech.prerequisites.Split(';');
            foreach (var prereq in prerequisites)
            {
                if (!string.IsNullOrEmpty(prereq) && 
                    (!researchedTechnologies.ContainsKey(prereq) || !researchedTechnologies[prereq]))
                {
                    return false;
                }
            }
        }

        // 检查资源是否足够
        if (resourceSystem != null)
        {
            return resourceSystem.GetResourceAmount("RES011") >= tech.researchCost; // 使用知识资源
        }

        return true;
    }

    public bool ResearchTechnology(string technologyID)
    {
        if (!CanResearchTechnology(technologyID))
        {
            return false;
        }

        var tech = technologies[technologyID];

        // 消耗资源
        if (resourceSystem != null)
        {
            if (!resourceSystem.ConsumeResource("RES011", tech.researchCost))
            {
                return false;
            }
        }

        // 开始研究
        researchProgress[technologyID] = 0;
        Debug.Log($"开始研究科技: {tech.techName}");

        return true;
    }

    public void UpdateTechnologies()
    {
        foreach (var tech in technologies.Values)
        {
            if (!researchedTechnologies[tech.techID] && researchProgress[tech.techID] > 0)
            {
                researchProgress[tech.techID]++;

                if (researchProgress[tech.techID] >= tech.researchTime)
                {
                    CompleteTechnology(tech.techID);
                }
            }
        }
    }

    private void CompleteTechnology(string technologyID)
    {
        researchedTechnologies[technologyID] = true;
        researchProgress[technologyID] = 0;

        var tech = technologies[technologyID];
        Debug.Log($"科技研究完成: {tech.techName}");

        // 应用技术效果
        if (tech.getEffects != null)
        {
            foreach (var effect in tech.getEffects)
            {
                ApplyTechnologyEffect(effect);
            }
        }
    }

    private void ApplyTechnologyEffect(TechnologyEffect effect)
    {
        // 根据效果类型应用不同的效果
        switch (effect.effectType)
        {
            case "ResourceBonus":
                // 资源获取效率提升
                break;
            case "BuildingUnlock":
                // 解锁建筑
                break;
            case "PopulationBonus":
                // 人口满意度提升
                break;
            case "ConsciousnessBonus":
                // 意识觉醒概率提升
                break;
        }
    }

    public TechnologyModel GetTechnology(string technologyID)
    {
        return technologies.ContainsKey(technologyID) ? technologies[technologyID] : null;
    }

    public List<TechnologyModel> GetAllTechnologies()
    {
        return new List<TechnologyModel>(technologies.Values);
    }

    public List<TechnologyModel> GetAvailableTechnologies()
    {
        var available = new List<TechnologyModel>();
        foreach (var tech in technologies.Values)
        {
            if (CanResearchTechnology(tech.techID))
            {
                available.Add(tech);
            }
        }
        return available;
    }

    public List<TechnologyModel> GetResearchedTechnologies()
    {
        var researched = new List<TechnologyModel>();
        foreach (var tech in technologies.Values)
        {
            if (researchedTechnologies[tech.techID])
            {
                researched.Add(tech);
            }
        }
        return researched;
    }

    public int GetResearchProgress(string technologyID)
    {
        if (!technologies.ContainsKey(technologyID))
        {
            return 0;
        }

        var tech = technologies[technologyID];
        var progress = researchProgress[technologyID];
        return (int)((float)progress / tech.researchTime * 100);
    }

    public bool IsTechnologyResearched(string technologyID)
    {
        return researchedTechnologies.ContainsKey(technologyID) && researchedTechnologies[technologyID];
    }

    public bool IsTechnologyResearching(string technologyID)
    {
        return researchProgress.ContainsKey(technologyID) && researchProgress[technologyID] > 0;
    }

    public void SetTechnologyResearched(string technologyID, bool researched)
    {
        if (researchedTechnologies.ContainsKey(technologyID))
        {
            researchedTechnologies[technologyID] = researched;
        }
    }

    public void SetResourceSystem(ResourceSystem resourceSystem)
    {
        this.resourceSystem = resourceSystem;
    }

    public bool UpgradeTechnology(string technologyID)
    {
        if (!technologies.ContainsKey(technologyID) || !researchedTechnologies[technologyID])
        {
            return false;
        }

        var tech = technologies[technologyID];
        
        // 检查升级资源需求（这里简化处理，使用研究成本的一半）
        if (resourceSystem != null)
        {
            var upgradeCost = tech.researchCost / 2;
            if (resourceSystem.GetResourceAmount("RES011") < upgradeCost)
            {
                return false;
            }
            
            // 消耗升级资源
            if (!resourceSystem.ConsumeResource("RES011", upgradeCost))
            {
                return false;
            }
        }

        Debug.Log($"升级科技: {tech.techName}");
        
        // 这里可以添加升级逻辑，比如增加技术等级或效果
        return true;
    }
}