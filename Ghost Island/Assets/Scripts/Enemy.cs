using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject player;
    public float speed = 1;
    public int damage = 5;

    PlayerHealth playerHealth;
    AudioManager audioManager;

    //public GameObject spawnManager;

    //public SpawnManager spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    //public static int enemyCount;



    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        player = GameObject.Find("FPSController");

        playerHealth = player.GetComponent<PlayerHealth>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        //enemyCount = SpawnManager.enemiesAlive;

        //spawnManager = GameObject.Find("SpawnManager");
        //spawnManager


    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform);
        //transform.Translate(0, 0, speed * Time.deltaTime);

        //enemyCount = SpawnManager.enemiesAlive;

        transform.LookAt(player.transform);

        // Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.position += transform.forward * speed * Time.deltaTime;
            
       // playerRB.AddForce(lookDirection * speed * Time.deltaTime);
        
    }

    void Attack()
    {

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(damage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           
            Attack();
            Destroy(gameObject);
            SpawnManager.killEnemy();
            audioManager.PlayEnemyAudio();
        }
        
    }

    public void Die()
    {        
        Destroy(gameObject);
        Debug.Log("Enemy killed!");
    }


}
