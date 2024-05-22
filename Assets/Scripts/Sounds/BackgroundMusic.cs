using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;

    void Start()
    {
        if (musicAudioSource == null)
        {
            Debug.LogError("Music AudioSource component not assigned.");
        }
        else
        {
            // Play the music at the start of the level
            musicAudioSource.loop = true;
            musicAudioSource.Play();
        }
    }
}
