using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBall : MonoBehaviour
{
    public GameObject player3;
    public GameObject player4;
    public string tagFilter;
    public Transform spawnPoint;
    private BallSpawnerBlack ballSpawner;

    private bool isPlayer3OnCube = false;
    private bool isPlayer4OnCube = false;

    public int Count3 { get { return count3; } }
    private int count3;
    public int Count4 { get { return count4; } }
    private int count4=0;

    private float alturaPlayer3;
    private float alturaPlayer4;

    public basket redbasket;
    public basket2 bluebasket;

    void Start()
    {

        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        redbasket = FindObjectOfType<basket>();
        bluebasket = FindObjectOfType<basket2>();
        if (player3 != null)
        {
            alturaPlayer3 = player3.transform.position.y;
        }
        if (player4 != null)
        {
            alturaPlayer4 = player4.transform.position.y;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
        {
            float objectTopY = transform.position.y + GetComponent<Collider>().bounds.extents.y;

            if (other.gameObject == player3)
            {
                if (alturaPlayer3 > objectTopY)
                {
                    isPlayer3OnCube = true;
                    count3++;
                    redbasket.UpdateCount3(count3);
                    
                    Destroy(gameObject);
                }
            }
            else if (other.gameObject == player4)
            {
                if (alturaPlayer4 > objectTopY)
                {
                    isPlayer4OnCube = true;
                    count4++;
                    bluebasket.UpdateCount4(count4);

                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnDestroy(){
        if (ballSpawner != null)
        {
            ballSpawner.RemoveBallFromList(gameObject);
        }
    }

    void Update()
    {
        if (player3 != null)
        {
            alturaPlayer3 = player3.transform.position.y;
        }
        if (player4 != null)
        {
            alturaPlayer4 = player4.transform.position.y;
        }
    }

    public void SetSpawner(BallSpawnerBlack spawner)
    {
        ballSpawner = spawner;
    }

}
