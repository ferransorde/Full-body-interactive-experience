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
    private float alturaBola;
    
    

    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        player1 = GameObject.Find("Player1");
        playerScript = player1.GetComponent<PlayerMovement>();
        
        alturaBola = ball.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText(){
        countdisplay1.text = count1.ToString();
    }
    

    private void OnTriggerEnter (Collider other) 
    {
        float objectTopY = transform.position.z + GetComponent<Collider>().bounds.extents.z;
        if (other.CompareTag(tagFilter) && playerScript.with_ball) 
        {
            Destroy(other.gameObject);
            ballSpawner.RemoveBallFromList(gameObject);
            count1+=1;
            SetCountText();
            
        }
    }

  
}
