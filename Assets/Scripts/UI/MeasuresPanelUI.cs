using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MeasuresPanelUI : MonoBehaviour
{
    public Transform measuresListContainer;
    public GameObject measureItemPrefab;
    public Text measureNameText;
    public Text measureDescText;
    public Text measureCostText;
    public Button takeMeasureButton;

    private List<GameObject> measureItems = new List<GameObject>();
    private MeasuresSystem measuresSystem;
    private MeasureModel selectedMeasure;

    void Start()
    {
        measuresSystem = GameEngine.Instance.measuresSystem;
        RefreshMeasuresList();
    }

    public void RefreshMeasuresList()
    {
        foreach (var item in measureItems)
            Destroy(item);
        measureItems.Clear();

        var measures = measuresSystem.GetAllMeasures();
        foreach (var measure in measures)
        {
            var go = Instantiate(measureItemPrefab, measuresListContainer);
            var ui = go.GetComponent<MeasureItemUI>();
            if (ui != null)
                ui.Setup(measure, OnSelectMeasure);
            measureItems.Add(go);
        }
    }

    void OnSelectMeasure(MeasureModel measure)
    {
        selectedMeasure = measure;
        measureNameText.text = measure.measureName;
        measureDescText.text = measure.description;
        measureCostText.text = $"消耗：{measure.cost}";
        takeMeasureButton.onClick.RemoveAllListeners();
        takeMeasureButton.onClick.AddListener(() => TakeMeasure(measure));
    }

    void TakeMeasure(MeasureModel measure)
    {
        measuresSystem.TakeMeasure(measure.measureID);
        RefreshMeasuresList();
    }
} 