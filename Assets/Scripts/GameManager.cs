    using UnityEngine;
    using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
    //private int Score = 0;
    //public TextMeshProUGUI scoreText;
    //public int bullets = 30;
    //public TextMeshProUGUI bulletText;
    //public bool canShoot = true;
    //public StartScene startScene;
    //public bool isGameOver = false;
    //public bool isGamePaused = false;
    public GameState currentState { get;private set; }
   
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
        {
            Instance = this;
            //isGamePaused = false;
            Debug.Log("Game Manager Initialized");
        currentState = GameState.Playing;
    }

    //    public void AddScore()
    //    {
    //        Score += 1;
    //        if (scoreText != null)
    //        {
    //            scoreText.text = "Score: " + Score.ToString();
    //        }

    //    }
    //    public bool UseBullet()
    //    {
    //        bullets -= 1;
    //        if(bullets <= 0)
    //        {
    //            Debug.Log("Out of bullets!");
    //            canShoot = false;
    //            GameOver(); 
                

    //    }
    //    if (bulletText != null)
    //           {
    //        bulletText.text = "Ammo Left : " + bullets.ToString();
    //           }
    //        return canShoot;


    //}
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
    GameOver
}
