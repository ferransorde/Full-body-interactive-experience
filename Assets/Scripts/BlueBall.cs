using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public Transform spawnPoint;
    public GameObject player2;
    private BallSpawnerBlue ballSpawner;
    public PlayerMovement playerScript;


    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2");
        playerScript = player2.GetComponent<PlayerMovement>();
    
      
    }

    // Update is called once per frame
    void Update()
    {
        if(follow && playerScript.with_ball){
            transform.position = player2.transform.position;
        }
    }

    

    private void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag(tagFilter) && !playerScript.with_ball) 
        {
            follow = true;
            playerScript.with_ball = true;
        }
    }

    private void OnDestroy(){

        if (playerScript != null){
            follow = false;
            playerScript.with_ball = false;
        }
        
        if (ballSpawner != null)
        {
            ballSpawner.RemoveBallFromList(gameObject);
        }
        
    }

    public void SetSpawner(BallSpawnerBlue spawner)
    {
        ballSpawner = spawner;
    }

}
