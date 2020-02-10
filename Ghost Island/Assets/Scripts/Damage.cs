using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    PlayerHealth playerHealth;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("FPSController");
        playerHealth = player.GetComponent<PlayerHealth>();

    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.Death();
        }

    }


    void damage()
    {
            if (playerHealth.currentHealth > 0)
        {
            playerHealth.Damage();
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            damage();

        }
    }
}
