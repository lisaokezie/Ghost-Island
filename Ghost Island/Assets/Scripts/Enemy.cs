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

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        player = GameObject.Find("FPSController");

        playerHealth = player.GetComponent<PlayerHealth>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform);

        transform.position += transform.forward * speed * Time.deltaTime;
               
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
            audioManager.PlayDamageAudio();
        }
        
    }


}
