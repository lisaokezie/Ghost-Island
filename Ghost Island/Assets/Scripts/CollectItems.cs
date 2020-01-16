using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

    public int collectedItems;

    //UI Elemente
    //public GameObject hammerUI;
    //public GameObject nailsUI;
    //public GameObject woodUI;
    //public GameObject ladderUI;
    //public GameObject keyUI;

    //Lösung mit Array
    public GameObject[] itemsUI;

    //GameObjects
    //public GameObject hammer;
    //public GameObject nails;
    //public GameObject wood;
    //public GameObject ladder;
    //public GameObject key;

    //Player
    private Rigidbody playerRB;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        collectedItems = 0;

        playerRB = GetComponent<Rigidbody>();
        player = GameObject.Find("FPSController");


        for (int i = 0; i < itemsUI.Length; i++)
        {
            itemsUI[i].SetActive(false);
        }
    }

   

    public void collectItem(int i)
    {
        itemsUI[i].SetActive(true);
        collectedItems++;
        Debug.Log("Show Item UI");

        if(collectedItems == 5)
        {
            Debug.Log("Alle Items wurden aufgesammelt");
        }
    }


}
