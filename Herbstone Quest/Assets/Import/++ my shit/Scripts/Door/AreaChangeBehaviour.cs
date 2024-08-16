using System.Collections;
using UnityEngine;

public class AreaChangeBehaviour : MonoBehaviour
{
    public Animator animDoor;
    public Transform portPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(InitiateTeleport(other));
        }
    }

    IEnumerator InitiateTeleport(Collider2D other)
    {
        animDoor.Play("FadeToBlack");
        yield return new WaitForSeconds(1);
        other.transform.position = portPosition.position;
        yield return new WaitForSeconds(.3f);
        animDoor.Play("FadeToGone");
    }
}
