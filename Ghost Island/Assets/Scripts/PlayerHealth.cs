using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour

{

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    bool isDead;                                              
    bool damaged;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
       
        damaged = true;

        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Player ist gestorben!");
            Death();
        }
    }

    void Death()
    {
        
        isDead = true;

    }

}
