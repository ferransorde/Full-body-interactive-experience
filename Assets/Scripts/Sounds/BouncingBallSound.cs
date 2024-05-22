using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBallSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody rigidbody;

    // Adjust this value to control the pitch change based on ball speed
    public float pitchMultiplier = 1.0f;

    void Start()
    {
        // Check if audioSource and rigidbody are assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing.");
            }
        }

        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody>();
            if (rigidbody == null)
            {
                Debug.LogError("Rigidbody component is missing.");
            }
        }

        // Debug logs for initialization
        if (audioSource != null && rigidbody != null)
        {
            Debug.Log("Initialization complete: AudioSource and Rigidbody are assigned.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (audioSource == null || rigidbody == null)
        {
            Debug.LogWarning("AudioSource or Rigidbody is not assigned.");
            return;
        }

        // Log collision event for debugging
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        // Calculate the ball's speed at the moment of collision
        float speed = rigidbody.velocity.magnitude;

        // Log speed for debugging
        Debug.Log("Ball speed: " + speed);

        // Adjust the pitch of the audio clip based on the ball's speed
        float minSpeed = 0.5f;
        float maxSpeed = 10f;
        float minPitch = 0.8f;
        float maxPitch = 1.2f;

        float pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.InverseLerp(minSpeed, maxSpeed, speed));
        audioSource.pitch = pitch * pitchMultiplier;

        // Log pitch for debugging
        Debug.Log("Audio pitch: " + audioSource.pitch);

        // Play the bounce sound
        audioSource.Play();
    }

    public void GrabBall()
    {
        Debug.Log("Ball has been grabbed.");
        // Additional logic for when the ball is grabbed, if needed
    }
}
