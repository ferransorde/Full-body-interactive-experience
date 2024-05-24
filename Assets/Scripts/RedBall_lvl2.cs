using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall_lvl2 : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public Transform spawnPoint;
    public GameObject player1;
    private BallSpawnerRed ballSpawner;
    public PlayerMovement playerScript;
    private Rigidbody rb;
    public float speed = 5f;
    private Vector3 movementDirection;
    


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        playerScript = player1.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        movementDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
      
    }


    // Update is called once per frame
    void Update()
    {
        if(follow && playerScript.with_ball){
            transform.position = player1.transform.position;
        }else{
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
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

        
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            movementDirection = Vector3.Reflect(movementDirection, normal);
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

    public void SetSpawner(BallSpawnerRed spawner)
    {
        ballSpawner = spawner;
    }

}
