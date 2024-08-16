using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameController gameController;



    private void OnEnable()
    {
        StartCoroutine(DelayEnable());
    }

    IEnumerator DelayEnable()
    {
        yield return null;
        gameController = FindObjectOfType<GameController>();
        switch (gameController.gameMode)
        {
            case GameController.GameMode.PreMenu:
                gameController.gameMode = GameController.GameMode.MainMenu;
                break;

            case GameController.GameMode.GameMode:
                gameController.gameMode = GameController.GameMode.MainMenu;
                break;

            default:
                Debug.LogWarning($"Wrong Game Mode detected: {gameController.gameMode}!");
                gameController.gameMode = GameController.GameMode.MainMenu;

                break;
        }
    }


public void Button_NewGame()
    {
        gameController.gameMode = GameController.GameMode.NewGame;
        SceneManager.LoadScene("Forest");
    }

    public void Button_Continue()
    {
        gameController.gameMode = GameController.GameMode.LoadGame;
        SceneManager.LoadScene(PlayerPrefs.GetString("Scenename"));
    }

    public void Button_Quit()
    {
        Application.Quit();
    }
    
}
