using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisability : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if (FindObjectOfType<FirstPersonController>() != null)
        //{
        //    Cursor.visible = false;
        //} else
        //{
        //    Cursor.visible = true;
        //}

        // Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;
        //Cursor.lockState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
