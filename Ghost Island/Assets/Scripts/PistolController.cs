using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolController : MonoBehaviour
{

    public GameObject ShootingPosition;
    public GameObject projectilePrefab;



    public float fireRate = 1;
    private float nextFire = 0;
    public ParticleSystem MuzzleFlash;
    private bool weapon;

    public int maxAmmo = 8;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public Animator animator;

    public Text ammoDisplay;


    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        GameObject thePlayer = GameObject.Find("FPSController");
        PlayerController playerController = thePlayer.GetComponent<PlayerController>();
        weapon = playerController.hasWeapon;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {


        if (isReloading)
        {
            return;
        }


        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire && weapon)
        {


            Instantiate(projectilePrefab, ShootingPosition.transform.position, ShootingPosition.transform.rotation);
            currentAmmo--;
            nextFire = Time.time + fireRate;
            MuzzleFlash.Play();
            //Shoot();

            audioManager.PlayShootAudio();

            animator.SetTrigger("shoot");
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

    }

    private void LateUpdate()
    {
        ammoDisplay.text = currentAmmo.ToString() + " | ∞";


    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        audioManager.PlayReloadAudio();

        animator.SetBool("reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    void Shoot()
    {



        RaycastHit hit;

        if (Physics.Raycast(ShootingPosition.transform.position, ShootingPosition.transform.forward, out hit))
        {

            Enemy enemy = hit.transform.GetComponent<Enemy>();

            Debug.Log(hit.transform.GetComponent<Enemy>());

            if (hit.collider.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }


    }

    //void kill (Collider other)
    //{
    //    Destroy(other.gameObject);
    //}
}
