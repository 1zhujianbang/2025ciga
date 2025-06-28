using System.Collections.Generic;
using UnityEngine;

public class MeasuresSystem
{
    private List<MeasureModel> measures;

    public MeasuresSystem()
    {
        measures = new List<MeasureModel>();
        // 示例数据，可根据实际需求加载JSON等
        measures.Add(new MeasureModel { measureID = "M001", measureName = "限水令", description = "限制用水，缓解干旱。", cost = 10 });
        measures.Add(new MeasureModel { measureID = "M002", measureName = "节能倡议", description = "推广节能，减少消耗。", cost = 15 });
    }

    public List<MeasureModel> GetAllMeasures()
    {
        return measures;
    }

    public void TakeMeasure(string measureID)
    {
        Debug.Log($"执行措施: {measureID}");
        // 实际执行措施逻辑
    }
} 