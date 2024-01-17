
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip jump;
    public AudioClip CandyCorn;
    public AudioClip CobBoss;



    private void Start()
    {
        
    }

    public void PLaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}

