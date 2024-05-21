using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerRed : MonoBehaviour
{
    public bool canSpawn = true; 
    public GameObject ballPrefab; 
    public List<Transform> ballSpawnPositions = new List<Transform>(); 
    public float minTimeBetweenSpawns = 1f;
    public float maxTimeBetweenSpawns = 3f;
    public float spawnOffsetRange = 1f;
    //public float timeBetweenSpawns ;
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
        // Find all unoccupied spawn points
        List<Transform> availableSpawnPoints = new List<Transform>();
        foreach (var point in ballSpawnPositions)
        {
            if (!spawnPointOccupied[point])
            {
                availableSpawnPoints.Add(point);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            // Select a random unoccupied spawn point
            Transform spawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
            // Add a random offset within the defined range
            Vector3 spawnOffset = new Vector3(
                Random.Range(-spawnOffsetRange, spawnOffsetRange),
                0,
                Random.Range(-spawnOffsetRange, spawnOffsetRange)
            );
            Vector3 spawnPosition = spawnPoint.position + spawnOffset;
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
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
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
