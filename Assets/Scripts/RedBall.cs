using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public Transform spawnPoint;
    public GameObject player1;
    private BallSpawnerRed ballSpawner;
    public PlayerMovement playerScript;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        playerScript = player1.GetComponent<PlayerMovement>();
        playerScript.with_ball = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(follow && playerScript.with_ball){
            transform.position = player1.transform.position;
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
            playerScript.with_ball = false;
        }
        
        if (ballSpawner != null)
        {
            ballSpawner.RemoveBallFromList(gameObject);
        }
        
    }

    public void SetSpawner(BallSpawnerRed spawner)
    {
        ballSpawner = spawner;
    }

}
