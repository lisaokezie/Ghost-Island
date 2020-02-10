using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

    public int collectedItems;

    public GameObject[] itemsUI;

    private Rigidbody playerRB;
    private GameObject player;
  

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

    }


}
