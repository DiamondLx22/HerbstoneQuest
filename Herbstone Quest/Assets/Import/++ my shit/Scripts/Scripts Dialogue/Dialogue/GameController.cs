using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController player;
    private DialogueController dialogueController;

    public enum GameMode
    {
        PreMenu, MainMenu, NewGame, LoadGame, SaveGame, GameMode, DialogueMode, DebugMode
        
    }

    public GameMode gameMode;
    

    public Button lastSelectable;
    #region Unity Event Functions

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        dialogueController = FindObjectOfType<DialogueController>();
    }

    private void OnEnable()
    {
        DialogueController.DialogueClosed += EndDialogue;
    }

    private void Start()
    {
        if(player)
            EnterPlayMode();
    }

    private void OnDisable()
    {
        DialogueController.DialogueClosed -= EndDialogue;
    }

    #endregion

    #region Modes

    private void EnterPlayMode()
    {
        Time.timeScale = 1;
        // In the editor: Unlock with ESC.
        //Cursor.lockState = CursorLockMode.Locked;
        player.EnableInput();
    }

    private void EnterDialogueMode()
    {
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        player.DisableInput(); 
    }
    
    private void EnterPopupMode()
    {
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        player.DisableInput(); 
    }

    private void EnterInventoryMode()
    {
        Time.timeScale = 0;
        player.DisableInput();
    }

    #endregion

    public void StartDialogue(string dialoguePath)
    {
        EnterDialogueMode();
        dialogueController.StartDialogue(dialoguePath);
    }

    private void EndDialogue()
    {
        EnterPlayMode();
    }

    public void StartPopupMode()
    {
        EnterPopupMode();
    }
    
    public void EndPopupMode()
    {
        EnterPlayMode();
    }

    public void StartInventory()
    {
        EnterInventoryMode();
    }
    
    public void EndInventory()
    {
        EnterPlayMode();
    }
    

    public void SetLastSelectable()
    {
        SetSelectable(lastSelectable);
    }
    public void SetSelectable(Button newSelactable)
    {
        Selectable newSelectable;
        lastSelectable = newSelactable;
        newSelectable = newSelactable;

        //newSelactable.Select();
        StartCoroutine(DelayNewSelectable(newSelectable));
    }

    public void ExitMenu()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator DelayNewSelectable(Selectable newSelectable)
    {
        yield return null;
        newSelectable.Select();
    }
}

