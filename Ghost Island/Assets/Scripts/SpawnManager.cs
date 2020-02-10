using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public float spawnZPos = 20;
    public float spawnXRange = 15;
    public bool isSpawning = false;

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

    }

    private void Update()
    {
        if (isSpawning)
        {
            return;
        }

        StartCoroutine(Spawn());
    }



    public static void killEnemy()
    {
        enemiesAlive = enemiesAlive - 1;
    }

    void SpawnEnemies()
    {
        int randIndex = Random.Range(0, enemiesPrefabs.Length);
      
        GameObject place = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Vector3 position = place.transform.position;

        Instantiate(enemiesPrefabs[randIndex], position, enemiesPrefabs[randIndex].transform.rotation);


    }

    IEnumerator Spawn()
    {

        isSpawning = true;

        if (enemiesAlive == 0)
        {
            yield return new WaitForSeconds(5f);

        }

        yield return new WaitForSeconds(2.5f);
        if (enemiesAlive < 10)
        {

            SpawnEnemies();
            enemiesAlive++;
        }
        else
        {
            Debug.Log("Too many Enemies in the Game!");
        }

        Debug.Log(enemiesAlive);

        isSpawning = false;
    }
}
