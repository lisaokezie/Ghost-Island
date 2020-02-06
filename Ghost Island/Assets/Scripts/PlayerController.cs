using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float fireRate = 1;
    private float nextFire = 0;

    public GameObject projectilePrefab;
    public GameObject weapon;
    public GameObject ShootingPosition;

    public GameObject Flash;
    public GameObject MuzzleLight;

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
        ladder = GameObject.Find("Leiter");
        ladder.SetActive(false);
        weapon.SetActive(false);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        for (int i = 0; i < itemsUI.Length; i++)
        {
            itemsUI[i].SetActive(false);
        }

        Flash.SetActive(false);
    }

    private void Update()
    {
        Flash.SetActive(false);
        MuzzleLight.SetActive(false);

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
            winnerScreen.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && hasWeapon)
        {
            Flash.SetActive(true);
            MuzzleLight.SetActive(true);
            Instantiate(projectilePrefab, ShootingPosition.transform.position, ShootingPosition.transform.rotation);
            nextFire = Time.time + fireRate;
            audioManager.PlayShootAudio();
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
            if (Input.GetKeyDown(KeyCode.M))
            {
                UIManager.GoToMenu();
            }

        }
        }


    void LateUpdate()
    {
        //if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && hasWeapon)
        //{
        //    Instantiate(projectilePrefab, ShootingPosition.transform.position, ShootingPosition.transform.rotation);
        //    nextFire = Time.time + fireRate;
        //    audioManager.PlayShootAudio();
        //}
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
            other.gameObject.SetActive(true);
            Destroy(other.gameObject);
            hasWeapon = true;
            audioManager.PlayWeaponAudio();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player wurde angegriffen");
            isGameOver = true;
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