using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerRed : MonoBehaviour
{
    public bool canSpawn = true; 
    public GameObject ballPrefab; 
    public List<Transform> ballSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns ;
    private List<GameObject> ballList = new List<GameObject>();
    private Dictionary<Transform, bool> spawnPointOccupied = new Dictionary<Transform, bool>();

    

    // Start is called before the first frame update
    void Start()
    {
        foreach (var spawnPoint in ballSpawnPositions)
        {
            spawnPointOccupied[spawnPoint] = false;
        }
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBall()
    {
        Transform spawnPoint = null;
        foreach (var point in ballSpawnPositions)
        {
            if (!spawnPointOccupied[point])
            {
                spawnPoint = point;
                break;
            }
        }

        //Vector3 randomPosition = ballSpawnPositions[Random.Range(0,
        //ballSpawnPositions.Count)].position; 
        /**GameObject ball = Instantiate(ballPrefab, randomPosition ,
        ballPrefab.transform.rotation); 
        ballList.Add(ball); 
        ball.GetComponent<RedBall>().SetSpawner(this); **/
        if (spawnPoint != null)
        {
            Vector3 spawnPosition = spawnPoint.position;
            GameObject ball = Instantiate(ballPrefab, spawnPosition, ballPrefab.transform.rotation);
            ballList.Add(ball);
            ball.GetComponent<RedBall>().SetSpawner(this);
            ball.GetComponent<RedBall>().spawnPoint = spawnPoint;

            // Mark this spawn point as occupied
            spawnPointOccupied[spawnPoint] = true;
        }
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnBall(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }

    public void RemoveBallFromList (GameObject ball)
    {
        ballList.Remove(ball);
        RedBall redBallScript = ball.GetComponent<RedBall>();
        if (redBallScript != null && redBallScript.spawnPoint != null)
        {
            spawnPointOccupied[redBallScript.spawnPoint] = false;
        }
        
    }
}
