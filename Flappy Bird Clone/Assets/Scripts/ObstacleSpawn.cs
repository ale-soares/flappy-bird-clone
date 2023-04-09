using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnRate = 2;
    public float minSpawnRate = 2;
    public float acceleration;

    public float spawnHeightOffset = 10;

    private float timer = 0;

    void Start()
    {
        spawnObstacle();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;

            if (spawnRate > minSpawnRate)
            {
                spawnRate -= Time.deltaTime * acceleration;
            }
            else
            {
                spawnRate = minSpawnRate;
            }
        }
        else
        {
            spawnObstacle();
            timer = 0;
        }
    }

    void spawnObstacle()
    {
        float lowestPoint = transform.position.y - spawnHeightOffset;
        float highestPoint = transform.position.y + spawnHeightOffset;

        Vector3 spawnRangePosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(obstacle, spawnRangePosition, transform.rotation);
    }
}
