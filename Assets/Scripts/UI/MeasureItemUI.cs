using UnityEngine;
using UnityEngine.UI;
using System;

public class MeasureItemUI : MonoBehaviour
{
    public Text measureNameText;
    public Text measureDescText;
    public Button selectButton;

    private MeasureModel measureData;
    public Action<MeasureModel> OnMeasureSelected;

    public void Setup(MeasureModel model, Action<MeasureModel> onSelect)
    {
        measureData = model;
        measureNameText.text = model.measureName;
        measureDescText.text = model.description;
        OnMeasureSelected = onSelect;
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => OnMeasureSelected?.Invoke(measureData));
    }
} 