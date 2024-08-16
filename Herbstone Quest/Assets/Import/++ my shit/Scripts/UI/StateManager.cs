using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StateManager : MonoBehaviour
{
    
    [SerializeField] private StateInfo[] stateinfos;

    [SerializeField] private TextMeshProUGUI text_header;
    [SerializeField] private TextMeshProUGUI text_description;
    [SerializeField] private Image item_icon;
    
    [Header("Selected Item Panel")]
    private GameController gameController;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private Button continueButton;
    
    void Start()
    {
        itemPanel.SetActive(false);

        continueButton.onClick.AddListener(HideItemPanel);
    }

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        GameState.StateAdded += AddNewState;
    }

    private void OnDisable()
    {
        GameState.StateAdded -= AddNewState;
    }

    void AddNewState(string id, int amount)
    {
        print($"<color=green>Added Item</color>: <color=yellow>{amount} {id}</color>");
        foreach (StateInfo stateInfo in stateinfos)
        {
            if (stateInfo.id == id)
            {
                print($"State ID: {stateInfo.id}, Name: {stateInfo.name}, Description: {stateInfo.description}");
                
                text_header.text = $"Added {amount} of {stateInfo.name}";
                text_description.text = $"{stateInfo.description}";
                item_icon.sprite = stateInfo.icon;

                StartCoroutine(DelayStatePopup());
            }
        }
    }

    IEnumerator DelayStatePopup()
    {
        yield return null;
        itemPanel.SetActive(true);
        gameController.StartPopupMode();
        
        Selectable newSelection;

        newSelection = continueButton;
        yield return null;
                
        newSelection.Select();
    }
    
    void HideItemPanel()
    {
        itemPanel.SetActive(false);
        gameController.EndPopupMode();
    }

    public StateInfo GetStateInfoById(string id)
    {
        foreach (StateInfo stateInfo in stateinfos)
        {
            if (id == stateInfo.id)
            {
                return stateInfo;
            }
        }

        return null;
    }

}
