using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public float delay = 3f; // Delay in seconds
    public GameObject textObject; // Reference to your 3D Text GameObject

    IEnumerator Start()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Enable the 3D Text GameObject
        textObject.SetActive(true);
    }
}
