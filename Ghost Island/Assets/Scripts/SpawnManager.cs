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
    private GameObject player;

    PlayerController pc;
 

    public GameObject[] spawnPoints;

    public static int enemiesAlive = 0;

    void Start()
    {
        player = GameObject.Find("FPSController");
        pc = player.GetComponent<PlayerController>();

        while (enemiesAlive < 12 && enemiesAlive >= 0 && (!pc.isGameOver || !pc.hasWon)) { 
            InvokeRepeating("SpawnEnemies", delay, interval);
            enemiesAlive++;
            Debug.Log(enemiesAlive);
        }
    }

    private void Update()
    {
        
    }


    public static void killEnemy()
    {
        enemiesAlive = enemiesAlive-1;
    }

    void SpawnEnemies()
    {
        int randIndex = Random.Range(0, enemiesPrefabs.Length);
        //float randXPos = Random.Range(-spawnXRange, spawnXRange);

        // Instantiate(enemiesPrefabs[randIndex], new Vector3(randXPos, 2, spawnZPos), enemiesPrefabs[randIndex].transform.rotation);

        //Instantiate(enemiesPrefabs[randIndex], new Vector3(386, 7, 736), enemiesPrefabs[randIndex].transform.rotation);


        GameObject place = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 position = place.transform.position;

        Instantiate(enemiesPrefabs[randIndex], position, enemiesPrefabs[randIndex].transform.rotation);

        enemiesAlive++;
        Debug.Log(enemiesAlive);

    }
}
