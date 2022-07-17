using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    // determines how far the player's shots travel
    public float range = 7;

    public float rotationSpeed = 3.5f;

    public Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        //GetComponent<Rigidbody2D>().angularVelocity  = rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 travelDistance = originalPosition - transform.position;
        if(travelDistance.magnitude >= range)
        {
            Destroy(gameObject);

            //this
        }

        transform.eulerAngles += new Vector3(0, 0, rotationSpeed);
    }

    void OnCollisionEnter2D(Collision2D c){
        Destroy(gameObject);
    }
}
