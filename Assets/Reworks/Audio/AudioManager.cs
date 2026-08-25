using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource sfxSource;
    [Header("Music")]


    [Header("SFX")]
    [SerializeField] private AudioClip[] footsteps;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip steelDoorOpenClip;
    [SerializeField] private AudioClip woodDoorOpenClip;
    [SerializeField] private AudioClip steelDoorCloseClip;
    [SerializeField] private AudioClip woodDoorCloseClip;
    [SerializeField] private AudioClip inventoryOpenSound;
    [SerializeField] private AudioClip jumpsound;
    [SerializeField] private AudioClip landsound;    

    private int lastFootStep = -1;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    public void PlayFootSteps()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, footsteps.Length);
        }
        while (randomIndex == lastFootStep);
        {
            lastFootStep = randomIndex;
            sfxSource.PlayOneShot(footsteps[randomIndex]);
        }
    }
    public void PlayPickItem()
    {
        sfxSource.PlayOneShot(pickUp);
    }
    public void OpenDoorSound(DoorType doorType)
    {
        switch (doorType)
        {
            case DoorType.Steel:
                sfxSource.PlayOneShot(steelDoorOpenClip);
                break;
            case DoorType.Wood:
                sfxSource.PlayOneShot(woodDoorOpenClip);
                break;


        }

    }
    public void CloseDoorSound(DoorType doorType)
    {
        switch(doorType)
        {
            case DoorType.Steel:
                sfxSource.PlayOneShot(steelDoorCloseClip);
                break;
            case DoorType.Wood:
                sfxSource.PlayOneShot(woodDoorCloseClip);
                break;

        }
    }
    public void OpenInventorySound()
    {
        Debug.Log("Inventory Open Sound Played");
        sfxSource.PlayOneShot(inventoryOpenSound);
    }

    public void PlayJumpSound()
    {
        sfxSource.PlayOneShot(jumpsound);
    }
    public void PlayLandSound()
    {
        sfxSource.PlayOneShot(landsound);
    }


}
