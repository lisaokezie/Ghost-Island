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

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        player = GameObject.Find("FPSController");

        playerHealth = player.GetComponent<PlayerHealth>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    void Update()
    {

        transform.LookAt(player.transform);

        transform.position += transform.forward * speed * Time.deltaTime;
               
    }

    void Attack()
    {

        if (playerHealth.currentHealth > 0)
        {
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
