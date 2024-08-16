using UnityEngine;

public class InkDialogue : MonoBehaviour
{
    #region Inspector

    [Tooltip("Path to a specified knot.stitch in the ink file.")]
    [SerializeField] private string defaultDialoguePath; // Corrected spelling here
    [SerializeField] private string finishedDialoguePath;
    [SerializeField] private string backupDialoguePath;
    
    [SerializeField] private bool finishedDialogue;
    
    #endregion

    public void StartDialogue()
    {
        if (string.IsNullOrWhiteSpace(defaultDialoguePath))
        {
            Debug.LogWarning("No default dialogue path defined", this);
            return;
        }
        
        if (string.IsNullOrWhiteSpace(finishedDialoguePath))
        {
            Debug.LogWarning("No finished dialogue path defined", this);
            return;
        }
        
        if (string.IsNullOrWhiteSpace(backupDialoguePath))
        {
            Debug.LogWarning("No backup dialogue path defined", this);
            return;
        }
        
        if (finishedDialogue)
        {
            FindObjectOfType<GameController>().StartDialogue(finishedDialoguePath);
        }
        else
        {
            FindObjectOfType<GameController>().StartDialogue(defaultDialoguePath);
        }
    }

    public void finishDialogue()
    {
        finishedDialogue = true;
    }
}