/* 
--------------------------  
    ObstacleSpawner.cs
Description: Script for spawning prefabs at a random position
--------------------------

Literature:
    * Stack overflow forum - How to spawn prefabs within a certain period of time in Unity?
        [Link] (https://stackoverflow.com/questions/50573081/how-to-spawn-prefabs-within-a-certain-period-of-time-in-unity)
*/

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // References to the obstacle and star prefabs to be spawned
    public GameObject obstaclePrefab;
    public GameObject starPrefab;

    // Variables to control the spawning rate and position range
    public float spawnRate = 4f;
    public float spawnHeight = 10f;
    public float minX = -2f;
    public float maxX = 2f;

    // Reference to the GameManager to access game state
    GameManager gameManager;

    void Start()
    {
        // Find the GameManager in the scene and assign it to the gameManager variable
        gameManager = FindObjectOfType<GameManager>(); 

        // SpawnObstacle method to be called repeatedly after 1.5 seconds, then every spawnRate * 2 seconds
        InvokeRepeating("SpawnObstacle", 1.5f, spawnRate * 2);

        // SpawnStar method to be called repeatedly after 1 second, then every spawnRate seconds
        InvokeRepeating("SpawnStar", 1f, spawnRate);
    }

    void Update()
    {
        // Adjust the spawnRate based on the game's score
        if (gameManager.score >= 100)
        {
            spawnRate = 3f; // Decrease spawn rate as score increases
        }
        if (gameManager.score >= 200)
        {
            spawnRate = 2f; // Further decrease spawn rate
        }
        if (gameManager.score >= 300)
        {
            spawnRate = 1f; // Minimum spawn rate for highest difficulty
        }
    }

    // Method to spawn an obstacle at a random position within the defined range
    void SpawnObstacle()
    {
        // Generate a random X position within minX and maxX, and set the spawn height
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y + spawnHeight, 0);
        
        // Instantiate the obstaclePrefab at the calculated position with no rotation
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    // Method to spawn a star at a random position within the defined range
    void SpawnStar()
    {
        // Generate a random X position within minX and maxX, and set the spawn height
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y + spawnHeight, 0);
        
        // Instantiate the starPrefab at the calculated position with no rotation
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}
