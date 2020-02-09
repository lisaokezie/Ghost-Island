using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    PlayerHealth playerHealth;
    public GameObject gameOverScreen;
    private GameObject player;



    void Start()
    {
        gameOverScreen.SetActive(false);

        player = GameObject.Find("FPSController");
        playerHealth = player.GetComponent<PlayerHealth>();

       



    }

    void Update()
    {
        if (playerHealth.isDead == true)
        {
            gameOverScreen.SetActive(true);
            
           
        }
    }
}
