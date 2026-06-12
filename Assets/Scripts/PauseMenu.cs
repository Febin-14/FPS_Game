using System.Data;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public StartScene startScene;
    public ShootMechanism shootMechanism;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //    {
        //    GameManager.Instance.isGamePaused = !(GameManager.Instance.isGamePaused);
        //    if(GameManager.Instance.isGamePaused == true)
        //    {
        //        PauseGame();
        //    }
        //    else
        //    {
        //        ResumeGame();
        //    }
        //}
        
    }
    public void PauseGame()
    {   
        Cursor.lockState = CursorLockMode.None;
        shootMechanism.enabled = false;
        Debug.Log("Pause Game");
        container.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shootMechanism.enabled = true;
        Debug.Log("Resume Game");
        container.SetActive(false);
        Time.timeScale = 1f;
        //GameManager.Instance.isGamePaused = false;
    }
    public void TryAgain()
    {
        Debug.Log("Try Again");
        Time.timeScale = 1f;
        //GameManager.Instance.isGamePaused = false;
        startScene.StartGame();

    }
    public void QuitGame()
    {
        ;
        startScene.QuitGame();
    }
    public void CheckIsGamePause()
    {
    //    if (GameManager.Instance.isGamePaused == true)
    //    {
    //        PauseGame();
    //    }
    //    else
    //    {
    //        ResumeGame();
    //    }
    //
    }

}
