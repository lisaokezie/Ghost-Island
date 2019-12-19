using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float spawnZPos = 20;
    public float spawnXRange = 15;

    public float delay = 2;
    public float interval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", delay, interval);
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int randIndex = Random.Range(0, enemiesPrefabs.Length);
        float randXPos = Random.Range(-spawnXRange, spawnXRange);

      // Instantiate(enemiesPrefabs[randIndex], new Vector3(randXPos, 2, spawnZPos), enemiesPrefabs[randIndex].transform.rotation);
        Instantiate(enemiesPrefabs[randIndex], new Vector3(-386, 7, 736), enemiesPrefabs[randIndex].transform.rotation);



    }
}
