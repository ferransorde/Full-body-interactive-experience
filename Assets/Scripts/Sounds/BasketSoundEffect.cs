using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasketSoundEffect : MonoBehaviour
{
    [SerializeField] AudioSource Basketball_Net;
    [SerializeField] AudioSource Crowd;

    void Start()
    {
        // Assuming the first AudioSource is for the net sound and the second for the crowd sound
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            Basketball_Net = audioSources[0];
            Crowd = audioSources[1];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is tagged as "Blue_ball"
        if (other.CompareTag("Blue_ball"))
        {
            // Play the blue ball sound effect
            if (Basketball_Net != null)
            {
                Basketball_Net.Play();
            }
            // Play the blue ball crowd sound effect
            if (Crowd != null)
            {
                Invoke("PlayCrowdSound", 0.5f);
            }
        }

        // Check if the object entering the trigger is tagged as "Red_ball"
        else if (other.CompareTag("Red_ball"))
        {
            // Play the red ball sound effect
            if (Basketball_Net != null)
            {
                Basketball_Net.Play();
            }
             // Play the blue ball crowd sound effect
            if (Crowd != null)
            {
                Invoke("PlayCrowdSound", 0.5f);
            }
        }
    }

    void PlayCrowdSound()
    {
        Crowd.Play();
    }
        
    
}