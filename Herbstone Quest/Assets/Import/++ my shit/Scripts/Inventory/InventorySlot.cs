using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private StateInfo stateInfo;
    private InventoryManager inventoryManager;
    
    [SerializeField] private Toggle inventorySlotToggle;
    [SerializeField] private Image inventorySlotImage;
    [SerializeField] private TextMeshProUGUI inventorySlotAmount;

    public void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    
    public void SetStateInfo(StateInfo stateInfo)
    {
        this.stateInfo = stateInfo;
        SetVisuals();
    }

    public void SetVisuals()
    {
        ChangeVisuals(true);
        inventorySlotImage.sprite = stateInfo.icon;
        inventorySlotAmount.SetText(stateInfo.amount.ToString());
    }

    public void ChangeVisuals(bool value)
    {
        inventorySlotToggle.interactable = value;
        inventorySlotImage.gameObject.SetActive(value);
        inventorySlotAmount.gameObject.SetActive(value);
    }

    public void ShowItemDescription()
    {
        if(inventorySlotToggle.isOn)
            inventoryManager.ShowItemDescription(stateInfo);
    }
}
