using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    AudioManager audioManager;
    private GameObject player;
    public bool isDead;                                              

    void Start()
    {
        player = GameObject.Find("FPSController");

        currentHealth = startingHealth;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

  
    public void TakeDamage(int amount)
    {     
        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Player ist gestorben!");
            Death();
            audioManager.PlayGameOverAudio();
        }
    }

    public void Heal()
    {
        currentHealth += 10;
        healthSlider.value = currentHealth;
    }

    public void Damage()
    {
        currentHealth -= 5;
        healthSlider.value = currentHealth;
       
    }

    public void Death()
    {        
        isDead = true;
        player.GetComponent<PlayerController>().isGameOver = true;

    }

}
