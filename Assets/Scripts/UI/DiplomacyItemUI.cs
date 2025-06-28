using UnityEngine;
using UnityEngine.UI;
using System;

public class DiplomacyItemUI : MonoBehaviour
{
    public Text diplomacyNameText;
    public Text diplomacyStatusText;
    public Button selectButton;

    private DiplomaticModel diplomacyData;
    public Action<DiplomaticModel> OnDiplomacySelected;

    public void Setup(DiplomaticModel model, Action<DiplomaticModel> onSelect)
    {
        diplomacyData = model;
        diplomacyNameText.text = model.diplomacyName;
        diplomacyStatusText.text = model.status;
        OnDiplomacySelected = onSelect;
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => OnDiplomacySelected?.Invoke(diplomacyData));
    }
} 