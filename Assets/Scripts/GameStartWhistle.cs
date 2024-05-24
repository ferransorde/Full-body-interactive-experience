using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartWhistle : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to the WhistleSound GameObject
        audioSource = GetComponent<AudioSource>();

        // Play the whistle sound at the start of the game
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
