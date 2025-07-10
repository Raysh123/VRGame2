using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this);
        
        DontDestroyOnLoad(this);
    }

    #endregion
    
    public delegate void OnGameStartHandler();
    public static event OnGameStartHandler OnGameStart;
    
    public delegate void OnGameOverHandler();
    public static event OnGameOverHandler OnGameOver;

    private static GameState _currentGameState;

    public static GameState CurrentGameState
    {
        get => _currentGameState;
        set
        {
            _currentGameState = value;
            switch (_currentGameState)
            {
                case GameState.Start:
                    OnGameStart?.Invoke();
                    break;
                case GameState.GameOver:
                    OnGameOver?.Invoke();
                    break;
            }
        }
    }

    private void OnEnable()
    {
        CurrentGameState = GameState.Start;
    }
}

public enum GameState
{
    Start,
    GameOver
}
