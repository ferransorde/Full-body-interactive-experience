using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class basket : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public GameObject ball;
    public BallSpawnerRed ballSpawner;
    public GameObject player1;
    public TextMeshProUGUI countdisplay1;
    public int Count1 { get { return count1; } }
    private int count1;
    public PlayerMovement playerScript;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        player1 = GameObject.Find("Player1");
        playerScript = player1.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText(){
        countdisplay1.text ="Points: " + count1.ToString();
    }
    

    private void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag(tagFilter) && playerScript.with_ball) 
        {
            Destroy(other.gameObject);
            ballSpawner.RemoveBallFromList(gameObject);
            count1+=1;
            SetCountText();
            
        }
    }

  
}
