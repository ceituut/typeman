using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    [SerializeField] private SoundContainer soundContainer;
    private AudioSource soundSource;


    private void Start() 
    {
        soundSource = gameObject.GetComponent<AudioSource>();
        soundSource.clip = soundContainer.GetCurrentSound;
    }

    public void PlaySound()
    {
        soundSource.clip = soundContainer.GetCurrentSound;
        soundSource.PlayOneShot(soundSource.clip);
    }    
}