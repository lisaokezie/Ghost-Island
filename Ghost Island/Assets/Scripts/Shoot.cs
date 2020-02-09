using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float speed = 15;

    Vector3 mPrevPos;



    // Start is called before the first frame update
    void Start()
    {
        mPrevPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mPrevPos = transform.position;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit[] hits = Physics.RaycastAll(new Ray(mPrevPos, (transform.position - mPrevPos).normalized),(transform.position - mPrevPos).magnitude);

        for(int i = 0; i < hits.Length; i++)
        {
            // Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider.tag == "Enemy")
            {
                Destroy(hits[i].collider.gameObject);
            }
        }

        Destroy(gameObject, 2.0f);
    }
}
