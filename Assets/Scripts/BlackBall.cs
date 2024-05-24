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

    private int countply3 = 0;
    private int countply4 = 0;

    private float alturaPlayer3;
    private float alturaPlayer4;

    void Start()
    {

        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
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
                    countply3++;
                    Destroy(gameObject);
                }
            }
            else if (other.gameObject == player4)
            {
                if (alturaPlayer4 > objectTopY)
                {
                    isPlayer4OnCube = true;
                    countply4++;
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
