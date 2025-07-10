using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject levelLoopGroup, gameOverGroup;
    private void OnEnable()
    {
        GameManager.OnGameStart += () => SetActiveCanvasGroup("GameLoop");
        GameManager.OnGameOver += () => SetActiveCanvasGroup("GameOver");
    }

    //
    private void SetActiveCanvasGroup(string groupName)
    {
        foreach (Transform child in canvas.transform) child.gameObject.SetActive(false);

        switch (groupName)
        {
            case "GameLoop":
                levelLoopGroup.SetActive(true);
                break;
            case "GameOver":
                gameOverGroup.SetActive(true);
                break;
        }
    }
}
