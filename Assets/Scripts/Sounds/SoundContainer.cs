using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Container", menuName = "TypeMan/SoundContainer", order = 0)]
public class SoundContainer : ScriptableObject {
    // Fields
    [SerializeField] private List<AudioClip> soundList;
    private AudioClip currentSound;
    private int currentSoundIndex;

    // Properties
    private int CurrentSoundIndex
    {
        get { return currentSoundIndex;}
        set {
            if(value > soundList.Count - 1)
                currentSoundIndex = 0;
            else
                currentSoundIndex = value;
        }
    }
    public AudioClip GetCurrentSound 
    {
        get 
        {
            CurrentSoundIndex ++;
            return soundList[CurrentSoundIndex];
        }
    }

    // Methods
    private void Awake() 
    {
        currentSoundIndex = -1;
    }
}