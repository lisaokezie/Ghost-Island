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
    //PlayerController pc;
    public bool isDead;                                              
    //bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController");

        currentHealth = startingHealth;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        //damaged = true;

        currentHealth -= amount;

        // Set the health bar's value to the current health.
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

    }

}
