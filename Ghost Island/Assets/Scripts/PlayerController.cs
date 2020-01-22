using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float fireRate = 1;
    private float nextFire = 0;

    
    public GameObject projectilePrefab;
    public GameObject weapon;
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

    void Start()
    {

        pauseScreen.SetActive(false);
        winnerScreen.SetActive(false);
        ladder.SetActive(false);
        weapon.SetActive(false);
        //player = GameObject.Find("FPSController");
        //playerHealth = player.GetComponent<PlayerHealth>();

        for (int i = 0; i < itemsUI.Length; i++)
        {
            itemsUI[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(hasWeapon)
        {
            weapon.SetActive(true);
        }

        if (hasWeapon == false)
        {
            weapon.SetActive(false);
        }

        if(hasWon == true)
        {
            winnerScreen.SetActive(true);
        }

        // Pause Screen
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            if (!isPaused)
            {
                PauseGame();
                Debug.Log("Pause Game");
            }
            else
            {
                ContinueGame();
                Debug.Log("Continue");
            }
        }

    }
    void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && hasWeapon)
        {
            Instantiate(projectilePrefab, Camera.main.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
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

    void PauseGame()
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
                    }
               }
        }

    }
}