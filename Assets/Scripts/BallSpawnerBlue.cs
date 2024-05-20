using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerBlue : MonoBehaviour
{
    public bool canSpawn = true; 
    public GameObject ballPrefab; 
    public List<Transform> ballSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns ;
    private List<GameObject> ballList = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBall()
    {
        Vector3 randomPosition = ballSpawnPositions[Random.Range(0,
        ballSpawnPositions.Count)].position; 
        GameObject ball = Instantiate(ballPrefab, randomPosition ,
        ballPrefab.transform.rotation); 
        ballList.Add(ball); 
        ball.GetComponent<BlueBall>().SetSpawner(this); 
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
        
    }
}
