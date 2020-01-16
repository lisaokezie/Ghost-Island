﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    PlayerHealth playerHealth;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Heal()
    {
        // If the player has health.
        if (playerHealth.currentHealth > 0 && playerHealth.currentHealth < 100)
        {
            // heal
            playerHealth.Heal();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Pilz heilt Player");
            Heal();
            Destroy(gameObject);
        }
    }
}
