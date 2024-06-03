using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinnerPlayer : MonoBehaviour
{
    public string crowdSoundFileName = "crowdSound"; 

    private AudioSource audioSource;

    
    private bool isPlayer1Winner;
    private bool isPlayer2Winner;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DetermineWinnerAndPlaySound();
    }

    void DetermineWinnerAndPlaySound()
    {
        if (isPlayer1Winner || isPlayer2Winner)
        {
            PlayCrowdSound();
        }
    }

    void PlayCrowdSound()
    {
        AudioClip crowdSound = Resources.Load<AudioClip>(crowdSoundFileName);
        if (crowdSound != null)
        {
            audioSource.clip = crowdSound;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Crowd sound not found in Resources folder");
        }
    }

    
    public void SetPlayer1Winner()
    {
        isPlayer1Winner = true;
        isPlayer2Winner = false;
    }

    public void SetPlayer2Winner()
    {
        isPlayer1Winner = false;
        isPlayer2Winner = true;
    }

    public void SetTie()
    {
        isPlayer1Winner = false;
        isPlayer2Winner = false;
    }
}
