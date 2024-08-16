using UnityEngine;
using System.Collections;
using DG.Tweening;

//using DG.Tweening;

public class FadePanelManager : MonoBehaviour
{
    public DOTweenAnimation doTweenFadePanel;
    public TeleportManager teleportManager;

    public void FadePanel(float timeDelay = 0)
    {
        StartCoroutine(StartFade(timeDelay));
    }

    public void FadePanel(Transform player, Transform teleportPos, float direction, float timeDelay = 0)
    {
        StartCoroutine(StartFade(player, teleportPos, timeDelay, direction));
    }

    private IEnumerator StartFade(Transform player, Transform teleportPos, float timeDelay, float direction)
    {
        yield return null;
        //player.GetComponent<PlayerController>().SetFloatAnimation("dirX", direction);
        //player.GetComponent<PlayerController>().SetFloatAnimation("dirY", 0);
        //player.GetComponent<PlayerController>().SetBoolAnimation("isWalking", true);
        yield return new WaitForSeconds(timeDelay);
        //doTweenFadePanel.DOPlayForward();
        yield return new WaitForSeconds(1);
        //teleportManager.TeleportPlayerToPos(player, teleportPos);
        //player.GetComponent<PlayerController>().SetBoolAnimation("isWalking", false);
        doTweenFadePanel.DOPlayBackwards();
        yield return new WaitForSeconds(0.6f);
        player.gameObject.GetComponent<PlayerController>().EnableInput();
    }

    private IEnumerator StartFade(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        //doTweenFadePanel.DOPlayForward();
        yield return new WaitForSeconds(1);
        //doTweenFadePanel.DOPlayBackwards();
    }
    
    public void SimpleFadeAndTeleport(Transform teleportPos)
    {
        StartCoroutine(StartSimpleFadeAndTeleport(teleportPos));
    }

    private IEnumerator StartSimpleFadeAndTeleport(Transform teleportPos)
    {
        //doTweenFadePanel.DOPlayForward();
        yield return new WaitForSeconds(1);
        teleportManager.TeleportPlayerToPos(teleportPos);
        yield return new WaitForSeconds(1);
        //doTweenFadePanel.DOPlayBackwards();
    }
}