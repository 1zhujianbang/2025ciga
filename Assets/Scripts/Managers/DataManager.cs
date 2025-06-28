using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    
    public ResourceData Resources { get; private set; }
    public BuildingData Buildings { get; private set; }
    public TechnologyData Technologies { get; private set; }
    public DiplomacyData Diplomacy { get; private set; }
    public EventData Events { get; private set; }
    public NaturalElementData NaturalElements { get; private set; }
    public MeasureData Measures { get; private set; }
    public BalanceData Balances { get; private set; }
    public AchievementData Achievements { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadAllData()
    {
        Debug.Log("开始加载游戏数据...");
        
        try
        {
            Resources = LoadJsonData<ResourceData>("Data/Resources");
            Buildings = LoadJsonData<BuildingData>("Data/Buildings");
            Technologies = LoadJsonData<TechnologyData>("Data/Technologies");
            Diplomacy = LoadJsonData<DiplomacyData>("Data/Diplomacy");
            Events = LoadJsonData<EventData>("Data/Events");
            NaturalElements = LoadJsonData<NaturalElementData>("Data/NaturalElements");
            Measures = LoadJsonData<MeasureData>("Data/Measures");
            Balances = LoadJsonData<BalanceData>("Data/Balance");
            Achievements = LoadJsonData<AchievementData>("Data/Achievements");
            
            Debug.Log("游戏数据加载完成");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"加载数据失败: {ex.Message}");
        }
    }
    
    private T LoadJsonData<T>(string path)
    {
        TextAsset jsonFile = UnityEngine.Resources.Load<TextAsset>(path);
        if (jsonFile != null)
        {
            return JsonUtility.FromJson<T>(jsonFile.text);
        }
        Debug.LogWarning($"未找到数据文件: {path}");
        return default(T);
    }
}