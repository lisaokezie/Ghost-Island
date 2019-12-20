using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody playerRB;
    private GameObject player;
    public float speed = 300;

    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        player = GameObject.Find("FPSController");

        // Player Health
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        playerRB.AddForce(lookDirection * speed * Time.deltaTime);

        //if (transform.position.y < -10)
      //  {
         //   Destroy(gameObject);
       // }
    }

    void Attack()
    {

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(10);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Attack();
        }
        
    }

   
}
