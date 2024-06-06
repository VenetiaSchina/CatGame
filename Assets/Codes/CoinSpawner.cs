using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 5f;
    public float minX = -3f; // Minimum x position
    public float maxX = 3f;  // Maximum x position
    public float minY = 3f;  // Minimum y position
    public float maxY = 6f;  // Maximum y position
    private float spawnTimer = 0f;

    void Update()
    {
        if (spawnTimer <= 0)
        {
            SpawnCoin();
            spawnTimer = spawnRate;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void SpawnCoin()
    {
        float randomX = Random.Range(minX, maxX); // Random x position
        float randomY = Random.Range(minY, maxY); // Random y position
        Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}