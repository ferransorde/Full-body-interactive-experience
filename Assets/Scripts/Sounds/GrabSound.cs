using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GrabSound : MonoBehaviour
{
    private AudioSource grabAudioSource;

    void Start()
    {
        grabAudioSource = GetComponent<AudioSource>();

        if (grabAudioSource == null)
        {
            Debug.LogError("Grab AudioSource component not found.");
        }
    }

    // Method to play the grab sound
    public void PlayGrabSound()
    {
        if (grabAudioSource != null)
        {
            grabAudioSource.Play();
        }
    }
}

