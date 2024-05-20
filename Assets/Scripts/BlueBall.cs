using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    public string tagFilter;
    bool follow = false;
    bool with_ball = false;
    public GameObject player2;
    private BallSpawnerBlue ballSpawner;


    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        if(follow){
            transform.position = player2.transform.position;
            
        }
    }

    

    private void OnTriggerEnter (Collider other) 
    {
        if(!with_ball){
            if (other.CompareTag(tagFilter)) 
            {
                follow = true;
                with_ball = true;
            }
        }

        if(gameObject == null){
            with_ball = false;
        }
    }

    private void destroyed(){
        
    }

    public void SetSpawner(BallSpawnerBlue spawner)
    {
        ballSpawner = spawner;
    }

}
