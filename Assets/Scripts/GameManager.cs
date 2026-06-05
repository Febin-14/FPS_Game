    using UnityEngine;
    using TMPro;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private int Score = 0;
        public TextMeshProUGUI scoreText;
        public int bullets = 30;
        public TextMeshProUGUI bulletText;
        public bool canShoot = true;
        public StartScene startScene;
        public bool isGameOver = false;
        public bool isGamePaused = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
        {
            Instance = this;
            //isGamePaused = false;
            Debug.Log("Game Manager Initialized");
    }

        public void AddScore()
        {
            Score += 1;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + Score.ToString();
            }

        }
        public bool UseBullet()
        {
            bullets -= 1;
            if(bullets <= 0)
            {
                Debug.Log("Out of bullets!");
                canShoot = false;
                GameOver(); 
                

        }
        if (bulletText != null)
               {
            bulletText.text = "Ammo Left : " + bullets.ToString();
               }
            return canShoot;


    }
    public void GameOver()
    {
        if(bullets <= 0)
        {
            isGameOver = true;
            Debug.Log("Game Over");
            startScene.GameOver();
            //isGameOver = true;
        }
    }
}
