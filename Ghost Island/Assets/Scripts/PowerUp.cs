using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    PlayerHealth playerHealth;

    private GameObject player;

    AudioManager audioManager;
 
    void Start()
    {
        player = GameObject.Find("FPSController");
        playerHealth = player.GetComponent<PlayerHealth>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
    }

    void Heal()
    {
        if (playerHealth.currentHealth > 0 && playerHealth.currentHealth < 100)
        {
            playerHealth.Heal();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
           
            Heal();
            Destroy(gameObject);
            audioManager.PlayEnergyAudio();
          
        }
    }
}
