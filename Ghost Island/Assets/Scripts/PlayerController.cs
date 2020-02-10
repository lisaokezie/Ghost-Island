using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject weapon;
    public GameObject ShootingPosition;

   // UIManager uiManager;
    public bool isGameOver = false;
    public bool hasWeapon = false;
    public bool hasWon = false;
    public bool isPaused = false;

    // Screens
    public GameObject winnerScreen;
    public GameObject pauseScreen;

    // Items
    public int collectedItems = 0;
    public GameObject[] itemsUI;
    public GameObject[] items;

    public GameObject ladder;

    AudioManager audioManager;

    void Start()
    {
        pauseScreen.SetActive(false);
        winnerScreen.SetActive(false);
        ladder.SetActive(false);
        weapon.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        for (int i = 0; i < itemsUI.Length; i++)
        {
            itemsUI[i].SetActive(false);
        }

    }

    private void Update()
    {


        if (hasWeapon)
        {
           weapon.SetActive(true);
        }

        if (hasWeapon == false)
        {
            weapon.SetActive(false);
        }

       

        if (hasWon == true)
        {
            Time.timeScale = 0;
            winnerScreen.SetActive(true);
        }

       
        // Pause Screen
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
               
            }
        }


        // Game Over/Won: Press key to go back to Menu
        if (isPaused || isGameOver || hasWon)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //gameObject.SetActive(false);
                UIManager.QuitGame();
            }

        }

        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                UIManager.GoToLevell1();

            }
        }
        }
    
    void checkItemNumber()
    {
        if(collectedItems == 5)
        {
            ladder.SetActive(true);
            Debug.Log("Baumhausleiter");
        }
    }

    void showUI(int i)
    {
       itemsUI[i].SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        isPaused = true;
    }

    void ContinueGame() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    //Wenn eine Kolllision mit einem GameObjekt (Tag: "Weapon") stattfindet, wird die Waffe aktiviert
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("Weapon wurde aufgesammelt");
            weapon.SetActive(true);
            Destroy(other.gameObject);
            hasWeapon = true;
            audioManager.PlayWeaponAudio();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player wurde angegriffen");
            //isGameOver = true;
        }

        if (other.gameObject.CompareTag("Item"))
        {
            for (int i = 0; i < items.Length; i++)
               {
                   if(other.gameObject == items[i])
                    {
                        showUI(i);
                        Destroy(other.gameObject);
                         collectedItems++;
                        checkItemNumber();
                        Debug.Log("Item aufgesammelt");
                        audioManager.PlayItemAudio();
                }
               }
        }

        if (other.gameObject.CompareTag("WinTrigger"))
        {
            hasWon = true;            
            audioManager.PlayWinMusicAudio();
        }
    }

}