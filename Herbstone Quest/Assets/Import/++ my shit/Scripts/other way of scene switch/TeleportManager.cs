using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    private GameObject player;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    public void TeleportPlayerToPos(Transform teleportPos)
    {
        player.transform.position = teleportPos.position;
    }
}