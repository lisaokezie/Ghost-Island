using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
            Debug.Log(other.gameObject.name);
        Destroy(gameObject);
        Destroy(other.gameObject);

    }
}
