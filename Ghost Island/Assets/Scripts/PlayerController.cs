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



    // Start is called before the first frame update
    void Start()
    {

        weapon.SetActive(false);
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

    }
    void LateUpdate()
    {

        if (Input.GetKey(KeyCode.Mouse1) && Time.time > nextFire && hasWeapon)
        {
            Instantiate(projectilePrefab, Camera.main.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        
        
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
    }
}