using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    public GameObject player1;
    private BallSpawner ballSpawner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(follow){
            transform.position = player1.transform.position;
        }
    }

    

    private void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag(tagFilter)) 
        {
            follow = true;
            
        }
    }

    public void SetSpawner(BallSpawner spawner)
    {
        ballSpawner = spawner;
    }

}
