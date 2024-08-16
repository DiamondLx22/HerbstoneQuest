using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private GameState gameState;
    private StateManager stateManager;
    
    [SerializeField] private InventorySlot[] inventorySlots;

    [Header("Item Description")]
    [SerializeField] private GameObject itemDescriptionContainer;
    [SerializeField] private TextMeshProUGUI itemHeaderText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private Image itemImage;
    
    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        stateManager = FindObjectOfType<StateManager>();
    }
    
    public void RefreshInventory()
    {
        List<State> currentStateList = gameState.GetStateList();
        
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < currentStateList.Count)
            {
                StateInfo newStateInfo = stateManager.GetStateInfoById(currentStateList[i].id);
                newStateInfo.amount = currentStateList[i].amount;
                inventorySlots[i].SetStateInfo(newStateInfo);
            }
            else
            {
                //#TODO Turn off Toggle
                inventorySlots[i].ChangeVisuals(false);
                
            }
        }
    }

    public void ShowItemDescription(StateInfo stateInfo)
    {
        itemDescriptionContainer.SetActive(true);
        itemHeaderText.SetText(stateInfo.name);
        itemDescriptionText.SetText(stateInfo.description);
        itemImage.sprite = stateInfo.icon;
    }
}
