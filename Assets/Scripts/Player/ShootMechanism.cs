using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class ShootMechanism : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public Camera fpsCamera;
    public float range = 100f;
    public float Score = 0f;
    //public TextMeshProUGUI scoreText;
    public AudioSource shootSound;
    
    
    public bool canShoot = true;
    


    public void Awake()
    {
        shootSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward );
        if (Input.GetButtonDown("Fire1"))
        {
            if(canShoot)
            {
                shootSound.Play();
                shoot();
                Dispbullet();

            }

        }
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    GameManager.Instance.isGamePaused = !(GameManager.Instance.isGamePaused);
        //}
    }
    void shoot()
    {   

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit,range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.Die();
                GameManager.Instance.AddScore();
            }
            
        }
    }
    void Dispbullet()
    {
        
        canShoot = GameManager.Instance.UseBullet();
        return;

    }
}
