using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class basket2 : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public GameObject ball;
    public BallSpawnerBlue ballSpawner;
    public TextMeshProUGUI countdisplay2;
    public int Count2 { get { return count2; } }
    private int count2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText(){
        countdisplay2.text = count2.ToString();
    }
    

    private void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag(tagFilter)) 
        {
            Destroy(other.gameObject);
            ballSpawner.RemoveBallFromList(gameObject);
            count2+=1;
            SetCountText();
            
        }
    }

    
}