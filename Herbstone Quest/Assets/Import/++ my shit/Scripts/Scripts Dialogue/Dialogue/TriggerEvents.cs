using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    private const string PlayerTag = "Player";
    private const string NoTag = "Untagged";

    #region Inspector

    [Tooltip("Animator to control the NPC animations.")]
    [SerializeField] private Animator animator;

    [Tooltip("Name of the animation trigger to start the animation.")]
    [SerializeField] private string startAnimationTrigger;

    [Tooltip("Name of the animation trigger to stop the animation.")]
    [SerializeField] private string stopAnimationTrigger;

    [Tooltip("Invoked when OnTriggerEnter() is called.")]
    [SerializeField] private UnityEvent<Collider2D> onTriggerEnter;

    [Tooltip("Invoked when OnTriggerExit() is called.")]
    [SerializeField] private UnityEvent<Collider2D> onTriggerExit;

    [Tooltip("Enable to filter the interacting collider by a specified tag.")]
    [SerializeField] private bool filterOnTag = true;

    [Tooltip("Tag of the interacting collider to filter on.")]
    [SerializeField] private string reactOn = PlayerTag;

    #endregion

    #region Unity Event Functions

    private void OnValidate()
    {
        // Replaces an 'empty' reactOn field with "Untagged".
        if (string.IsNullOrWhiteSpace(reactOn))
        {
            reactOn = NoTag;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (filterOnTag && !other.CompareTag(reactOn)) { return; }

        onTriggerEnter.Invoke(other);
        PlayStartAnimation();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (filterOnTag && !other.CompareTag(reactOn)) { return; }

        onTriggerExit.Invoke(other);
        PlayStopAnimation();
    }

    #endregion

    #region Animation Methods

    private void PlayStartAnimation()
    {
        if (animator != null && !string.IsNullOrEmpty(startAnimationTrigger))
        {
            animator.SetTrigger(startAnimationTrigger);
        }
    }

    private void PlayStopAnimation()
    {
        if (animator != null && !string.IsNullOrEmpty(stopAnimationTrigger))
        {
            animator.SetTrigger(stopAnimationTrigger);
        }
    }

    #endregion
}
