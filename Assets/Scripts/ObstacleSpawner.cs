using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject starPrefab;
    public float spawnRate = 4f;
    public float spawnHeight = 10f;
    public float minX = -2f;
    public float maxX = 2f;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Assign a value to the gameManager variable
        InvokeRepeating("SpawnObstacle", 1.5f, spawnRate* 2);
        InvokeRepeating("SpawnStar", 1f, spawnRate);
    }

    void Update()
    {
        if (gameManager.score >= 100)
        {
            spawnRate = 3f;
        }
        if (gameManager.score >= 200)
        {
            spawnRate = 2f;
        }
        if (gameManager.score >= 300)
        {
            spawnRate = 1f;
        }
    }
    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y + spawnHeight, 0);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    void SpawnStar()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y + spawnHeight, 0);
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}
