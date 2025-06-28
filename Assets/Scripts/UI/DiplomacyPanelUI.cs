using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DiplomacyPanelUI : MonoBehaviour
{
    public Transform diplomacyListContainer;
    public GameObject diplomacyItemPrefab;
    public Text diplomacyNameText;
    public Text diplomacyStatusText;
    public Button startDiplomacyButton;
    public Button endDiplomacyButton;

    private List<GameObject> diplomacyItems = new List<GameObject>();
    private DiplomacySystem diplomacySystem;
    private DiplomaticModel selectedDiplomacy;

    void Start()
    {
        diplomacySystem = GameEngine.Instance.diplomacySystem;
        RefreshDiplomacyList();
    }

    public void RefreshDiplomacyList()
    {
        foreach (var item in diplomacyItems)
            Destroy(item);
        diplomacyItems.Clear();

        var diplomacies = diplomacySystem.availableDiplomacies;
        foreach (var dip in diplomacies)
        {
            var go = Instantiate(diplomacyItemPrefab, diplomacyListContainer);
            var ui = go.GetComponent<DiplomacyItemUI>();
            if (ui != null)
                ui.Setup(dip, OnSelectDiplomacy);
            diplomacyItems.Add(go);
        }
    }

    void OnSelectDiplomacy(DiplomaticModel dip)
    {
        selectedDiplomacy = dip;
        diplomacyNameText.text = dip.diplomacyName;
        diplomacyStatusText.text = dip.status;
        startDiplomacyButton.onClick.RemoveAllListeners();
        endDiplomacyButton.onClick.RemoveAllListeners();
        startDiplomacyButton.onClick.AddListener(() => StartDiplomacy(dip));
        endDiplomacyButton.onClick.AddListener(() => EndDiplomacy(dip));
    }

    void StartDiplomacy(DiplomaticModel dip)
    {
        diplomacySystem.StartDiplomacy(dip.diplomacyID);
        RefreshDiplomacyList();
    }

    void EndDiplomacy(DiplomaticModel dip)
    {
        diplomacySystem.EndDiplomacy(dip.diplomacyID);
        RefreshDiplomacyList();
    }
} 