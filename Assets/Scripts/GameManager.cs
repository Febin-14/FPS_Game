    using UnityEngine;
    using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

    public GameState currentState { get;private set; }
    private void Awake()
        {
            Instance = this;
            //isGamePaused = false;
            Debug.Log("Game Manager Initialized");
        currentState = GameState.Playing;
    }


    public void GameOver()
    {
        
    }
   
    public void SetState(GameState newState)
    {
        currentState = newState;
        switch(currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.Inspecting:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.Inventory:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.ReadingNotes:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
        }

    }
}
public enum GameState
{
    Playing,
    Paused,
    Inventory,
    ReadingNotes,
    GameOver,
    Inspecting
}
