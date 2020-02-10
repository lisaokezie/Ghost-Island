using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float speed = 15;

    Vector3 mPrevPos;

    void Start()
    {
        mPrevPos = transform.position;
    }

    void Update()
    {
        mPrevPos = transform.position;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit[] hits = Physics.RaycastAll(new Ray(mPrevPos, (transform.position - mPrevPos).normalized),(transform.position - mPrevPos).magnitude);

        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.tag == "Enemy")
            {
                Destroy(hits[i].collider.gameObject);
                SpawnManager.killEnemy();
            }
        }

        Destroy(gameObject, 2.0f);
    }
}
