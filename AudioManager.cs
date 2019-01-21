using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource soundSource;

    public AudioClip winSound, loseSound, drinkSound, trashSound;

    void Awake()
    {
        OnReload();   
    }

    void Start () {
		
	}
	
    public void PlayWinSound()
    {
        soundSource.PlayOneShot(loseSound);
    }

    public void PlayDrinkSound()
    {
        soundSource.PlayOneShot(drinkSound);
    }
    public void PlayTrashSound()
    {
        soundSource.PlayOneShot(trashSound);
    }
    public void PlayLoseSound()
    {
        soundSource.PlayOneShot(loseSound);
    }

}
