﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
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
        if (playerHealth.currentHealth <= 0)
        {
            playerHealth.Death();
        }

    }


    void damage()
    {
            if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.Damage();
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Feuer verbrennt Player");
            damage();

        }
    }
}
