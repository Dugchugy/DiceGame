using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    // determines how far the player's shots travel
    public float range = 7;

    public Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
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
    }

    void OnCollisionEnter2D(Collision2D c){
        Destroy(gameObject);
    }
}
