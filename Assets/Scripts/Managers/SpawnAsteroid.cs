using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    public float minXSpawn=35, maxXSpawn=200;
    public float minYSpawn = 6f, maxYSpawn = 15f;
    public float minSpawnTime=0.5f, maxSpawnTime = 1.5f;
    void Start()
    {
        InvokeRepeating("SpawnAsteroids", 1, Random.Range(minSpawnTime, maxSpawnTime));
    }

    private void SpawnAsteroids()
    {
        float randomX = Random.Range(minXSpawn, maxXSpawn);
        float randomY = Random.Range(minYSpawn, maxYSpawn);
        Vector2 spawnPos = new Vector2(randomX, randomY);

        //Instantiate(asteroid, spawnPos, Quaternion.identity);

        GameObject asteroid = Pool.instance.GetObject("Asteroid");
        if (asteroid!=null)
        {
            asteroid.transform.position = spawnPos;
            asteroid.SetActive(true);
        }
       
    }

}
