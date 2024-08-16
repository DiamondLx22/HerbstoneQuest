using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameLoader : MonoBehaviour
{
    [SerializeField] private Transform[] spawnpoints;
    private void OnEnable()
    {
        GameController gameController = FindObjectOfType<GameController>();
        SpawnpointSaver spawnpointSaver = FindObjectOfType<SpawnpointSaver>();
        Transform playerTransform = FindObjectOfType<PlayerController>().transform;

        switch (gameController.gameMode)
        {
            case GameController.GameMode.LoadGame:
                FindObjectOfType<SaveManager>().LoadGame();
                break;
            
            case GameController.GameMode.NewGame:
                //#TODO Change and adjust with gamelogic
                playerTransform.position = spawnpoints[0].position;
                break;
            
            case GameController.GameMode.GameMode:
                playerTransform.position = spawnpoints[spawnpointSaver.spawnpointId].position;
                break;
            
            case GameController.GameMode.DebugMode:
                Debug.LogWarning("Debug Mode turned on!");
                break;
            
            default:
                Debug.LogWarning("Game Mode not supported!");
                playerTransform.position = spawnpoints[0].position;
                break;
        }
    }
}