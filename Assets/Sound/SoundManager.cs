using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}

